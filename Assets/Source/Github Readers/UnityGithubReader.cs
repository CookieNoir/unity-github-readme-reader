using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using UnityEngine;

public class UnityGithubReader : IGithubReader
{
    private JSONReceiver _jsonReceiver;

    public UnityGithubReader(JSONReceiver jsonReceiver)
    {
        string userAgentValue = $"{Application.productName}/{Application.version}";
        _jsonReceiver = jsonReceiver;
        _jsonReceiver.Set(userAgentValue);
    }

    public void RequestUserData(string username, Action<GithubUser> onSuccessAction, Action<string> onFailureAction = null)
    {
        string url = $"https://api.github.com/users/{username}";
        _jsonReceiver.TryToGetJson(url, _OnUserDataReceived, onSuccessAction, onFailureAction);
    }

    private void _OnUserDataReceived(string json, Action<GithubUser> onSuccessAction, Action<string> onFailureAction)
    {
        try
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement root = jsonDocument.RootElement;
            int id = root.GetProperty("id").GetInt32();
            string avatarUrl = root.GetProperty("avatar_url").ToString();
            string name = root.GetProperty("name").ToString();
            string login = root.GetProperty("login").ToString();
            string bio = root.GetProperty("bio").ToString();
            string blog = root.GetProperty("blog").ToString();
            string url = root.GetProperty("url").ToString();

            GithubUser userData = new GithubUser(id, avatarUrl, name, login, bio, blog, url);
            onSuccessAction(userData);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public void RequestUserRepositoriesData(string username, Action<IEnumerable<GithubRepository>> onSuccessAction, Action<string> onFailureAction = null)
    {
        string url = $"https://api.github.com/users/{username}/repos";
        _jsonReceiver.TryToGetJson(url, _OnRepositoryDataReceived, onSuccessAction, onFailureAction);
    }

    private void _OnRepositoryDataReceived(string json, Action<IEnumerable<GithubRepository>> onSuccessAction, Action<string> onFailureAction)
    {
        try
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            List<GithubRepository> repositories = new List<GithubRepository>();
            JsonElement root = jsonDocument.RootElement;
            foreach (JsonElement element in root.EnumerateArray())
            {
                long id = element.GetProperty("id").GetInt64();
                string name = element.GetProperty("name").ToString();
                string fullName = element.GetProperty("full_name").ToString();

                JsonElement descriptionElement = element.GetProperty("description");
                string description = descriptionElement.ValueKind != JsonValueKind.Null ? descriptionElement.ToString() : null;

                string defaultBranch = element.GetProperty("default_branch").ToString();

                JsonElement licenseElement = element.GetProperty("license");
                string licenseName = licenseElement.ValueKind != JsonValueKind.Null ? licenseElement.GetProperty("name").ToString() : null;

                DateTime updatedAt = element.GetProperty("updated_at").GetDateTime();
                string url = element.GetProperty("url").ToString();
                string svnUrl = element.GetProperty("svn_url").ToString();
                GithubRepository repositoryData = new GithubRepository(id, name, fullName, description, defaultBranch, licenseName, updatedAt, url, svnUrl);
                repositories.Add(repositoryData);
            }
            onSuccessAction(repositories);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }

    public void RequestRepositoryReadme(string repositoryFullName, Action<GithubReadme> onSuccessAction, Action<string> onFailureAction = null)
    {
        string url = $"https://api.github.com/repos/{repositoryFullName}/readme";
        _jsonReceiver.TryToGetJson(url, _OnReadmeDataReceived, onSuccessAction, onFailureAction);
    }

    private void _OnReadmeDataReceived(string json, Action<GithubReadme> onSuccessAction, Action<string> onFailureAction)
    {
        GithubReadme result = null;
        try
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement root = jsonDocument.RootElement;
            if (root.TryGetProperty("html_url", out JsonElement htmlUrlElement))
            {
                string htmlUrl = htmlUrlElement.ToString();
                byte[] contentBytes = Convert.FromBase64String(root.GetProperty("content").ToString());
                string content = Encoding.UTF8.GetString(contentBytes);
                result = new GithubReadme(htmlUrl, content);
            }
            onSuccessAction(result);
        }
        catch (Exception ex)
        {
            onFailureAction(ex.Message);
        }
    }
}
