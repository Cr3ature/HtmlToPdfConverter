namespace HtmlToPdfConverter.Abstractions.Configuration
{
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using HtmlToPdfConverter.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public static class ServiceCollectionExtenstion
    {
        public static IServiceCollection AddHtmlToPdfConverterService(this IServiceCollection services )
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IPdfConverter, PdfConverter>();

            var context = new CustomAssemblyLoadContext();
            var projectRootFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var path = Path.Combine(projectRootFolder, RuntimeInformation.ProcessArchitecture.ToString(), "libwkhtmltox.dll");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = Path.Combine(projectRootFolder, RuntimeInformation.ProcessArchitecture.ToString(), "libwkhtmltox.so");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                path = Path.Combine(projectRootFolder,  RuntimeInformation.ProcessArchitecture.ToString(), "libwkhtmltox.dylib");
            }

            context.LoadUnmanagedLibrary(path);

            return services;
        }
    }
}
