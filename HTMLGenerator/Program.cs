using HTMLGenerator;

PageData pageData = new PageData(
             "TestPage",
             "/path/to/test/page",
             "<TestPageContent></TestPageContent>");

pageData.AddAttribute("Test");

try
{
    string html = MakeHTML.TestableHtml(pageData, true);
    Console.WriteLine(html);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}