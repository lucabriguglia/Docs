using System.Reflection;
using Docs.Models;

namespace Docs
{
    public interface IDocumentationService
    {
        void Generate(params Assembly[] assemblies);
        string GetLatestAsJson();
        DocumentationModel GetLatest();
    }
}