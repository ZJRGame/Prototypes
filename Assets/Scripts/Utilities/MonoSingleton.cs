using UnityEngine;

/// <summary>
/// 继承MonoBehaviour的单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool global = true;
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance =(T)FindObjectOfType<T>();
            }
            return instance;
        }

    }

    //该类会占用Awake，继承该类时要使用Awake的话，需重写OnAwake
    void Awake()
    {
        Debug.LogWarningFormat("{0}[{1}]Awake",typeof(T),this.GetInstanceID());
        if (global)
        {
            if (instance != null && instance != this.gameObject.GetComponent<T>())
            {
                Destroy(this.gameObject);
                return;
            }
            DontDestroyOnLoad(this.gameObject);
            instance = this.gameObject.GetComponent<T>();
        }
        this.OnAwake();
    }

    protected virtual void OnAwake()
    {

    }
}