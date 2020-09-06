using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Docs.Attributes;
using Docs.Extensions;
using Docs.Models;

namespace Docs
{
    /// <inheritdoc />
    public class AssemblyScanner : IAssemblyScanner
    {
        /// <inheritdoc />
        public DocumentationModel Scan(params Assembly[] assemblies)
        {
            var watch = new Stopwatch();
            watch.Start();

            var documents = new Dictionary<string, XmlDocument>();
            var contexts = new List<Context>();
            var requests = new List<Request>();

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

                        var target = new Target(assembly.FullName, type);

                        var name = !string.IsNullOrWhiteSpace(targetContext) ? targetContext : "General";

                        var context = contexts.FirstOrDefault(x => x.Name == name);

                        if (context != null)
                        {
                            context.Targets.Add(target);
                        }
                        else
                        {
                            contexts.Add(new Context(name, target));
                        }

                        continue;
                    }

                    if (type.GetCustomAttribute(typeof(DocRequestAttribute)) != null)
                    {
                        requests.Add(new Request(assembly.FullName, type));
                    }
                }
            }

            var data = BuildData(documents, contexts, requests);

            watch.Stop();

            return new DocumentationModel(data, DateTime.UtcNow, watch.ElapsedMilliseconds);
        }

        private static List<ContextModel> BuildData(Dictionary<string, XmlDocument> documents, IEnumerable<Context> contexts, IEnumerable<Request> requests)
        {
            var result = new List<ContextModel>();

            foreach (var context in contexts.OrderBy(x => x.Name))
            {
                var contextModel = new ContextModel(context.Name);

                foreach (var target in context.Targets)
                {
                    var document = documents.FirstOrDefault(x => x.Key == target.Assembly).Value;
                    var summary = document.GetSummaryFor(target.Type);

                    var targetModel = new TargetModel(target.Type.Name, summary);

                    contextModel.AddTarget(targetModel);
                }

                contextModel.Targets = contextModel.Targets.OrderBy(x => x.Name).ToList();

                result.Add(contextModel);
            }

            foreach (var request in requests)
            {
                var requestAttribute = (DocRequestAttribute)request.Type.GetCustomAttribute(typeof(DocRequestAttribute));
                var targetType = requestAttribute.Target;

                var document = documents.FirstOrDefault(x => x.Key == request.Assembly).Value;
                var summary = document.GetSummaryFor(request.Type);

                var requestModel = new RequestModel(request.Type.Name, summary, targetType?.Name);

                ContextModel contextModel = null;

                foreach (var context in
                    from context in result
                    from target in context.Targets
                    where target.Name == targetType?.Name
                    select context)
                {
                    contextModel = context;
                }

                contextModel?.AddRequest(requestModel);
            }

            foreach (var target in result.SelectMany(context => context.Targets))
            {
                target.Requests = target.Requests.OrderBy(x => x.Name).ToList();
            }

            return result;
        }

        private class Context
        {
            public string Name { get; }
            public IList<Target> Targets { get; } = new List<Target>();

            public Context(string name, Target target)
            {
                Name = name;
                Targets.Add(target);
            }
        }

        private class Target
        {
            public string Assembly { get; }
            public Type Type { get; }

            public Target(string assembly, Type type)
            {
                Assembly = assembly;
                Type = type;
            }
        }

        private class Request
        {
            public string Assembly { get; }
            public Type Type { get; }

            public Request(string assembly, Type type)
            {
                Assembly = assembly;
                Type = type;
            }
        }
    }
}