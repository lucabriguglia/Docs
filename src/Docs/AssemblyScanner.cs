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

            var areaModel = new AreaModel(assembly.FullName);

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
                var summary = documentation.GetSummary(type);

                var targetModel = new TargetModel(type.Name, summary);

                areaModel.AddTarget(targetModel);
            }

            foreach (var type in requestTypes)
            {
                var requestAttribute = (DocRequestAttribute)type.GetCustomAttribute(typeof(DocRequestAttribute));
                var targetType = requestAttribute.Target;

                var summary = documentation.GetSummary(type);

                var requestModel = new RequestModel(type.Name, summary, targetType?.Name);

                areaModel.AddRequest(requestModel);
            }
        }
    }
}