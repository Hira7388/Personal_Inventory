using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerStat
{
    public StatData Health;
    public StatData Attack;
    public StatData Defense;
    public StatData Critical;
}


public class Player : MonoBehaviour
{
    [SerializeField] private CharacterSO _characterDataSO;

    // 런타임 스텟
    private PlayerStat _playerRuntimeStat;

    // 플레이어 데이터
    [SerializeField] private int gold;
    [SerializeField] private string name;
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentExp;

    private void Awake()
    {
        InitializeStat();
    }

    private void InitializeStat()
    {
        _playerRuntimeStat = new PlayerStat();
        _playerRuntimeStat.Health = new StatData();
        _playerRuntimeStat.Attack = new StatData();
        _playerRuntimeStat.Defense = new StatData();
        _playerRuntimeStat.Critical = new StatData();

        _playerRuntimeStat.Health.baseStat = _characterDataSO.BaseStat.Health;
        _playerRuntimeStat.Attack.baseStat = _characterDataSO.BaseStat.Attack;
        _playerRuntimeStat.Defense.baseStat = _characterDataSO.BaseStat.Defense;
        _playerRuntimeStat.Critical.baseStat = _characterDataSO.BaseStat.Critical;

        // 저장하기 등으로 경험치를 가져오면 여기서 저장된 데이터를 불러와야 할 것
        currentLevel = 1;
        currentExp = 0;
    }
}
