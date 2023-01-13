using System;
using Octokit;
using UnityEngine;

public class RepositoryCard : MonoBehaviour
{
    [SerializeField] private RepositoryDrawer _repositoryDrawer;
    public Repository Repository { get; private set; }
    public bool HasReadme { get; private set; }
    private Action<long> _openReadmeAction;

    public async void SetData(Repository repository, Action<long> openReadmeAction, Action onDataSet)
    {
        _repositoryDrawer.Hide();
        Repository = repository;
        HasReadme = await ReadmeChecker.ExistsAsync(Repository.FullName, Repository.DefaultBranch);
        _openReadmeAction = openReadmeAction;
        _repositoryDrawer.Draw(repository, HasReadme);
        onDataSet();
    }

    public void OpenReadme()
    {
        _openReadmeAction(Repository.Id);
    }

    public void OpenSvnUrl()
    {
        UrlOpener.OpenURL(Repository.SvnUrl);
    }
}
