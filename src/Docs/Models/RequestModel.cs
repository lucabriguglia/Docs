using System;
using Docs.Extensions;

namespace Docs.Models
{
    /// <summary>
    /// RequestModel
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// NormalizedName
        /// </summary>
        public string NormalizedName => Name.InsertSpaceBeforeUpperCase();

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }

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
        /// <param name="targetName"></param>
        public RequestModel(string name, string summary, string targetName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(summary));
            }

            if (string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(targetName));
            }

            Name = name;
            Summary = summary;
            TargetName = targetName;
        }
    }
}