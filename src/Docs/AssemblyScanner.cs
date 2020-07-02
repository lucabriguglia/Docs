using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Docs.DataAnnotations;
using Docs.Models;

namespace Docs
{
    /// <inheritdoc />
    public class AssemblyScanner : IAssemblyScanner
    {
        /// <inheritdoc />
        public void Scan(Assembly assembly)
        {
            var documentationPath = Path.ChangeExtension(assembly.Location, ".xml");

            XmlDocument documentation = null;

            if (File.Exists(documentationPath))
            {
                documentation = new XmlDocument();
                documentation.Load(documentationPath);
            }

            //if (documentation == null)
            //{
            //    throw new Exception();
            //}

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

            var area = new AreaModel(assembly.FullName);

            var targetTypes = new List<Type>();
            var requestTypes = new List<Type>();

            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute(typeof(DocTargetAttribute)) != null)
                {
                    targetTypes.Add(type);
                    continue;
                }

                if (type.GetCustomAttribute(typeof(DocRequestAttribute)) != null)
                {
                    requestTypes.Add(type);
                }
            }

            foreach (var type in targetTypes)
            {
                var target = (DocTargetAttribute)type.GetCustomAttribute(typeof(DocTargetAttribute));

                var fullName = $"T:{type.FullName}";

                var summary = documentation == null
                    ? $"Documentation file for assembly {assembly.FullName} not found."
                    : $"Summary for type {type.Name} not found.";

                if (documentation?["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']") is XmlElement memberElement)
                {
                    var summaryNode = memberElement.SelectSingleNode("summary");

                    if (summaryNode != null)
                    {
                        summary = summaryNode.InnerText.Trim();
                    }
                }


            }

            foreach (var type in requestTypes)
            {

            }
        }
    }
}