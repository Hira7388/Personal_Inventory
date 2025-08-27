using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 1. 인스턴스가 없다면 인스턴스를 찾아본다 (씬에 존재할 경우)
    // 2. 찾아봐도 없다면 새로 만든다. (씬에 존재하지 않는 경우)
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            if (instance == null)
            {
                GameObject obj = new(typeof(T).Name);
                instance = obj.AddComponent<T>();
                (instance as Singleton<T>).Initialize();
            }
            return instance;
        }
    }

    public bool useDonDestroyOnLoad = true;

    // 초기화 메서드
    protected virtual void Initialize() { }

    // 1. 인스턴스가 존재하고 그것이 내가 아니면 지우고 그것을 사용
    // 2. 인스턴스가 존재하지 않는다면 자기 자신을 참조하고 초기화, 씬을 이동해도 Destory하지 않게 한다.
    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as T;
            Initialize();
            if(useDonDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
    }
}
