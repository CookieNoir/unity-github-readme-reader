using UnityEngine;

public class LogViewer : MonoBehaviour
{
    public void ShowWarning(string log)
    {
        Debug.LogWarning(log);
    }
}
