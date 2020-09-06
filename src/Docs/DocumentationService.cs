using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Docs.Models;

namespace Docs
{
    /// <inheritdoc />
    public class DocumentationService : IDocumentationService
    {
        private readonly string _path;

        private readonly IAssemblyScanner _assemblyScanner;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyScanner"></param>
        public DocumentationService(IAssemblyScanner assemblyScanner)
        {
            _assemblyScanner = assemblyScanner;

            _path = Path.Combine(Directory.GetCurrentDirectory(), "Documentation");

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        /// <inheritdoc />
        public void Generate(params Assembly[] assemblies)
        {
            var models = _assemblyScanner.Scan(assemblies);
            var json = JsonSerializer.Serialize(models, new JsonSerializerOptions { WriteIndented = true });

            var count = Directory.GetFiles(_path).Length;
            var fileName = $"documentation.v{count + 1}.json";

            var fullPath = Path.Combine(_path, fileName);

            File.WriteAllText(fullPath, json);
        }

        /// <inheritdoc />
        public string GetLatestAsJson()
        {
            var latest = Directory.GetFiles(_path).OrderByDescending(f => new FileInfo(f).Name).FirstOrDefault();

            return latest != null ? File.ReadAllText(latest) : string.Empty;
        }

        /// <inheritdoc />
        public DocumentationModel GetLatest()
        {
            var json = GetLatestAsJson();

            return !string.IsNullOrEmpty(json) ? JsonSerializer.Deserialize<DocumentationModel>(json) : null;
        }
    }
}