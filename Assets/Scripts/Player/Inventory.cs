using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> Items { get; private set; } = new List<ItemSO>();
    public event Action OnInventoryChanged;

    public void AddItem(ItemSO itemToAdd)
    {
        Items.Add(itemToAdd);

        // 인벤토리에 변화가 생겼음을 외부에 알립니다.
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemSO itemToRemove)
    {
        if (Items.Remove(itemToRemove))
        {
            OnInventoryChanged?.Invoke();
        }
    }
}
