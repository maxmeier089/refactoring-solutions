using System.Text;

namespace HTMLGenerator
{
    public class MakeHTML
    {

        class SetupTeardownSurrounder
        {

            PageData pageData;
            bool includeSuiteSetup;
            WikiPage wikiPage;
            StringBuilder buffer;
            PageCrawlerImpl pageCrawler;

            
            internal string Invoke()
            {
                IncludeSetup();

                IncludeContent();

                IncludeTeardown();

                return GetPageHTML();
            }


            private void IncludeSetup()
            {
                if (IsTestPage())
                {
                    IncludeSuiteSetup("setup", SuiteResponder.SUITE_SETUP_NAME);

                    IncludePage("setup", "SetUp");
                }
            }

            private void IncludeContent()
            {
                buffer.Append(pageData.Content);
            }

            private void IncludeTeardown()
            {
                if (IsTestPage())
                {
                    IncludePage("teardown", "TearDown");

                    IncludeSuiteSetup("teardown", SuiteResponder.SUITE_TEARDOWN_NAME);
                }
            }

            private string GetPageHTML()
            {
                pageData.Content = buffer.ToString();
                return pageData.GetHtml();
            }

            private bool IsTestPage()
            {
                return pageData.HasAttribute("Test");
            }

            private void IncludeSuiteSetup(string mode, string pageName)
            {
                if (includeSuiteSetup)
                {
                    IncludePage(mode, pageName);
                }
            }

            private void IncludePage(string mode, string pageName)
            {
                WikiPage inheritedPage = PageCrawlerImpl.GetInheritedPage(pageName, wikiPage);

                if (inheritedPage != null)
                {
                    WikiPagePath pagePath = pageCrawler.GetFullPath(inheritedPage);
                    string pagePathName = PathParser.Render(pagePath);
                    buffer.Append(string.Format("!include -{0} . {1}\n", mode, pagePathName));
                }
            }

            public SetupTeardownSurrounder(PageData pageData, bool includeSuiteSetup)
            {
                this.pageData = pageData;
                this.includeSuiteSetup = includeSuiteSetup;
                wikiPage = pageData.GetWikiPage();
                buffer = new StringBuilder();
                pageCrawler = wikiPage.GetPageCrawler();
            }
        }

        public static string TestableHtml(PageData pageData, bool includeSuiteSetup)
        {
            return new SetupTeardownSurrounder(pageData, includeSuiteSetup).Invoke();
        }

    }
}
