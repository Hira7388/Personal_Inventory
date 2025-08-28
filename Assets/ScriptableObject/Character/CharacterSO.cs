using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BaseCharacterStat
{
    public int Health;
    public int Attack;
    public int Defense;
    public int Critical;
}

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObject/CharacterData")]
public class CharacterSO : ScriptableObject
{
    // 기본 정보
    [Header("기본 정보")]
    public string CharaterType; // 전사, 마법사 등등
    [TextArea(3, 5)]
    public string Description;

    // 스텟 정보
    [Header("스텟 정보")]
    public BaseCharacterStat BaseStat;
    public BaseCharacterStat LevelUpStat;

    // 성장 정보
    [Header("성장 정보")]
    public ExperienceSO ExpTable;
}
