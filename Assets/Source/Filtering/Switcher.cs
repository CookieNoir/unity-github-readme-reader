using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

class Switcher : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private string[] _values;
    [SerializeField] private int _startValue;
    public UnityEvent<int> OnValueChanged;
    public int CurrentValue { get; private set; }

    private void Awake()
    {
        _SetValue(_startValue);
    }

    private void _SetValue(int value)
    {
        CurrentValue = value;
        _textField.text = _values[CurrentValue];
        OnValueChanged.Invoke(CurrentValue);
    }

    public void Next()
    {
        _SetValue((CurrentValue + 1) % _values.Length);
    }

    private void OnValidate()
    {
        if (_values == null || _values.Length == 0) 
        {
            _startValue = -1;
            return;
        }
        _startValue = Math.Clamp(_startValue, 0, _values.Length - 1);
        if (_textField) _textField.text = _values[_startValue];
    }
}
