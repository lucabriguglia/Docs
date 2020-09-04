using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Docs.DataAnnotations;
using Docs.Extensions;
using Docs.Models;

namespace Docs
{
    public class Context
    {
        public string Name { get; set; }
        public IList<Target> Targets { get; set; } = new List<Target>();

        public Context(string name, Target target)
        {
            Name = name;
            Targets.Add(target);
        }
    }

    public class Target
    {
        public string Assembly { get; set; }
        public Type Type { get; set; }

        public Target(string assembly, Type type)
        {
            Assembly = assembly;
            Type = type;
        }
    }

    public class Request
    {
        public string Assembly { get; set; }
        public Type Type { get; set; }

        public Request(string assembly, Type type)
        {
            Assembly = assembly;
            Type = type;
        }
    }

    public static class ContextListExtensions
    {
        public static IList<Context> Add(this IList<Context> list, string name, Target target)
        {
            var context = list.FirstOrDefault(x => x.Name == name);

            if (context != null)
            {
                context.Targets.Add(target);
            }
            else
            {
                list.Add(new Context(name, target));
            }

            return list;
        }
    }

    /// <inheritdoc />
    public class AssemblyScanner : IAssemblyScanner
    {
        /// <inheritdoc />
        public void Scan(Assembly[] assemblies)
        {
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

                //var fullName2 = $"M:{memberInfo.DeclaringType.FullName}.{memberInfo.Name}";

                //var parametersString = "";
                //foreach (var parameterInfo in methodInfo.GetParameters())
                //{
                //    if (parametersString.Length > 0)
                //    {
                //        parametersString += ",";
                //    }

                //    parametersString += parameterInfo.ParameterType.FullName;
                //}

                //if (parametersString.Length > 0)
                //{
                //    return XmlFromName(methodInfo.DeclaringType, 'M', methodInfo.Name + "(" + parametersString + ")");
                //}
                //else
                //{
                //    return XmlFromName(methodInfo.DeclaringType, 'M', methodInfo.Name);
                //}



                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute(typeof(DocTargetAttribute)) != null)
                    {
                        //var targetAttribute = (DocTargetAttribute)type.GetCustomAttribute(typeof(DocTargetAttribute));
                        //var targetContext = targetAttribute.Context;

                        //var target = new Target(assembly.FullName, type);

                        //contexts.Add(!string.IsNullOrWhiteSpace(targetContext) ? targetContext : "General", target);

                        var contextModel = new ContextModel(context.Name);

                        foreach (var target in context.Targets)
                        {
                            var document = documents.FirstOrDefault(x => x.Key == target.Assembly).Value;
                            var summary = document.GetSummaryFor(target.Type);

                            var targetModel = new TargetModel(target.Type.Name, summary);

                            contextModel.AddTarget(targetModel);
                        }

                        continue;
                    }

                    if (type.GetCustomAttribute(typeof(DocRequestAttribute)) != null)
                    {
                        requests.Add(new Request(assembly.FullName, type));
                    }
                }
            }



            foreach (var context in contexts)
            {
                var contextModel = new ContextModel(context.Name);
                
                foreach (var target in context.Targets)
                {
                    var document = documents.FirstOrDefault(x => x.Key == target.Assembly).Value;
                    var summary = document.GetSummaryFor(target.Type);

                    var targetModel = new TargetModel(target.Type.Name, summary);

                    contextModel.AddTarget(targetModel);
                }
            }

            foreach (var request in requests)
            {
                var requestAttribute = (DocRequestAttribute)request.Type.GetCustomAttribute(typeof(DocRequestAttribute));
                var targetType = requestAttribute.Target;

                var document = documents.FirstOrDefault(x => x.Key == request.Assembly).Value;
                var summary = document.GetSummaryFor(request.Type);

                var requestModel = new RequestModel(request.Type.Name, summary, targetType?.Name);



                foreach (var context in contexts)
                {
                    foreach (var target in context.Targets)
                    {
                        if (target.Type == targetType)
                        {

                        }
                    }
                }

                //contextModel.AddRequest(requestModel);
            }
        }
    }
}