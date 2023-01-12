using System.Collections;
using UnityEngine;

public static class GameObjectHelper
{
    public static void SetActive(IEnumerable gameObjects, bool value)
    {
        foreach (GameObject go in gameObjects) go.SetActive(value);
    }
}
