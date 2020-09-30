using System.Linq;
using System.Reflection;
using NUnit.Framework;

#pragma warning disable 1591

namespace Docs.Tests
{
    [TestFixture]
    public class AssemblyScannerTests
    {
        [Test]
        public void Should_scan_the_given_assembly()
        {
            var sut = new AssemblyScanner();
            var assembly = Assembly.GetExecutingAssembly();
            var actual = sut.Scan(assembly);

            Assert.NotNull(actual);
            Assert.AreEqual("Sample Context", actual.Contexts.FirstOrDefault().Name);
            Assert.AreEqual(typeof(SampleTarget), actual.Contexts.FirstOrDefault().Targets.FirstOrDefault().Type);
            Assert.AreEqual(typeof(SampleRequest), actual.Requests.FirstOrDefault().Type);
        }
    }
}
