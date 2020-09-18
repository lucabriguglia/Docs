using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Docs.Attributes;
using Docs.ScanTypes;

namespace Docs
{
    public class AssemblyScanner : IAssemblyScanner
    {
        public ScanResult Scan(params Assembly[] assemblies)
        {
            var watch = new Stopwatch();
            watch.Start();

            var documents = new Dictionary<string, XmlDocument>();
            var contexts = new List<ContextType>();
            var requests = new List<RequestType>();

            foreach (var assembly in assemblies)
            {
                var documentPath = Path.ChangeExtension(assembly.Location, ".xml");

                XmlDocument document = null;

                if (File.Exists(documentPath))
                {
                    document = new XmlDocument();
                    document.Load(documentPath);
                }

                if (document == null)
                {
                    throw new Exception($"No xml document found for assembly {assembly.FullName}. Make sure to generate the xml document when building the project.");
                }

                documents.Add(assembly.FullName, document);

                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute(typeof(DocTargetAttribute)) != null)
                    {
                        var targetAttribute = (DocTargetAttribute)type.GetCustomAttribute(typeof(DocTargetAttribute));
                        var targetContext = targetAttribute.Context;

                        var target = new TargetType(assembly.FullName, type);

                        var name = !string.IsNullOrWhiteSpace(targetContext) ? targetContext : "General";

                        var context = contexts.FirstOrDefault(x => x.Name == name);

                        if (context != null)
                        {
                            context.Targets.Add(target);
                        }
                        else
                        {
                            contexts.Add(new ContextType(name, target));
                        }

                        continue;
                    }

                    if (type.GetCustomAttribute(typeof(DocRequestAttribute)) != null)
                    {
                        requests.Add(new RequestType(assembly.FullName, type));
                    }
                }
            }

            watch.Stop();

            return new ScanResult
            {
                Documents = documents,
                Contexts = contexts,
                Requests = requests,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };
        }
    }
}