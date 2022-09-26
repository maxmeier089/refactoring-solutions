namespace HTMLGenerator
{
    public class WikiPagePath
    {

        string path = "/<unknown-path>";


        public override string ToString()
        {
            return path;
        }

        public WikiPagePath(string path)
        {
            this.path = path;
        }

    }
}
