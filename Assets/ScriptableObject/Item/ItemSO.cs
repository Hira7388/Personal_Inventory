using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    [Header("아이템 정보")]
    public string itemName;
    public string description;
    public Sprite icon;

    [Header("장비 스탯 보너스")]
    public BaseCharacterStat statBonuses;
}