using System;

namespace Docs.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DocTargetAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Context { get; }

        /// <summary>
        /// 
        /// </summary>
        public DocTargetAttribute()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DocTargetAttribute(string context)
        {
            Context = context;
        }
    }
}