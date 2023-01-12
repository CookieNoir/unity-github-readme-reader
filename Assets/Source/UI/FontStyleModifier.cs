using UnityEngine;
using TMPro;

public class FontStyleModifier : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private FontStyles _style;

    public void AddStyle()
    {
        _text.fontStyle |= _style;
    }

    public void RemoveStyle()
    {
        _text.fontStyle ^= _style;
    }
}
