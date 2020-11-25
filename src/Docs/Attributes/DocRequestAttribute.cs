using System;
#pragma warning disable 1591

namespace Docs.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DocRequestAttribute : Attribute
    {
        public Type Target { get; }

        public DocRequestAttribute(Type target)
        {
            Target = target;
        }
    }
}