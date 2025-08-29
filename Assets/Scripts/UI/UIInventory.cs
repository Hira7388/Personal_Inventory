using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;


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

    private void Start()
    {
        // 1. Player 및 Inventory 참조를 한 번만 가져옵니다.
        player = GameManager.Instance.player;
        if (player != null)
        {
            inventory = player.Inventory;
        }
        else
        {
            Debug.LogError("UIInventory: Player 참조를 찾을 수 없습니다!");
        }

        // 2. 인벤토리 슬롯들을 생성합니다.
        InitInventoryUI();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (closeButton != null)
            closeButton.onClick.AddListener(Close);

        if (inventory != null)
            inventory.OnInventoryChanged += RefreshInventory;
        
        RefreshInventory();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (closeButton != null)
            closeButton.onClick.RemoveListener(Close);

        if (inventory != null)
            inventory.OnInventoryChanged -= RefreshInventory;
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

        InitInventoryUI();
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
