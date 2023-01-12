using System;
using Octokit;
using UnityEngine;

public class RepositoryCard : MonoBehaviour
{
    [SerializeField] private RepositoryDrawer _repositoryDrawer;
    public Repository Repository { get; private set; }
    private Action<long> _openReadmeAction;

    public void SetData(Repository repository, Action<long> openReadmeAction)
    {
        Repository = repository;
        _openReadmeAction = openReadmeAction;
        _repositoryDrawer.Draw(repository);
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
