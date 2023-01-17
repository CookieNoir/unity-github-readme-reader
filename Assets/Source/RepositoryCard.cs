using System;
using Octokit;
using UnityEngine;

public class RepositoryCard : MonoBehaviour
{
    [SerializeField] private RepositoryDrawer _repositoryDrawer;
    public Repository Repository { get; private set; }
    public bool HasReadme { get; private set; }
    private string _readmeUrl;

    public async void SetData(Repository repository, Action onDataSet)
    {
        _repositoryDrawer.Hide();
        Repository = repository;
        string url = $"https://github.com/{Repository.FullName}/blob/{Repository.DefaultBranch}/README.md";
        HasReadme = await UrlChecker.ExistsAsync(url);
        _repositoryDrawer.Draw(repository, HasReadme);
        if (HasReadme) _readmeUrl = url;
        onDataSet();
    }

    public void OpenReadme()
    {
        UrlOpener.OpenURL(_readmeUrl);
    }

    public void OpenSvnUrl()
    {
        UrlOpener.OpenURL(Repository.SvnUrl);
    }
}
