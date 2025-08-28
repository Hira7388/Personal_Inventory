using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    protected virtual void Awake() 
    {
        AddUIDictionary();
    }

    public void AddUIDictionary()
    {
        UIManager.Instance.uiDictionary.Add(gameObject.name, this);
    }

    public virtual void OpenUI()
    {
        gameObject.SetActive(true);
        
    }

    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }
}
