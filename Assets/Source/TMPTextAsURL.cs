using UnityEngine;
using TMPro;

public class TMPTextAsURL : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _prefix = "";
    [SerializeField] private string _suffix = "";

    public void OpenUrl()
    {
        UrlOpener.OpenURL(_prefix + _text.text + _suffix);
    }
}
