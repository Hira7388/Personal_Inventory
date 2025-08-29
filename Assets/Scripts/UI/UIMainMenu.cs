using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIMainMenu : UIBase
{
    [Header("Button")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    [SerializeField] private GameObject hiddenButtonGroup;

    [Header("플레이어 정보 출력")]
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private TextMeshProUGUI playerExpText;
    [SerializeField] private TextMeshProUGUI playerDescriptionText;
    [SerializeField] private Image expFillImage;
    [SerializeField] private TextMeshProUGUI playerGoldText;

    private Player player;
    private CharacterSO playerCharacterSO;
    // =====================
    // 버튼 이벤트 구간
    // =====================
    protected override void Awake()
    {
        base.Awake();
        // Todo : 게임 매니저에서 Player 불러오기 (순서 조심해야 할 듯하다 => 그래서 Start로 옮겼습니다)
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        if (player != null)
        {
            playerCharacterSO = player.CharacterDataSO;
        }
        UpdateCharacterUI();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);

        if (player != null)
        {
            player.OnExperienceChanged += UpdateCharacterUI;
            player.OnLevelChanged += UpdateCharacterUI;
            player.OnGoldChanged += UpdateCharacterUI;
        }
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        statusButton.onClick.RemoveListener(OpenStatus);
        inventoryButton.onClick.RemoveListener(OpenInventory);

        if (player != null)
        {
            player.OnExperienceChanged -= UpdateCharacterUI;
            player.OnLevelChanged -= UpdateCharacterUI;
            player.OnGoldChanged -= UpdateCharacterUI;
        }
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

    // 외부 호출용
    public void ShowButtonGroup()
    {
        hiddenButtonGroup.SetActive(true);
    }


    // =====================
    // 플레이어 정보 받아오기
    // =====================

    // 받아올 정보
    // 이름, 레벨, 경험치 정보, 설명, 골드
    private void UpdateCharacterUI()
    {
        if (player == null || playerCharacterSO == null) return;

        
        playerNameText.text = player.PlayerName;
        playerLevelText.text = $"Lv. {player.CurrentLevel}";

        playerExpText.text = $"{player.CurrentExp} / {player.RequiredExp}";

        playerDescriptionText.text = playerCharacterSO.Description;

        if (player.RequiredExp > 0)
        {
            expFillImage.fillAmount = (float)player.CurrentExp / player.RequiredExp;
        }
        else
        {
            expFillImage.fillAmount = 1;
        }
        playerGoldText.text = player.Gold.ToString("N0");
    }
}
