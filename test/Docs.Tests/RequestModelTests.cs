using System.Xml;
using Docs.Models;
using NUnit.Framework;

namespace Docs.Tests
{
    [TestFixture]
    public class RequestModelTests
    {
        [Test]
        public void Should_create_a_new_request_model()
        {
            const string name = "My Request";
            const string summary = "My Request Summary";
            const string targetName = "My Target";

            var document = new XmlDocument();
            document.Load("Docs.Tests.xml");

            var sut = new RequestModel(name, summary, typeof(SampleRequest), document, targetName);

            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(summary, sut.Summary);
            Assert.AreEqual(targetName, sut.TargetName);
            Assert.AreEqual("Name", sut.Properties[0].Name);
            Assert.AreEqual("New", sut.Methods[0].Name);
            Assert.AreEqual("New", sut.Methods[1].Name);
            Assert.AreEqual("UpdateName", sut.Methods[2].Name);
        }
    }
}