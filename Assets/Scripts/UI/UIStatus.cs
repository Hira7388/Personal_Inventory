using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIStatus : UIBase
{
    [Header("스탯 UI 요소")]
    [SerializeField] private TextMeshProUGUI attackValueText;
    [SerializeField] private TextMeshProUGUI defenseValueText;
    [SerializeField] private TextMeshProUGUI healthValueText;
    [SerializeField] private TextMeshProUGUI criticalValueText;

    [Header("닫기 버튼")]
    [SerializeField] private Button closeButton;

    private Player player;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (closeButton != null)
            closeButton.onClick.AddListener(Close);

        if (player == null)
            player = GameManager.Instance.player;

        if (player != null)
            player.OnLevelChanged += UpdateStatUI;

        UpdateStatUI();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (closeButton != null)
            closeButton.onClick.RemoveListener(Close);

        if (player != null)
            player.OnLevelChanged -= UpdateStatUI;
    }

    private void UpdateStatUI()
    {
        if (player == null) return;

        // Player가 가지고 있는 런타임 스탯(PlayerStat)의 최종 값(Value)을 가져옵니다.
        attackValueText.text = player.PlayerRuntimeStat.Attack.Value.ToString();
        defenseValueText.text = player.PlayerRuntimeStat.Defense.Value.ToString();
        healthValueText.text = player.PlayerRuntimeStat.Health.Value.ToString();
        criticalValueText.text = player.PlayerRuntimeStat.Critical.Value.ToString();
    }

    private void Close()
    {
        // UIManager를 통해 자신(UIStatus)을 닫습니다.
        UIManager.Instance.CloseUI<UIStatus>();

        var mainMenu = UIManager.Instance.GetUI<UIMainMenu>();
        if (mainMenu != null)
        {
            mainMenu.ShowButtonGroup();
        }
    }
}
