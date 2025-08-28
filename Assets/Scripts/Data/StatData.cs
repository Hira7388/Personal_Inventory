using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatData
{
    public int baseStat; // 기본 순수 스탯

    private List<int> _modifierStats = new List<int>(); // 해당 스텟에서 추가되는 스텟 (장비, 버프, 디버프 등등)

    public int Value
    {
        get
        {
            int finalStatValue = baseStat;
            _modifierStats.ForEach(x => finalStatValue += x); // finalStatValue에 추가된 스탯을 모두 더한다.
            return finalStatValue;
        }
    }

    // 외부에서 스텟이 추가, 제거되는 상황에 호출
    public void AddModifierStat(int modifierStat)
    {
        if(modifierStat != 0)
            _modifierStats.Add(modifierStat);
    }

    public void RemoveModifierStat(int modifierStat)
    {
        if (modifierStat != 0)
            _modifierStats.Remove(modifierStat);
    }
}

