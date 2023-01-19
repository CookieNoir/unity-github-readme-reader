using System;
using UnityEngine;

public class RepositoryCard : MonoBehaviour
{
    [SerializeField] private RepositoryDataDrawer _repositoryDrawer;
    public RepositoryData Repository { get; private set; }
    public bool HasReadme { get; private set; }
    private string _readmeUrl;

    public async void SetData(RepositoryData repository, Action onDataSet)
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
