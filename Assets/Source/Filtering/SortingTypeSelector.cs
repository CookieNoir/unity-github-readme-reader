using UnityEngine;

public class SortingTypeSelector : MonoBehaviour
{
    [SerializeField] private Switcher _switcher;
    private int _sortingType;

    public void UpdateValue()
    {
        _sortingType = _switcher.CurrentValue;
    }

    public object Sort(RepositoryCard repositoryCard)
    {
        switch (_sortingType)
        {
            case 0:
                {
                    return repositoryCard.Repository.Name;
                }
            case 1:
                {
                    return repositoryCard.Repository.UpdatedAt;
                }
            default:
                {
                    return null;
                }
        }
    }
}
