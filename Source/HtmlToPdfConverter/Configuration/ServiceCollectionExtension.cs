using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfConverterCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HtmlToPdfConverter.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHtmlToPdfConverter(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddSingleton<IPdfConverter, PdfConverter>();

            var context = new CustomAssemblyLoadContext();

            string path = GetPath();

            context.LoadUnmanagedLibrary(path);

            return services;
        }

        private static string GetPath()
        {
            string projectRootFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string runtimeArchitecture = RuntimeInformation.ProcessArchitecture.ToString().ToLower();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var folderName = "win-" + runtimeArchitecture;
                return Path.Combine(projectRootFolder, "runtimes", folderName, "native", "libwkhtmltox.dll");
            } 
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var folderName = "linux-" + runtimeArchitecture;
                return Path.Combine(projectRootFolder, "runtimes", folderName, "native", "libwkhtmltox.so");
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var folderName = "osx-" + runtimeArchitecture;
                return Path.Combine(projectRootFolder, "runtimes", folderName, "native", "libwkhtmltox.dylib");
            }
            
            throw new InvalidOperationException("Supported OS Platform not found");
        }
    }
}