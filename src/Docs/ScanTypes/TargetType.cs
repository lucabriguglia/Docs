using System;

namespace Docs.ScanTypes
{
    public class TargetType
    {
        public string Assembly { get; }
        public Type Type { get; }

        public TargetType(string assembly, Type type)
        {
            Assembly = assembly;
            Type = type;
        }
    }
}