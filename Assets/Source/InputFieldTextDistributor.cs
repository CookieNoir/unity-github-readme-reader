using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InputFieldTextDistributor : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    public UnityEvent<string> OnValueReceived;

    public void Distribute()
    {
        OnValueReceived.Invoke(_inputField.text);
    }
}
