using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image equippedIconObject;

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

            if (player != null && equippedIconObject != null)
            {
                bool isEquipped = (player.EquippedWeapon == item);
                equippedIconObject.gameObject.SetActive(isEquipped);
            }
        }
        else // 슬롯이 비어있을 경우
        {
            itemIcon.sprite = null;
            itemIcon.gameObject.SetActive(false);

            if (equippedIconObject != null)
            {
                equippedIconObject.gameObject.SetActive(false);
            }
        }
    }

    private void OnSlotClicked()
    {
        if (item == null || player == null) return;

        if (player.EquippedWeapon == item)
        {
            // 같다면, 장착 해제
            player.UnEquip(item);
        }
        else
        {
            // 다르다면, 장착
            player.Equip(item);
        }
    }
}
