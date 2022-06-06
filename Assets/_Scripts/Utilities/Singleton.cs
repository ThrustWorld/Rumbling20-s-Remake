using UnityEngine;


// Static instance != Singleton => it doesn't destroy any new instances, but it overrides the current instance.
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance{ get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit(){
        Instance = null;
        Destroy(gameObject);
    }
}


// The static instance becomes a singleton. Any new versions will be destroyed and the original instance will be intact.
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        base.Awake();
    }
}

// The singletone became persistent and it will survive through scene loads.
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
