using System;

public class ReadmeReceiver : DataReceiver<long, string>
{
    protected override Action<long, Action<string>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestRepositoryReadme;
    }
}
