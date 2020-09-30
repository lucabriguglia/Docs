using Docs.Attributes;

namespace Docs.Tests
{
    /// <summary>
    /// Description of SampleTarget.
    /// </summary>
    [DocTarget("Sample Context")]
    public class SampleTarget
    {
        /// <summary>
        /// Description of Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of constructor.
        /// </summary>
        public SampleTarget()
        {
        }

        /// <summary>
        /// Description of constructor with parameter.
        /// </summary>
        public SampleTarget(string name)
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