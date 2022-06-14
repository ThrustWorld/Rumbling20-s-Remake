using UnityEngine;
using System.Collections.Generic;
//A static class for general helpful methods

public static class Helpers
{
    public static void DestroyChildren(this Transform t)
    {
        foreach(Transform child in t) Object.Destroy(child.gameObject);
    }

    public static List<GameObject> GetList() 
    {
        return new List<GameObject>();
    }
}