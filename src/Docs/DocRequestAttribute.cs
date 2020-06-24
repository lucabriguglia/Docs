using System;

namespace Docs
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