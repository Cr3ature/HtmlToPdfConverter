using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfConverter.Configuration;
using HtmlToPdfConverter.Core;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HtmlToPdfConverter.Abstractions.Configuration
{
    public static class HostContainerExtenstion
    {
        public static IServiceCollection AddHtmlToPdfConverterService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IPdfConverterCore, PdfConverterCore>();

            var context = new CustomAssemblyLoadContext();
            var projectRootFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var path = Path.Combine(projectRootFolder, "libwkhtmltox");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = Path.Combine(projectRootFolder, "libwkhtmltox.so");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                path = Path.Combine(projectRootFolder, "libwkhtmltox.dylib");
            }

            context.LoadUnmanagedLibrary(path);

            return services;
        }


    }
}
