using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Experience Table", menuName = "ScriptableObject/Experience Table")]
public class ExperienceSO : ScriptableObject
{
    public List<int> RequiredExperience;

    // 현재 레벨에서 필요한 경험치 요구량을 가져온다.
    public int GetRequireExp(int level)
    {
        if(level > 0 && level <= RequiredExperience.Count)
        {
            return RequiredExperience[level - 1];
        }
        // 위 조건에 맞지 않으면 최대 레벨이거나 혹은 버그성 레벨?
        return 0;
    }
}
