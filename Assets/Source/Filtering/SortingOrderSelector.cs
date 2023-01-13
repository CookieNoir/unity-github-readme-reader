using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortingOrderSelector : MonoBehaviour
{
    [SerializeField] private Switcher _switcher;
    private bool _acsending;

    public void UpdateValue()
    {
        _acsending = _switcher.CurrentValue > 0;
    }

    public IEnumerable<T> Order<T>(IEnumerable<T> collection)
    {
        if (_acsending) return collection;
        else return collection.Reverse();
    }
}
