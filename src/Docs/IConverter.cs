using Docs.Models;
using Docs.ScanTypes;

namespace Docs
{
    public interface IConverter
    {
        DocumentationModel Convert(ScanResult scanResult);
    }
}