using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JSONReceiver : MonoBehaviour
{
    private string _userAgentValue;

    public void Set(string userAgentValue)
    {
        _userAgentValue = userAgentValue;
    }

    public void TryToGetJson<T>(string url, Action<string, Action<T>, Action<string>> onDataReceived, Action<T> onSuccessAction, Action<string> onFailureAction)
    {
        StartCoroutine(_GetJSON(url, onDataReceived, onSuccessAction, onFailureAction));
    }

    private IEnumerator _GetJSON<T>(string url, Action<string, Action<T>, Action<string>> onDataReceived, Action<T> onSuccessAction, Action<string> onFailureAction)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("User-Agent", _userAgentValue);
        request.SetRequestHeader("Accept", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onFailureAction(request.error);
        }
        else
        {
            onDataReceived(request.downloadHandler.text, onSuccessAction, onFailureAction);
        }
    }
}
