using System;
using System.Collections.Generic;

public class RepositoriesReceiver : DataReceiver<string, IEnumerable<RepositoryData>>
{
    protected override Action<string, Action<IEnumerable<RepositoryData>>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestUserRepositoriesData;
    }
}
