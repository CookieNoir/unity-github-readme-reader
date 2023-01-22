using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JSONReceiver : MonoBehaviour
{
    private string _userAgentValue;
    private string _tokenValue;

    public void Set(string userAgentValue, string accessToken = null)
    {
        _userAgentValue = userAgentValue;
        if (StringHelper.IsFilled(accessToken)) _tokenValue = $"token {accessToken}";
    }

    public void TryToGetJson<T>(string url, Action<string, Action<T>, Action<string>> onDataReceived, Action<T> onSuccessAction, Action<string> onFailureAction)
    {
        StartCoroutine(_GetJSON(url, onDataReceived, onSuccessAction, onFailureAction));
    }

    private IEnumerator _GetJSON<T>(string url, Action<string, Action<T>, Action<string>> onDataReceived, Action<T> onSuccessAction, Action<string> onFailureAction)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        if (StringHelper.IsFilled(_tokenValue)) request.SetRequestHeader("Authorization", _tokenValue);
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
