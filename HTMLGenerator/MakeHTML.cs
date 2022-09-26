using System.Text;

namespace HTMLGenerator
{
    public class MakeHTML
    {

        public static string TestableHtml(PageData pageData, bool includeSuiteSetup)
        {
            WikiPage wikiPage = pageData.GetWikiPage();
            StringBuilder buffer = new StringBuilder();

            if (pageData.HasAttribute("Test"))
            {
                if (includeSuiteSetup)
                {
                    WikiPage suiteSetup = PageCrawlerImpl.GetInheritedPage(SuiteResponder.SUITE_SETUP_NAME, wikiPage);
                    if (suiteSetup != null)
                    {
                        WikiPagePath pagePath = wikiPage.GetPageCrawler().GetFullPath(suiteSetup);
                        string pagePathName = PathParser.Render(pagePath);
                        buffer.Append("!include -setup . ").Append(pagePathName).Append("\n");
                    }
                }

                WikiPage setup = PageCrawlerImpl.GetInheritedPage("SetUp", wikiPage);

                if (setup != null)
                {
                    WikiPagePath setupPath = wikiPage.GetPageCrawler().GetFullPath(setup);
                    string setupPathName = PathParser.Render(setupPath);
                    buffer.Append("!include -setup . ").Append(setupPathName).Append("\n");
                }
            }

            buffer.Append(pageData.Content);

            if (pageData.HasAttribute("Test"))
            {
                WikiPage teardown = PageCrawlerImpl.GetInheritedPage("TearDown", wikiPage);
                if (teardown != null)
                {
                    WikiPagePath tearDownPath = wikiPage.GetPageCrawler().GetFullPath(teardown);
                    String tearDownPathName = PathParser.Render(tearDownPath);
                    buffer.Append("!include -teardown . ").Append(tearDownPathName).Append("\n");
                }

                if (includeSuiteSetup)
                {
                    WikiPage suiteTeardown = PageCrawlerImpl.GetInheritedPage(SuiteResponder.SUITE_TEARDOWN_NAME, wikiPage);

                    if (suiteTeardown != null)
                    {
                        WikiPagePath pagePath = wikiPage.GetPageCrawler().GetFullPath(suiteTeardown);
                        String pagePathName = PathParser.Render(pagePath);
                        buffer.Append("!include -teardown . ").Append(pagePathName).Append("\n");
                    }
                }
            }

            pageData.Content = buffer.ToString();
            return pageData.GetHtml();
        }

    }
}
