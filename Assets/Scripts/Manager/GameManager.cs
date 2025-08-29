using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player { get; private set; }

    [Header("임시 아이템 데이터 (테스트용)")]
    [Tooltip("게임 시작 시 플레이어에게 지급할 아이템 목록")]
    [SerializeField] private List<ItemSO> startingItems;

    // 생성자 대신 플레이어 등록
    public void RegisterPlayer(Player playerInstance)
    {
        player = playerInstance;
    }

    private void Start()
    {
        // Player 등록이 끝난 후, 테스트용 아이템을 추가합니다.
        if (player != null)
        {
            AddInitialItems();
        }
    }

    private void AddInitialItems()
    {
        foreach (var item in startingItems)
        {
            if (item != null)
            {
                player.Inventory.AddItem(item);
            }
        }
    }
}
