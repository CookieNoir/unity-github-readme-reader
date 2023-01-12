using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InputFieldDataTransmitter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    public UnityEvent<string> OnValuePassed;

    public void Pass()
    {
        OnValuePassed.Invoke(_inputField.text);
    }
}
