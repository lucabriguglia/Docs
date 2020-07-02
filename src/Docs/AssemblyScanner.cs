using System;
using System.IO;
using System.Reflection;
using System.Xml;

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

            if (documentation == null)
            {
                throw new Exception();
            }

            foreach (var type in assembly.GetTypes())
            {
                var targetAttribute = type.GetCustomAttribute(typeof(DocTargetAttribute));
                var requestAttribute = type.GetCustomAttribute(typeof(DocRequestAttribute));

                if (targetAttribute == null && requestAttribute == null)
                {
                    continue;
                }

                if (targetAttribute != null && requestAttribute != null)
                {
                    throw new Exception();
                }

                var fullName = $"T:{type.FullName}";
                var fullName2 = $"T:{type.FullName}.{typeof(DocTargetAttribute).Name}";

                if (documentation["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']") is XmlElement memberElement)
                {
                    var summaryNode = memberElement.SelectSingleNode("summary");

                    if (summaryNode != null)
                    {
                        var summary = summaryNode.InnerText.Trim();
                    }
                }

                if (targetAttribute != null)
                {
                    var target = (DocTargetAttribute)targetAttribute;
                }

                if (requestAttribute != null)
                {
                    var request = (DocRequestAttribute)requestAttribute;
                    var target = request.Target;
                }
            }
        }
    }
}