using System.Reflection;
using Docs.ScanTypes;

namespace Docs
{
    /// <summary>
    /// IAssemblyScanner
    /// </summary>
    public interface IAssemblyScanner
    {
        /// <summary>
        /// Scan
        /// </summary>
        /// <param name="assemblies"></param>
        ScanResult Scan(params Assembly[] assemblies);
    }
}
