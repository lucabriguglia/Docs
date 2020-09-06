using System;
using System.Reflection;
using System.Xml;

namespace Docs.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Get summary for type.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSummaryFor(this XmlDocument document, Type type)
        {
            var element = document.GetMemberNode("T", type.FullName);
            return element.GetSummary();
        }

        /// <summary>
        /// Get summary for member info.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static string GetSummaryFor(this XmlDocument document, MemberInfo memberInfo)
        {
            var element = document.GetMemberNode("M", memberInfo.Name);
            return element.GetSummary();
        }

        /// <summary>
        /// Get summary for method info.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static string GetSummaryFor(this XmlDocument document, MethodInfo methodInfo)
        {
            var parameters = string.Empty;

            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                if (parameters.Length > 0)
                {
                    parameters += ",";
                }

                parameters += parameterInfo.ParameterType.FullName;
            }

            var name = parameters.Length > 0 ? $"{methodInfo.Name}({parameters})" : methodInfo.Name;
            var element = document.GetMemberNode("M", name);

            return element.GetSummary();
        }

        /// <summary>
        /// Get summary for property info.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static string GetSummaryFor(this XmlDocument document, PropertyInfo propertyInfo)
        {
            var element = document.GetMemberNode("P", propertyInfo.Name);
            return element.GetSummary();
        }

        private static XmlElement GetMemberNode(this XmlDocument document, string prefix, string name)
        {
            return document["doc"]?["members"]?.SelectSingleNode($"member[@name='{prefix}:{name}']") as XmlElement;
        }

        private static string GetSummary(this XmlElement element)
        {
            var summary = element?.GetTextFor("summary");
            return !string.IsNullOrWhiteSpace(summary) ? summary : "Summary not found.";
        }

        private static string GetTextFor(this XmlElement element, string xpath)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var node = element.SelectSingleNode(xpath);

            return node != null
                ? node.InnerText.Trim()
                : string.Empty;
        }
    }
}