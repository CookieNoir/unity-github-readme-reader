using System.Collections.Generic;
using Octokit;
using UnityEngine;

public class RepositoriesHandler : MonoBehaviour
{
    [SerializeField] private GameObject _repositoryCardPrefab;
    [SerializeField] private Transform _prefabParent;
    [SerializeField] private ReadmeReceiver _readmeReceiver;
    [SerializeField] private ManagedLayoutRebuilder _layoutRebuilder;

    public void CreateCards(IEnumerable<Repository> repositories)
    {
        _Clear();
        foreach (Repository repository in repositories)
        {
            GameObject newGameObject = Instantiate(_repositoryCardPrefab, _prefabParent);
            newGameObject.name = repository.Name;
            RepositoryCard repositoryCard = newGameObject.GetComponent<RepositoryCard>();
            repositoryCard.SetData(repository, _readmeReceiver.SetRepositoryIdAndReceive);
        }
        _layoutRebuilder.Rebuild();
    }

    private void _Clear()
    {
        foreach (Transform child in _prefabParent) Destroy(child.gameObject);
    }
}
