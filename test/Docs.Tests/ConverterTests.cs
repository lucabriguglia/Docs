using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Docs.ScanTypes;
using NUnit.Framework;

namespace Docs.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void Should_convert_scan_types_to_models()
        {
            var sut = new Converter();

            var document = new XmlDocument();
            document.Load("Docs.Tests.xml");

            var actual = sut.Convert(new ScanResult
            {
                Documents = new Dictionary<string, XmlDocument>
                {
                    {Assembly.GetExecutingAssembly().FullName, document }
                },
                Contexts = new List<ContextType>
                {
                    new ContextType("Sample Context", new TargetType(Assembly.GetExecutingAssembly().FullName, typeof(SampleTarget)))
                },
                Requests = new List<RequestType>
                {
                    new RequestType(Assembly.GetExecutingAssembly().FullName, typeof(SampleRequest))
                }
            });

            Assert.NotNull(actual);
            Assert.AreEqual("Sample Context", actual.Contexts[0].Name);
            Assert.AreEqual("SampleTarget", actual.Contexts[0].Targets[0].Name);
            Assert.AreEqual("SampleRequest", actual.Contexts[0].Targets[0].Requests[0].Name);
        }
    }
}