using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JellyUnlockUI : MonoBehaviour
{
    [SerializeField] private Image jellyImage;
    [SerializeField] private TextMeshProUGUI jellyNameText;
    [SerializeField] private TextMeshProUGUI jellyIDText;
    [SerializeField] private TextMeshProUGUI jellyCostText;
    [SerializeField] private TextMeshProUGUI lockCostText;
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button buyButton;

    private int currentIndex = 0;
    private DataManager dataManager;
    private JellyData currentJelly;

    private void Start()
    {
        dataManager = DataManager.Instance;
        UpdateUI();
    }

    public void OnLeftButtonClick()
    {
        currentIndex = (currentIndex - 1 + dataManager.allJellyData.Count) % dataManager.allJellyData.Count;
        UpdateUI();
    }

    public void OnRightButtonClick()
    {
        currentIndex = (currentIndex + 1) % dataManager.allJellyData.Count;
        UpdateUI();
    }

    public void OnBuyButtonClick()
    {
        currentJelly = dataManager.allJellyData[currentIndex];

        // 구매 조건: 골드로 젤리를 구매 가능
        bool canBuy = BigInteger.Parse(dataManager.playerData.gold) >= currentJelly.buyJelly;
        // 해금 조건: 젤라틴으로 젤리를 해금 가능
        bool canUnlock = BigInteger.Parse(dataManager.playerData.jellatin) >= currentJelly.unlockJelly;

        // 해금되지 않은 경우, 먼저 해금 시도
        if (!dataManager.IsJellyUnlocked(currentJelly.jellyID))
        {
            if (canUnlock)
            {
                // 젤라틴 차감 및 Jelly 해금
                dataManager.jellyReward.SpendJellatin(currentJelly.unlockJelly);
                dataManager.UnlockJelly(currentJelly.jellyID);
                dataManager.SaveData();
                Debug.Log($"{currentJelly.jellyName}이(가) 해금되었습니다!");
            }
            else
            {
                Debug.Log("젤라틴이 부족하여 해금할 수 없습니다.");
                return;
            }
        }

        // 해금된 경우, 구매 시도
        if (canBuy)
        {
            // 골드 차감 및 Jelly 구매
            dataManager.jellyReward.SpendGold(currentJelly.buyJelly);

            // JellyData의 프리팹을 사용하여 생성
            if (currentJelly.jellyPrefab != null)
            {
                dataManager.jellyManager.SpawnJelly(currentJelly);
                dataManager.SaveData();
                Debug.Log($"{currentJelly.jellyName}이(가) 구매되어 개체 수가 증가했습니다!");
            }
            else
            {
                Debug.LogError($"{currentJelly.jellyName}의 프리팹이 설정되지 않았습니다.");
            }
        }
        else
        {
            Debug.Log("골드가 부족하여 구매할 수 없습니다.");
        }

        // UI 업데이트
        UpdateUI();
    }


    private void UpdateUI()
    {
        currentJelly = dataManager.allJellyData[currentIndex];

        jellyImage.sprite = currentJelly.jellySprite;
        jellyNameText.text = currentJelly.jellyName;
        jellyIDText.text = $"#{currentJelly.jellyID:D2}";

        jellyCostText.text = $"{currentJelly.buyJelly:N0}";
        lockCostText.text = $"{currentJelly.unlockJelly:N0}";

        bool isUnlocked = dataManager.IsJellyUnlocked(currentJelly.jellyID);
        lockIcon.SetActive(!isUnlocked);
        buyButton.interactable = true;
    }
}
