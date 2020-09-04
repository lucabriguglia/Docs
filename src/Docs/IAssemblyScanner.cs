using System.Reflection;

namespace Docs
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssemblyScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblies"></param>
        void Scan(Assembly[] assemblies);
    }
}
