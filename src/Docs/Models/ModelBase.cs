using System;
using Docs.Extensions;

namespace Docs.Models
{
    /// <summary>
    /// ModelBase
    /// </summary>
    public abstract class ModelBase
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
        /// 
        /// </summary>
        protected ModelBase()
        {
        }

        /// <summary>
        /// ModelBase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="summary"></param>
        /// <exception cref="ArgumentException"></exception>
        protected ModelBase(string name, string summary)
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