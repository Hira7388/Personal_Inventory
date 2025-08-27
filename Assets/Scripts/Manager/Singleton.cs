using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 1. �ν��Ͻ��� ���ٸ� �ν��Ͻ��� ã�ƺ��� (���� ������ ���)
    // 2. ã�ƺ��� ���ٸ� ���� �����. (���� �������� �ʴ� ���)
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

    // �ʱ�ȭ �޼���
    protected virtual void Initialize() { }

    // 1. �ν��Ͻ��� �����ϰ� �װ��� ���� �ƴϸ� ����� �װ��� ���
    // 2. �ν��Ͻ��� �������� �ʴ´ٸ� �ڱ� �ڽ��� �����ϰ� �ʱ�ȭ, ���� �̵��ص� Destory���� �ʰ� �Ѵ�.
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
