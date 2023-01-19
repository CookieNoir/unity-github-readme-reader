using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnityGithubReader : IGithubReader
{
    private IEnumerator _GetJSON<T>(string url, Action<string, Action<T>, Action<string>> onDataReceived, Action<T> onSuccessAction, Action<string> onFailureAction)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("User-Agent", $"{Application.productName}/{Application.version}");
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

    public void RequestUserData(string username, Action<UserData> onSuccessAction = null, Action<string> onFailureAction = null)
    {
        throw new NotImplementedException();
    }

    private void _OnUserDataReceived<UserData>(string json, Action<UserData> onSuccessAction, Action<string> onFailureAction)
    {
        // TODO
    }

    public void RequestUserRepositoriesData(string username, Action<IEnumerable<RepositoryData>> onSuccessAction, Action<string> onFailureAction = null)
    {
        throw new NotImplementedException();
    }

    public void RequestRepositoryReadme(long repositoryId, Action<string> onSuccessAction, Action<string> onFailureAction = null)
    {
        throw new NotImplementedException();
    }
}
