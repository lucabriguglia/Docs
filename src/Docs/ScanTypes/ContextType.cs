using System.Collections.Generic;

namespace Docs.ScanTypes
{
    public class ContextType
    {
        public string Name { get; }
        public IList<TargetType> Targets { get; } = new List<TargetType>();

        public ContextType(string name, TargetType target)
        {
            Name = name;
            Targets.Add(target);
        }
    }
}