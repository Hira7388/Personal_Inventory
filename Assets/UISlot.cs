using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;

    private Item _item;

    public void SetItem(Item item)
    {
        _item = item;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (_item != null)
        {
            itemIcon.sprite = _item.icon;
            itemIcon.gameObject.SetActive(true);
        }
        else // 슬롯이 비어있을 경우
        {
            itemIcon.sprite = null;
            itemIcon.gameObject.SetActive(false);
        }
    }
}
