using Docs.Models;
using Docs.ScanTypes;

namespace Docs
{
    /// <summary>
    /// IConverter
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="scanResult"></param>
        DocumentationModel Convert(ScanResult scanResult);
    }
}