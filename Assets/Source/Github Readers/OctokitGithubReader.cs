using System;
using System.Collections.Generic;
using Octokit;

public class OctokitGithubReader : IGithubReader
{
    private GitHubClient _client;

    public OctokitGithubReader(string productHeaderValue)
    {
        _client = new GitHubClient(new ProductHeaderValue(productHeaderValue));
    }

    public async void RequestRepositoryReadme(long repositoryId, Action<string> onSuccessAction, Action<string> onFailureAction = null)
    {
        try
        {
            var readme = await _client.Repository.Content.GetReadme(repositoryId);
            onSuccessAction(readme.Content);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public async void RequestUserData(string username, Action<UserData> onSuccessAction = null, Action<string> onFailureAction = null)
    {
        try
        {
            var user = await _client.User.Get(username);
            UserData userData = new UserData(user.Id, user.AvatarUrl, user.Name, user.Login, user.Bio, user.Blog, user.Url);
            onSuccessAction(userData);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public async void RequestUserRepositoriesData(string username, Action<IEnumerable<RepositoryData>> onSuccessAction, Action<string> onFailureAction = null)
    {
        try
        {
            var repositoryList = await _client.Repository.GetAllForUser(username);
            List<RepositoryData> resultRepositories = new List<RepositoryData>();
            foreach (var repository in repositoryList)
            {
                resultRepositories.Add(new RepositoryData(
                    repository.Id,
                    repository.Name,
                    repository.FullName,
                    repository.Description,
                    repository.DefaultBranch,
                    repository.License != null ? repository.License.Name : null,
                    repository.UpdatedAt.Date,
                    repository.SvnUrl));
            }
            onSuccessAction(resultRepositories);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }
}
