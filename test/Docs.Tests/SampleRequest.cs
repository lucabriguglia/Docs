using Docs.Attributes;

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

        /// <summary>
        /// Description of constructor.
        /// </summary>
        public SampleRequest()
        {
        }

        /// <summary>
        /// Description of constructor with parameter.
        /// </summary>
        public SampleRequest(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Description of UpdateName method.
        /// </summary>
        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}