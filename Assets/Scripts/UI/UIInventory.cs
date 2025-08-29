using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIBase
{
    private Player player;
    private Inventory inventory;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        if(player != null )
        {
            inventory = player.Inventory;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}
