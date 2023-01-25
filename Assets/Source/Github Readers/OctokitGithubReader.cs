using System;
using System.Collections.Generic;
using Octokit;

public class OctokitGithubReader : IGithubReader
{
    private GitHubClient _client;

    public OctokitGithubReader(string productHeaderValue, string accessToken = null)
    {
        _client = new GitHubClient(new ProductHeaderValue(productHeaderValue));
        if (StringHelper.IsFilled(accessToken)) _client.Credentials = new Credentials(accessToken);
    }

    public async void RequestRepositoryReadme(string repositoryFullName, Action<GithubReadme> onSuccessAction, Action<string> onFailureAction = null)
    {
        try
        {
            int slash = repositoryFullName.IndexOf('/');
            string owner = repositoryFullName[0..slash];
            string repositoryName = repositoryFullName[(slash + 1)..(repositoryFullName.Length)];
            var readme = await _client.Repository.Content.GetReadme(owner, repositoryName);
            GithubReadme githubReadme = new GithubReadme(readme.HtmlUrl, readme.Content);
            onSuccessAction(githubReadme);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public async void RequestUserData(string username, Action<GithubUser> onSuccessAction, Action<string> onFailureAction = null)
    {
        try
        {
            var user = await _client.User.Get(username);
            GithubUser userData = new GithubUser(user.Id, user.AvatarUrl, user.Name, user.Login, user.Bio, user.Blog, user.Url, user.PublicRepos);
            onSuccessAction(userData);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public async void RequestUserRepositoriesData(GithubUser user, Action<IEnumerable<GithubRepository>> onSuccessAction, Action<string> onFailureAction = null)
    {
        try
        {
            var repositoryList = await _client.Repository.GetAllForUser(user.Login, new ApiOptions() { PageSize = user.PublicRepos });
            List<GithubRepository> resultRepositories = new List<GithubRepository>();
            foreach (var repository in repositoryList)
            {
                resultRepositories.Add(new GithubRepository(
                    repository.Id,
                    repository.Name,
                    repository.FullName,
                    repository.Description,
                    repository.DefaultBranch,
                    repository.License != null ? repository.License.Name : null,
                    repository.UpdatedAt.Date,
                    repository.Url,
                    repository.SvnUrl,
                    repository.Topics));
            }
            onSuccessAction(resultRepositories);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }
}
