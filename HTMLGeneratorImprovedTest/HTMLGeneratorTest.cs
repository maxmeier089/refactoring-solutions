using HTMLGenerator;

namespace HTMLGeneratorImprovedTest
{
    internal class HTMLGeneratorTest
    {

        PageData pageData;

        [SetUp]
        public void Init()
        {
            pageData = new PageData(
                    "TestPage",
                    "/path/to/test/page",
                    "<TestPageContent></TestPageContent>");

            pageData.AddAttribute("Test");
        }


        [Test]
        public void TestableHtmlTrue()
        {
            string actual = MakeHTML.TestableHtml(pageData, true);

            string expected = "!include -setup . <Rendered><FullPath>/path/to/test/page/Suite Steup Name</FullPath></Rendered>\n" +
                    "!include -setup . <Rendered><FullPath>/path/to/test/page/SetUp</FullPath></Rendered>\n" +
                    "<TestPageContent></TestPageContent>!include -teardown . <Rendered><FullPath>/path/to/test/page/TearDown</FullPath></Rendered>\n" +
                    "!include -teardown . <Rendered><FullPath>/path/to/test/page/Suite Teardown Name</FullPath></Rendered>\n";

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void TestableHtmlFalse()
        {
            string actual = MakeHTML.TestableHtml(pageData, false);

            string expected = "!include -setup . <Rendered><FullPath>/path/to/test/page/SetUp</FullPath></Rendered>\n" +
                    "<TestPageContent></TestPageContent>!include -teardown . <Rendered><FullPath>/path/to/test/page/TearDown</FullPath></Rendered>\n";

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
