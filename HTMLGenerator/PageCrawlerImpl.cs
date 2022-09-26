namespace HTMLGenerator
{
    public class PageCrawlerImpl
    {

        string path = "";


        public static WikiPage GetInheritedPage(String name, WikiPage wikiPage)
        {
            return new WikiPage("subpage " + name + " of " + wikiPage.ToString(), wikiPage.Path + "/" + name);
        }

        public WikiPagePath GetFullPath(WikiPage suiteSetup)
        {
            return new WikiPagePath("<FullPath>" + suiteSetup.Path + "</FullPath>");
        }


        public PageCrawlerImpl(string path)
        {
            this.path = "<PageCrawlerImpl>" + path + "</PageCrawlerImpl>";
        }

    }
}
