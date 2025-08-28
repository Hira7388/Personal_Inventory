using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("Button")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    // =====================
    // 버튼 이벤트 구간
    // =====================
    private void OnEnable()
    {
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }
    private void OnDisable()
    {
        statusButton.onClick.RemoveListener(OnClickStatusButton);
        inventoryButton.onClick.RemoveListener(OnClickInventoryButton);
    }

    private void OnClickStatusButton() => UIManager.Instance.OpenUI<UIStatus>();
    private void OnClickInventoryButton() => UIManager.Instance.OpenUI<UIInventory>();


    // =====================
    // 플레이어 정보 받아오기
    // =====================

    // 받아올 정보
    // 이름, 레벨, 경험치 정보, 설명, 골드
}
