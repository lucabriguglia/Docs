using System.Reflection;
using Docs.ScanTypes;

namespace Docs
{
    public interface IAssemblyScanner
    {
        ScanResult Scan(params Assembly[] assemblies);
    }
}
