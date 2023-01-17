using System.Collections.Generic;
using UnityEngine;

public abstract class Filter<T> : MonoBehaviour
{
    public abstract IEnumerable<T> ApplyFilter(IEnumerable<T> collection);
}
