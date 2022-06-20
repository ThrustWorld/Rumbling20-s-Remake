using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Initialize my systems out of the scene process
public static class  Bootstrapper 
{
   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
   public static void Execute() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Systems")));
}
