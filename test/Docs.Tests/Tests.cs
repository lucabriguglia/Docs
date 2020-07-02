using System.Reflection;
using NUnit.Framework;

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
            assembleScanner.Scan(assembly);
        }
    }
}
