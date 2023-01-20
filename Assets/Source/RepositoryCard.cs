using System;
using UnityEngine;

public class RepositoryCard : MonoBehaviour
{
    [SerializeField] private RepositoryDataDrawer _repositoryDrawer;
    public GithubRepository Repository { get; private set; }
    public GithubReadme GithubReadme { get; private set; }
    public bool HasReadme { get; private set; }
    private Action _onDataSet;

    public void SetData(GithubRepository repository, ReadmeReceiver readmeReceiver, Action onDataSet)
    {
        _repositoryDrawer.Hide();
        Repository = repository;
        _onDataSet = onDataSet;
        readmeReceiver.RequestAndSendData(Repository.FullName, _OnReadmeReceived, _OnReadmeNotReceived);
    }

    private void _OnReadmeReceived(GithubReadme readme)
    {
        GithubReadme = readme;
        HasReadme = GithubReadme != null;
        _DrawData();
    }

    private void _OnReadmeNotReceived(string message)
    {
        HasReadme = false;
        _DrawData();
    }

    private void _DrawData()
    {
        _repositoryDrawer.Draw(Repository, HasReadme);
        _onDataSet();
    }

    public void OpenReadme()
    {
        if (HasReadme) UrlOpener.OpenURL(GithubReadme.HtmlUrl);
    }

    public void OpenSvnUrl()
    {
        UrlOpener.OpenURL(Repository.SvnUrl);
    }
}
