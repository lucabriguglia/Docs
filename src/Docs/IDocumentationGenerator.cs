using System.Reflection;

namespace Docs
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentationGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblies"></param>
        void Generate(params Assembly[] assemblies);
    }
}