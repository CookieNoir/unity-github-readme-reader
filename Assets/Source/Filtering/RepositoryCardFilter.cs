using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class RepositoryCardFilter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private SortingTypeSelector _sortingType;
    [SerializeField] private SortingOrderSelector _sortingOrder;
    public UnityEvent OnFilteringCompleted;

    public void ApplyFilters(List<RepositoryCard> repositoryCards)
    {
        foreach (RepositoryCard repositoryCard in repositoryCards)
        {
            repositoryCard.gameObject.SetActive(false);
        }

        string pattern = _nameInputField.text.ToLower();
        var sortedCards = repositoryCards.Where(x => x.Repository.Name.ToLower().Contains(pattern));

        _sortingType.UpdateValue();
        sortedCards = sortedCards.OrderBy(x => _sortingType.Sort(x));

        _sortingOrder.UpdateValue();
        sortedCards = _sortingOrder.Order(sortedCards);

        foreach (var card in sortedCards)
        {
            card.gameObject.SetActive(true);
            card.transform.SetAsLastSibling();
        }
    }
}
