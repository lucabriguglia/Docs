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
        /// <param name="name"></param>
        /// <param name="summary"></param>
        public RequestModel(string name, string summary)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(summary));
            }

            Name = name;
            Summary = summary;
        }
    }
}