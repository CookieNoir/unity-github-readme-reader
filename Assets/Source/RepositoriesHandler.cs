using System.Collections.Generic;
using UnityEngine;

public class RepositoriesHandler : MonoBehaviour
{
    [SerializeField] private GameObject _repositoryCardPrefab;
    [SerializeField] private Transform _prefabParent;
    [SerializeField] private ManagedLayoutRebuilder _layoutRebuilder;
    [SerializeField] private RepositoryCardFilter _repositoryCardFilter;
    private List<RepositoryCard> _repositoryCards = new List<RepositoryCard>();

    public void CreateCards(IEnumerable<RepositoryData> repositories)
    {
        _Clear();
        foreach (RepositoryData repository in repositories)
        {
            GameObject newGameObject = Instantiate(_repositoryCardPrefab, _prefabParent);
            newGameObject.name = repository.Name;
            RepositoryCard repositoryCard = newGameObject.GetComponent<RepositoryCard>();
            _repositoryCards.Add(repositoryCard);
            repositoryCard.SetData(repository, ApplyFilters);
        }
    }

    public void ApplyFilters()
    {
        _repositoryCardFilter?.ApplyFilters(_repositoryCards);
        _layoutRebuilder.Rebuild();
    }

    private void _Clear()
    {
        _repositoryCards.Clear();
        foreach (Transform child in _prefabParent) Destroy(child.gameObject);
    }
}
