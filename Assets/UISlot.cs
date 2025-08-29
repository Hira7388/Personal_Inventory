using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;

    private ItemSO item;
    private Player player;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnSlotClicked);
    }

    public void Initialize(Player player)
    {
        this.player = player;
    }

    public void SetItem(ItemSO itemSO)
    {
        item = itemSO;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (item != null)
        {
            itemIcon.sprite = item.icon;
            itemIcon.gameObject.SetActive(true);
        }
        else // 슬롯이 비어있을 경우
        {
            itemIcon.sprite = null;
            itemIcon.gameObject.SetActive(false);
        }
    }

    private void OnSlotClicked()
    {
        if (item == null || player == null) return;

        // 아이템 타입을 체크하는 분기문 없이, 바로 Equip 함수를 호출합니다.
        player.Equip(item);
    }
}
