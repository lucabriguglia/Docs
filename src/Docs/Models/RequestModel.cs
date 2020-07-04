using System;

namespace Docs.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get;}

        /// <summary>
        /// 
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// 
        /// </summary>
        public string TargetName { get; }

        /// <summary>
        /// 
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