using System.Reflection;
using NUnit.Framework;
#pragma warning disable 1591

namespace Docs.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var assembleScanner = new AssemblyScanner();
            var assembly = Assembly.GetExecutingAssembly();
            var actual = assembleScanner.Scan(new []{assembly});
            Assert.AreEqual(1, actual.Count);
        }
    }
}
