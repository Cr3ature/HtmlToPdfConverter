namespace HtmlToPdfConverterCore
{
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public static class ServiceCollectionExtenstion
    {
        public static IServiceCollection AddHtmlToPdfConverterCore(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            var context = new CustomAssemblyLoadContext();
            string projectRootFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string path;
            string runtimeArchitecture = RuntimeInformation.ProcessArchitecture.ToString().ToLower();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = Path.Combine(projectRootFolder, "runtimes", "win-"+runtimeArchitecture, "native", "libwkhtmltox.dll");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                path = Path.Combine(projectRootFolder, "runtimes", "linux-"+runtimeArchitecture, "native", "libwkhtmltox.so");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                path = Path.Combine(projectRootFolder, "runtimes", "osx-"+runtimeArchitecture, "native", "libwkhtmltox.dylib");
            else
                throw new InvalidOperationException("Supported OS Platform not found");

            context.LoadUnmanagedLibrary(path);

            return services;
        }
    }
}