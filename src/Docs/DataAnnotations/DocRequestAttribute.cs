using System;

namespace Docs.DataAnnotations
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DocRequestAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Target { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public DocRequestAttribute(Type target)
        {
            Target = target;
        }
    }
}