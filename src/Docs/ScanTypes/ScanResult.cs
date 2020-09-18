using System.Collections.Generic;
using System.Xml;

namespace Docs.ScanTypes
{
    public class ScanResult
    {
        public Dictionary<string, XmlDocument> Documents { get; set; }
        public IEnumerable<ContextType> Contexts { get; set; }
        public IEnumerable<RequestType> Requests { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}