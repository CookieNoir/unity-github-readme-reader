using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using UnityEngine;

public class GithubReader : MonoBehaviour
{
    [SerializeField] private string _productHeaderValue;
    private GitHubClient _client;

    private void Awake()
    {
        _client = new GitHubClient(new ProductHeaderValue(_productHeaderValue));
    }

    public async Task<IReadOnlyList<Repository>> GetRepositories(string username)
    {
        try
        {
            var repositoryList = await _client.Repository.GetAllForUser(username);
            return repositoryList;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
            return null;
        }
    }

    public async Task<User> GetUser(string username)
    {
        try
        {
            var user = await _client.User.Get(username);
            return user;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
            return null;
        }
    }

    public async Task<Readme> GetReadme(long repositoryId)
    {
        try
        {
            var readme = await _client.Repository.Content.GetReadme(repositoryId);
            return readme;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
            return null;
        }
    }
}
