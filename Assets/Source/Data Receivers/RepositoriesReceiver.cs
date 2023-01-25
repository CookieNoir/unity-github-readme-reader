using System;
using System.Collections.Generic;

public class RepositoriesReceiver : DataReceiver<GithubUser, IEnumerable<GithubRepository>>
{
    protected override Action<GithubUser, Action<IEnumerable<GithubRepository>>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestUserRepositoriesData;
    }
}
