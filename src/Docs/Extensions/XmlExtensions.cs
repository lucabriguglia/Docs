using System;
using System.Xml;

namespace Docs.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSummary(this XmlDocument document, Type type)
        {
            if (document == null)
            {
                return $"Documentation file for assembly {type.Assembly.FullName} not found.";
            }

            var fullName = $"T:{type.FullName}";

            if (!(document["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']") is XmlElement memberElement))
            {
                return string.Empty;
            }

            var summaryNode = memberElement.SelectSingleNode("summary");

            var summary = summaryNode != null
                ? summaryNode.InnerText.Trim()
                : string.Empty;

            return !string.IsNullOrWhiteSpace(summary)
                ? summary
                : $"Summary for type {type.Name} not found.";
        }
    }
}