using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class TextureLoader
{
    public static async Task<Texture2D> GetRemoteTexture(string url, int secondsToTimeout)
    {
        using UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        www.timeout = secondsToTimeout;
        var operation = www.SendWebRequest();

        while (!operation.isDone) await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning($"{www.error}, URL:{www.url}");
            return null;
        }
        return DownloadHandlerTexture.GetContent(www);
    }
}
