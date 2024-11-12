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
        // 싱글톤 초기화
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

        // 경로 설정 및 참조 초기화
        dataPath = Path.Combine(Application.persistentDataPath, "playerData.json");
        Debug.Log($"저장된 데이터 경로: {Application.persistentDataPath}");
        ui = FindObjectOfType<UI>();
        jellyReward = FindObjectOfType<JellyReward>();

        if (jellyReward == null)
        {
            Debug.LogError("JellyReward 인스턴스를 찾을 수 없습니다.");
            return;
        }

        // 데이터 로드
        if (File.Exists(dataPath))
        {
            LoadData();
        }
        else
        {
            InitializeData();
        }

        // UI 업데이트
        ui.UpdateUI();
    }

    private void InitializeData()
    {
        playerData = new PlayerData();
        SaveData();
        Debug.Log("데이터 초기화 완료");
    }

    public void SaveData()
    {
        // JellyReward의 값을 저장할 때 BigInteger 값을 문자열로 변환
        playerData.jellatin = jellyReward.jellatin.ToString();
        playerData.gold = jellyReward.gold.ToString();

        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(dataPath, jsonData);
        Debug.Log("데이터 저장 완료");
    }

    public void LoadData()
    {
        string jsonData = File.ReadAllText(dataPath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        // 문자열 값을 BigInteger로 변환하여 JellyReward에 적용
        jellyReward.jellatin = BigInteger.Parse(playerData.jellatin);
        jellyReward.gold = BigInteger.Parse(playerData.gold);

        Debug.Log($"데이터 불러오기 완료: 젤리틴 {jellyReward.jellatin}, 골드 {jellyReward.gold}");
    }

    public void UnlockJelly(int jellyID)
    {
        if (!playerData.unlockedJellies.Contains(jellyID))
        {
            playerData.unlockedJellies.Add(jellyID);
            SaveData();
            Debug.Log($"젤리 해금: ID {jellyID}");
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
