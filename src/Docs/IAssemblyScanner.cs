using System.Collections.Generic;
using System.Reflection;
using Docs.Models;

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
        IList<ContextModel> Scan(Assembly[] assemblies);
    }
}
