using Docs.DataAnnotations;

namespace Docs.Tests
{
    /// <summary>
    /// Description of SampleRequest.
    /// </summary>
    [DocRequest(typeof(SampleTarget))]
    public class SampleRequest
    {
        /// <summary>
        /// Description of Name.
        /// </summary>
        public string Name { get; set; }
    }
}