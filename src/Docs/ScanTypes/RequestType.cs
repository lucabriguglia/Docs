using System;

namespace Docs.ScanTypes
{
    public class RequestType
    {
        public string Assembly { get; }
        public Type Type { get; }

        public RequestType(string assembly, Type type)
        {
            Assembly = assembly;
            Type = type;
        }
    }
}