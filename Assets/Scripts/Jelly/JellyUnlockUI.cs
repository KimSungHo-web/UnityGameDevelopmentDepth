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

        // ���� ����: ���� ������ ���� ����
        bool canBuy = BigInteger.Parse(dataManager.playerData.gold) >= currentJelly.buyJelly;
        // �ر� ����: ����ƾ���� ������ �ر� ����
        bool canUnlock = BigInteger.Parse(dataManager.playerData.jellatin) >= currentJelly.unlockJelly;

        // �رݵ��� ���� ���, ���� �ر� �õ�
        if (!dataManager.IsJellyUnlocked(currentJelly.jellyID))
        {
            if (canUnlock)
            {
                // ����ƾ ���� �� Jelly �ر�
                dataManager.jellyReward.SpendJellatin(currentJelly.unlockJelly);
                dataManager.UnlockJelly(currentJelly.jellyID);
                dataManager.SaveData();
                Debug.Log($"{currentJelly.jellyName}��(��) �رݵǾ����ϴ�!");
            }
            else
            {
                Debug.Log("����ƾ�� �����Ͽ� �ر��� �� �����ϴ�.");
                return;
            }
        }

        // �رݵ� ���, ���� �õ�
        if (canBuy)
        {
            // ��� ���� �� Jelly ����
            dataManager.jellyReward.SpendGold(currentJelly.buyJelly);

            // JellyData�� �������� ����Ͽ� ����
            if (currentJelly.jellyPrefab != null)
            {
                dataManager.jellyManager.SpawnJelly(currentJelly);
                dataManager.SaveData();
                Debug.Log($"{currentJelly.jellyName}��(��) ���ŵǾ� ��ü ���� �����߽��ϴ�!");
            }
            else
            {
                Debug.LogError($"{currentJelly.jellyName}�� �������� �������� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            Debug.Log("��尡 �����Ͽ� ������ �� �����ϴ�.");
        }

        // UI ������Ʈ
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
