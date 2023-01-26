using UnityEngine;
using TMPro;

public class TextValueSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    public void Set(string value)
    {
        _textField.text = value;
    }
}
