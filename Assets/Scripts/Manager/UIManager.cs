using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Dictionary<string, UIBase> uiDictionary = new Dictionary<string, UIBase>();

    [Header("시작 시 비활성화할 UI")]
    [SerializeField]
    private List<UIBase> initiallyHiddenUIs;

    // 다른 UI를 열 때 굳이 해당 UI를 알 필요 없이 UIManager를 통해서 열어달라고 호출하면 된다.
    public void OpenUI<T>() where T : UIBase
    {
        var ui = GetUI<T>();
        ui?.OpenUI(); // UIBase에 OpenUI
    }

    public void CloseUI<T>() where T : UIBase
    {
        var ui = GetUI<T>();
        ui?.CloseUI();
    }

    public T GetUI<T>() where T : UIBase
    {
        // 게임 오브젝트 이름도 스크립트 이름과 반드시 동일해야 한다.(이는 개선이 필요해보입니다.)
        UIBase ui;
        string uiName = typeof(T).Name;

        ui = uiDictionary[uiName];

        return ui as T;
    }

    private void Start()
    {
        foreach (var ui in initiallyHiddenUIs)
        {
            if (ui != null)
            {
                ui.CloseUI();
            }
        }
    }
}
