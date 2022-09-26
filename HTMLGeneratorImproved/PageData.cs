namespace HTMLGenerator
{
    public class PageData
    {

        public string Content { get; set; }

        private string name;
        private string path;   

        private HashSet<string> attributes;

        
        public void AddAttribute(string name)
        {
            attributes.Add(name);
        }

        public WikiPage GetWikiPage()
        {
            return new WikiPage(name, path);
        }

        public bool HasAttribute(string test)
        {
            return attributes.Contains(test);
        }

        public string GetHtml()
        {
            return Content;
        }

        public PageData(string name, string path, string content)
        {
            this.name = name;
            this.path = path;
            Content = content;
            this.attributes = new HashSet<string>();
        }

    }
}
