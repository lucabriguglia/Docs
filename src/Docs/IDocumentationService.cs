using System.Reflection;
using Docs.Models;

namespace Docs
{
    /// <summary>
    /// IDocumentationService
    /// </summary>
    public interface IDocumentationService
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="assemblies"></param>
        void Generate(params Assembly[] assemblies);

        /// <summary>
        /// GetLatestAsJson
        /// </summary>
        /// <returns></returns>
        string GetLatestAsJson();

        /// <summary>
        /// GetLatest
        /// </summary>
        /// <returns></returns>
        DocumentationModel GetLatest();
    }
}