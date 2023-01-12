using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class ReadmeChecker
{
    public static async Task<bool> ExistsAsync(string fullName, string defaultBranch)
    {
        string url = $"https://github.com/{fullName}/blob/{defaultBranch}/README.md";
        UnityWebRequest www = UnityWebRequest.Head(url);
        www.timeout = 5;
        var operation = www.SendWebRequest();

        while (!operation.isDone) await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning($"{www.error}, URL:{www.url}");
            return false;
        }
        return true;
    }
}
