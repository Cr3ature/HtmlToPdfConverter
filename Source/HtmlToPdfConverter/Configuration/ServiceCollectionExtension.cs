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
            var projectRootFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string path;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = Path.Combine(projectRootFolder, "runtimes\\win-x64\\native", "libwkhtmltox.dll");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                path = Path.Combine(projectRootFolder, "runtimes\\linux-x64\\native", "libwkhtmltox.so");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                path = Path.Combine(projectRootFolder, "runtimes\\osx-x64\\native", "libwkhtmltox.dylib");
            else
                throw new InvalidOperationException("Supported OS Platform not found");

            context.LoadUnmanagedLibrary(path);

            return services;
        }
    }
}