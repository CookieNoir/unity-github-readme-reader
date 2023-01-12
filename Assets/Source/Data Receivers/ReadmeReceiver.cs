using Octokit;
using System.Threading.Tasks;

public class ReadmeReceiver : DataReceiver<Readme>
{
    private long _repositoryId;

    public void SetRepositoryIdAndReceive(long repositoryId)
    {
        _repositoryId = repositoryId;
        ReceiveAndTransfer();
    }

    protected override async Task<Readme> Receive()
    {
        return await githubReader.GetReadme(_repositoryId);
    }
}
