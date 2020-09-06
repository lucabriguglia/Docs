using System;
using System.Collections.Generic;
using System.Linq;
using Docs.Extensions;

namespace Docs.Models
{
    /// <summary>
    /// TargetModel
    /// </summary>
    public class TargetModel
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
        /// Requests
        /// </summary>
        public List<RequestModel> Requests { get; set; } = new List<RequestModel>();

        /// <summary>
        /// TargetModel
        /// </summary>
        public TargetModel()
        {
            
        }

        /// <summary>
        /// TargetModel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="summary"></param>
        /// <exception cref="ArgumentException"></exception>
        public TargetModel(string name, string summary)
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

        /// <summary>
        /// AddRequest
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRequest(RequestModel request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (Requests.FirstOrDefault(x => x.Name == request.Name) == null)
            {
                Requests.Add(request);
            }
        }
    }
}
