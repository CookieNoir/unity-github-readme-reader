using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepositoryCardFilter : MonoBehaviour
{
    [SerializeField] private Filter<RepositoryCard>[] _filters;
    public UnityEvent OnFilteringCompleted;

    public void ApplyFilters(List<RepositoryCard> repositoryCards)
    {
        foreach (RepositoryCard repositoryCard in repositoryCards)
        {
            repositoryCard.gameObject.SetActive(false);
        }

        IEnumerable<RepositoryCard> filteredCards = repositoryCards;
        foreach (var filter in _filters)
        {
            filteredCards = filter.ApplyFilter(filteredCards);
        }

        foreach (var card in filteredCards)
        {
            card.gameObject.SetActive(true);
            card.transform.SetAsLastSibling();
        }

        OnFilteringCompleted.Invoke();
    }
}
