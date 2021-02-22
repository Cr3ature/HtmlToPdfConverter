namespace HtmlToPdfConverterCore
{
    using System;
    using System.Reflection;
    using System.Runtime.Loader;

    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
            => this.LoadUnmanagedDll(absolutePath);

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
            => this.LoadUnmanagedDllFromPath(unmanagedDllName); 
    }
}