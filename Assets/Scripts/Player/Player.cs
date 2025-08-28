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
    public CharacterSO CharacterDataSO => _characterDataSO;
    // 런타임 스텟
    private PlayerStat _playerRuntimeStat;

    // 플레이어 데이터
    [SerializeField] private int gold;
    [SerializeField] private string playerName;
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentExp;

    // UI 변수 호출용
    public PlayerStat PlayerRuntimeStat => _playerRuntimeStat;
    public string PlayerName => playerName;
    public int Gold => gold;
    public int CurrentLevel => currentLevel;
    public int CurrentExp => currentExp;
    public int RequiredExp => _characterDataSO.ExpTable.GetRequireExp(currentLevel);

    // UI 변경 이벤트
    public event Action OnExperienceChanged;
    public event Action OnLevelChanged;
    public event Action OnGoldChanged;

    private void Awake()
    {
        GameManager.Instance.RegisterPlayer(this);
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
        //currentLevel = 1;
        //currentExp = 0;
    }

    // 경험치 추가 메서드, 외부에서 경험치를 획득할 때 이 메서드를 호출한다.
    public void AddExp(int amount)
    {
        if (amount <= 0) return;

        currentExp += amount;
        int requiredExp = _characterDataSO.ExpTable.GetRequireExp(currentLevel);

        if(currentExp >= requiredExp)
        {
            currentExp -= requiredExp;
            LevelUp();
        }
        OnExperienceChanged?.Invoke();
    }

    // 외부에서 레벨업을 불러오지는 않고 획득 경험치에 맞게 호출함
    private void LevelUp()
    {
        currentLevel++; 

        _playerRuntimeStat.Health.baseStat += _characterDataSO.LevelUpStat.Health;
        _playerRuntimeStat.Attack.baseStat += _characterDataSO.LevelUpStat.Attack;
        _playerRuntimeStat.Defense.baseStat += _characterDataSO.LevelUpStat.Defense;
        _playerRuntimeStat.Critical.baseStat += _characterDataSO.LevelUpStat.Critical;

        OnLevelChanged?.Invoke();
    }

    public void AddGold(int amount)
    {
        if (amount <= 0) return;
        gold += amount;
        OnGoldChanged?.Invoke();
    }

    public void SpendGold(int amount)
    {
        if (amount <= 0) return;

        if(gold < amount)
        {
            // 골드 부족
        }
        else
        {
            gold -= amount;
            OnGoldChanged?.Invoke();
        }
    }
}
