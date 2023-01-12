using Octokit;
using System.Threading.Tasks;

public class UserReceiver : DataReceiver<User>
{
    private string _username;

    public void SetUsername(string value)
    {
        _username = value;
    }

    protected override async Task<User> Receive()
    {
        return await githubReader.GetUser(_username);
    }
}
