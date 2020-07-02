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
        /// <param name="assembly"></param>
        void Scan(Assembly assembly);
    }
}
