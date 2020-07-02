using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Docs.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TargetModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<RequestModel> Requests => _requests.AsReadOnly();
        private readonly List<RequestModel> _requests = new List<RequestModel>();

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRequest(RequestModel request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (_requests.Single(x => x.Name == request.Name) == null)
            {
                _requests.Add(request);
            }
        }
    }
}
