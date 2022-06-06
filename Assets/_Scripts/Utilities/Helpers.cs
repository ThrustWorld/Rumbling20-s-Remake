using UnityEngine;

//A static class for general helpful methods

public static class Helpers
{
    public static void DestroyChildren(this Transform t)
    {
        foreach(Transform child in t) Object.Destroy(child.gameObject);
    }
}