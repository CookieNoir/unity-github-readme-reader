using UnityEngine;
using UnityEngine.UI;

public class ManagedLayoutRebuilder : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    public void Rebuild()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
    }
}
