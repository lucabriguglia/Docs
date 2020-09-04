using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Docs
{
    /// <inheritdoc />
    public class DocumentationGenerator : IDocumentationGenerator
    {
        private readonly IAssemblyScanner _assemblyScanner;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyScanner"></param>
        public DocumentationGenerator(IAssemblyScanner assemblyScanner)
        {
            _assemblyScanner = assemblyScanner;
        }

        /// <inheritdoc />
        public void Generate(params Assembly[] assemblies)
        {
            var models = _assemblyScanner.Scan(assemblies);
            var json = JsonSerializer.Serialize(models);

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Documentation");

            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            var fileName = $"documentation.{DateTime.UtcNow:yy-MM-dd-HH-mm-ss}.json";
            var fullPath = Path.Combine(pathToSave, fileName);

            File.WriteAllText(fullPath, json);
        }
    }
}