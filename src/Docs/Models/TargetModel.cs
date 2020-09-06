using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Docs.Models
{
    /// <summary>
    /// TargetModel
    /// </summary>
    public class TargetModel : MemberModelBase
    {
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
        /// <param name="type"></param>
        /// <param name="document"></param>
        /// <exception cref="ArgumentException"></exception>
        public TargetModel(string name, string summary, Type type, XmlDocument document) : base(name, summary, type, document)
        {
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
