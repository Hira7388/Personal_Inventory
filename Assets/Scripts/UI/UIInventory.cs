using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIInventory : UIBase
{
    [Header("닫기 버튼")]
    [SerializeField] private Button closeButton;

    // 아이템 슬롯 프리팹
    [SerializeField] private GameObject slotPrefab;

    // Transform 타입의 slot 부모 추가
    [SerializeField] private Transform contentParent;

    // UISlot 타입의 리스트 추가
    private List<UISlot> slots = new List<UISlot>();

    private Player player;
    private Inventory inventory;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        // UIStatus, Inventory 모두 Enable때마다 조건문을 검색하는 것도 좋지 않은 것 같지만, 현재 순서를 어떻게 해야 할 지 잘 모르겠습니다.
        if (player == null)
            player = GameManager.Instance.player;

        if (player != null)
            inventory = player.Inventory;

        if (inventory != null)
            inventory.OnInventoryChanged += RefreshInventory;
        
        RefreshInventory();
        closeButton.onClick.AddListener(Close);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= RefreshInventory;
        }
        closeButton.onClick.RemoveListener(Close);
    }

    private void InitInventoryUI()
    {
        // 예시로 20개의 슬롯을 미리 생성
        for (int i = 0; i < 21; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab, contentParent);
            UISlot slot = slotGO.GetComponent<UISlot>();
            slots.Add(slot);
        }
    }

    private void RefreshInventory()
    {
        if (inventory == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            // _player.Inventory 대신 _inventory.Items를 사용합니다.
            if (i < inventory.Items.Count)
            {
                slots[i].SetItem(inventory.Items[i]);
            }
            else
            {
                slots[i].SetItem(null);
            }
        }
    }

    private void Close()
    {
        // UIManager를 통해 자신(UIInventory)을 닫습니다.
        UIManager.Instance.CloseUI<UIInventory>();

        var mainMenu = UIManager.Instance.GetUI<UIMainMenu>();
        if (mainMenu != null)
        {
            mainMenu.ShowButtonGroup();
        }
    }
}
