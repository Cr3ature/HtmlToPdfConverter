using System;
using System.Reflection;
using System.Runtime.Loader;

namespace HtmlToPdfConverter.Configuration
{
    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return this.LoadUnmanagedDll(absolutePath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            return this.LoadUnmanagedDllFromPath(unmanagedDllName);
        }
    }
}
