using System;
using System.Collections.Generic;
using System.Linq;

namespace Docs.Models
{
    /// <summary>
    /// ContextModel
    /// </summary>
    public class ContextModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Targets
        /// </summary>
        public List<TargetModel> Targets { get; set; } = new List<TargetModel>();

        /// <summary>
        /// ContextModel
        /// </summary>
        public ContextModel()
        {
            
        }

        /// <summary>
        /// ContextModel
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContextModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// AddTarget
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddTarget(TargetModel target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (Targets.FirstOrDefault(x => x.Name == target.Name) == null)
            {
                Targets.Add(target);
            }
        }

        /// <summary>
        /// AddRequest
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddRequest(RequestModel request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var target = Targets.FirstOrDefault(x => x.Name == request.TargetName);

            if (target == null)
            {
                throw new ArgumentException(nameof(request));
            }

            target.AddRequest(request);
        }
    }
}