using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    public Sprite icon;

    public Item(string itemName, string description, Sprite icon)
    {
        this.itemName = itemName;
        this.description = description;
        this.icon = icon;
    }
}
