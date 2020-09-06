using System;
using System.Xml;

namespace Docs.Models
{
    /// <summary>
    /// RequestModel
    /// </summary>
    public class RequestModel : MemberModelBase
    {
        /// <summary>
        /// TargetName
        /// </summary>
        public string TargetName { get; set; }

        /// <summary>
        /// RequestModel
        /// </summary>
        public RequestModel()
        {
        }

        /// <summary>
        /// RequestModel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="summary"></param>
        /// <param name="document"></param>
        /// <param name="targetName"></param>
        /// <param name="type"></param>
        public RequestModel(string name, string summary, Type type, XmlDocument document, string targetName) : base(name, summary, type, document)
        {
            if (string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(targetName));
            }

            TargetName = targetName;
        }
    }
}