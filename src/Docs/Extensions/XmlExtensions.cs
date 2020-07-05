using System;
using System.IO;
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
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSummaryFor(this XmlDocument document, Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (document == null)
            {
                return $"Documentation file for assembly {type.Assembly.FullName} not found.";
            }

            var element = document.GetMemberNode("T", type.FullName);

            //var fullName = $"T:{type.FullName}";

            //if (!(document["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']") is XmlElement memberElement))
            //{
            //    return string.Empty;
            //}

            var summary = element.GetTextFor("summary");

            //var summaryNode = memberElement.SelectSingleNode("summary");

            //var summary = summaryNode != null
            //    ? summaryNode.InnerText.Trim()
            //    : string.Empty;

            return !string.IsNullOrWhiteSpace(summary)
                ? summary
                : $"Summary for type {type.Name} not found.";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetSummaryFor(this XmlDocument document, MemberInfo memberInfo)
        {
            if (memberInfo?.DeclaringType == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            if (document == null)
            {
                return $"Documentation file for assembly {memberInfo.DeclaringType.Assembly.FullName} not found.";
            }

            var element = document.GetMemberNode("M", memberInfo.Name);

            //var fullName = $"M:{memberInfo.Name}";

            //if (!(document["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']") is XmlElement memberElement))
            //{
            //    return string.Empty;
            //}

            var summary = element.GetTextFor("summary");

            //var summaryNode = element.SelectSingleNode("summary");

            //var summary = summaryNode != null
            //    ? summaryNode.InnerText.Trim()
            //    : string.Empty;

            return !string.IsNullOrWhiteSpace(summary)
                ? summary
                : $"Summary for member {memberInfo.Name} not found.";
        }

        private static XmlElement GetMemberNode(this XmlDocument document, string prefix, string name)
        {
            return document["doc"]?["members"]?.SelectSingleNode($"member[@name='{prefix}:{name}']") as XmlElement;
        }

        private static string GetTextFor(this XmlElement element, string xpath)
        {
            var node = element.SelectSingleNode(xpath);

            return node != null
                ? node.InnerText.Trim()
                : string.Empty;
        }
    }
}