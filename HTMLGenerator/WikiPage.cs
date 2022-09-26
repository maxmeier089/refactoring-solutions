namespace HTMLGenerator
{
    public class WikiPage
    {

        public string Name { get; private set; }

        public string Path { get; private set; }

        
        public PageCrawlerImpl GetPageCrawler()
        {
            return new PageCrawlerImpl("<Crawler>" + Path + "</Crawler>");
        }

        public string GetPath()
        {
            return "<PageCrawlerImpl>" + Path + "</PageCrawlerImpl>";
        }


        public WikiPage(string name, string path)
        {
            Name = name;
            Path = path;
        }

    }
}
