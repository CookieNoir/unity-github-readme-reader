using UnityEngine;

public abstract class FilterSelector<T>: Filter<T>
{
    [SerializeField] private Switcher _switcher;
    protected int Value { get => _switcher.CurrentValue; }
}
