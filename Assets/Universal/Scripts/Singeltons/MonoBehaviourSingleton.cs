using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning($"Instance already exists.{name}", this);
            Destroy(_instance);
        }

        Debug.Log($"Singleton Instance of type {typeof(T).Name} created!");
        _instance = this as T;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}
