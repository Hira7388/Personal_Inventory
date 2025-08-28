using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("Button")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    [SerializeField] private GameObject hiddenButtonGroup;

    // =====================
    // 버튼 이벤트 구간
    // =====================
    private void OnEnable()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }
    private void OnDisable()
    {
        statusButton.onClick.RemoveListener(OpenStatus);
        inventoryButton.onClick.RemoveListener(OpenInventory);
    }
    

    private void OpenStatus()
    {
        hiddenButtonGroup.SetActive(false);
        UIManager.Instance.OpenUI<UIStatus>();
    }
    private void OpenInventory()
    {
        hiddenButtonGroup.SetActive(false);
        UIManager.Instance.OpenUI<UIInventory>();
    }


    // =====================
    // 플레이어 정보 받아오기
    // =====================

    // 받아올 정보
    // 이름, 레벨, 경험치 정보, 설명, 골드
}
