using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private static string dataPath;
    public PlayerData playerData;
    public List<JellyData> allJellyData;
    public UI ui;
    private JellyReward jellyReward;

    private void Awake()
    {
        // �̱��� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // ��� ���� �� ���� �ʱ�ȭ
        dataPath = Path.Combine(Application.persistentDataPath, "playerData.json");
        Debug.Log($"����� ������ ���: {Application.persistentDataPath}");
        ui = FindObjectOfType<UI>();
        jellyReward = FindObjectOfType<JellyReward>();

        if (jellyReward == null)
        {
            Debug.LogError("JellyReward �ν��Ͻ��� ã�� �� �����ϴ�.");
            return;
        }

        // ������ �ε�
        if (File.Exists(dataPath))
        {
            LoadData();
        }
        else
        {
            InitializeData();
        }

        // UI ������Ʈ
        ui.UpdateUI();
    }

    private void InitializeData()
    {
        playerData = new PlayerData();
        SaveData();
        Debug.Log("������ �ʱ�ȭ �Ϸ�");
    }

    public void SaveData()
    {
        // JellyReward�� ���� ������ �� BigInteger ���� ���ڿ��� ��ȯ
        playerData.jellatin = jellyReward.jellatin.ToString();
        playerData.gold = jellyReward.gold.ToString();

        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(dataPath, jsonData);
        Debug.Log("������ ���� �Ϸ�");
    }

    public void LoadData()
    {
        string jsonData = File.ReadAllText(dataPath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        // ���ڿ� ���� BigInteger�� ��ȯ�Ͽ� JellyReward�� ����
        jellyReward.jellatin = BigInteger.Parse(playerData.jellatin);
        jellyReward.gold = BigInteger.Parse(playerData.gold);

        Debug.Log($"������ �ҷ����� �Ϸ�: ����ƾ {jellyReward.jellatin}, ��� {jellyReward.gold}");
    }

    public void UnlockJelly(int jellyID)
    {
        if (!playerData.unlockedJellies.Contains(jellyID))
        {
            playerData.unlockedJellies.Add(jellyID);
            SaveData();
            Debug.Log($"���� �ر�: ID {jellyID}");
        }
    }

    public bool IsJellyUnlocked(int jellyID)
    {
        return playerData.unlockedJellies.Contains(jellyID);
    }

    public JellyData GetJellyData(int jellyID)
    {
        return allJellyData.Find(jelly => jelly.jellyID == jellyID);
    }

}
