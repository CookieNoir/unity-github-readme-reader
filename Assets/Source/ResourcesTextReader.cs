using UnityEngine;

public class ResourcesTextReader: MonoBehaviour
{
    [SerializeField] private string _dataPath;

    public string ReadText()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(_dataPath);
        return textAsset.text;
    }
}
