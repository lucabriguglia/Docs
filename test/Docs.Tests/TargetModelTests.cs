using System.Xml;
using Docs.Models;
using NUnit.Framework;

namespace Docs.Tests
{
    public class TargetModelTests
    {
        [Test]
        public void Should_create_a_new_target_model()
        {
            const string name = "My Target";
            const string summary = "My Target Summary";

            var document = new XmlDocument();
            document.Load("Docs.Tests.xml");

            var sut = new TargetModel(name, summary, typeof(SampleTarget), document);

            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(summary, sut.Summary);
            Assert.AreEqual("Name", sut.Properties[0].Name);
            Assert.AreEqual("New", sut.Methods[0].Name);
            Assert.AreEqual("New", sut.Methods[1].Name);
            Assert.AreEqual("UpdateName", sut.Methods[2].Name);
        }

        [Test]
        public void Should_add_a_request_model()
        {
            var document = new XmlDocument();
            document.Load("Docs.Tests.xml");

            var sut = new TargetModel("My Target", "My Target Summary", typeof(SampleTarget), document);

            var request = new RequestModel("My Request", "My Request Summary", typeof(SampleRequest), document, "My Target");

            sut.AddRequest(request);

            Assert.AreEqual(request, sut.Requests[0]);
        }
    }
}