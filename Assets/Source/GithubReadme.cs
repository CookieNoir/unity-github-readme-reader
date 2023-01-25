public class GithubReadme
{
    public GithubReadme(string htmlUrl, string content)
    {
        HtmlUrl = htmlUrl;
        Content = content;
    }

    public string HtmlUrl { get; private set; }
    public string Content { get; private set; }
}
