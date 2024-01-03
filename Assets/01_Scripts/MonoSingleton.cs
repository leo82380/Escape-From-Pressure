using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                var obj = FindObjectOfType<T>();
                if(obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject(typeof(T).ToString());
                    _instance = newSingleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    
    protected virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
} 
