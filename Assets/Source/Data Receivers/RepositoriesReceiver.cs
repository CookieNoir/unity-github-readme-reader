using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

public class RepositoriesReceiver : DataReceiver<IEnumerable<Repository>>
{
    private string _username;

    public void SetUsername(string value)
    {
        _username = value;
    }

    protected override async Task<IEnumerable<Repository>> Receive()
    {
        return await githubReader.GetRepositories(_username);
    }
}
