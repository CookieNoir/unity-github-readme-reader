using UnityEngine;
using TMPro;

public class TMPTextAsURL : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void OpenUrl()
    {
        UrlOpener.OpenURL(_text.text);
    }
}
