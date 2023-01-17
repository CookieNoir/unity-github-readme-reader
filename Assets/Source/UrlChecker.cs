using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class UrlChecker
{
    public static async Task<bool> ExistsAsync(string url)
    {
        UnityWebRequest www = UnityWebRequest.Head(url);
        www.timeout = 5;
        var operation = www.SendWebRequest();

        while (!operation.isDone) await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            // Debug.LogWarning($"{www.error}, URL:{www.url}");
            return false;
        }
        return true;
    }
}
