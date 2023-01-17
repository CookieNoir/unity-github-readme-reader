using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class NameFilter : Filter<RepositoryCard>
{
    [SerializeField] private TMP_InputField _nameInputField;

    public override IEnumerable<RepositoryCard> ApplyFilter(IEnumerable<RepositoryCard> collection)
    {
        string pattern = _nameInputField.text.ToLower();
        return collection.Where(x => x.Repository.Name.ToLower().Contains(pattern));
    }
}
