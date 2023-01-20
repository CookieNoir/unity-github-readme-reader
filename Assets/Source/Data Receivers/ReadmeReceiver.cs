using System;

public class ReadmeReceiver : DataReceiver<string, GithubReadme>
{
    protected override Action<string, Action<GithubReadme>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestRepositoryReadme;
    }
}
