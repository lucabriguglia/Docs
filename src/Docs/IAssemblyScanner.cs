using System.Reflection;
using Docs.Models;

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
        DocumentationModel Scan(params Assembly[] assemblies);
    }
}
