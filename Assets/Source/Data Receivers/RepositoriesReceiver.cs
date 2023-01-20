using System;
using System.Collections.Generic;

public class RepositoriesReceiver : DataReceiver<string, IEnumerable<GithubRepository>>
{
    protected override Action<string, Action<IEnumerable<GithubRepository>>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestUserRepositoriesData;
    }
}
