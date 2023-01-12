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
        if (_defaultColorIndex < 0) _defaultColorIndex = 0;
        if (_defaultColorIndex >= _colors.Length) _defaultColorIndex = _colors.Length - 1;
    }
}
