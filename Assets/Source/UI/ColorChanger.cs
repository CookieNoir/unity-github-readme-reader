using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MaskableGraphic _maskableGraphic;
    [SerializeField] private Color[] _colors;
    [SerializeField] private int _defaultColorIndex;

    private void Awake()
    {
        SetColor(_defaultColorIndex);
    }

    public void SetColor(int value)
    {
        if (value < 0 || value >= _colors.Length) return;
        _maskableGraphic.color = _colors[value];
    }

    private void OnValidate()
    {
        if (_colors == null || _colors.Length == 0)
        {
            _defaultColorIndex = -1;
            return;
        }
        _defaultColorIndex = Math.Clamp(_defaultColorIndex, 0, _colors.Length - 1);
        if (_maskableGraphic) _maskableGraphic.color = _colors[_defaultColorIndex];
    }
}
