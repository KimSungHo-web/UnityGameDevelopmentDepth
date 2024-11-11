using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public JellyMovement JellyMovement;
    public JellyReward JellyReward;
    public JellyManager JellyManager;
   // public RewardManager rewardManager;

    private void Awake()
    {
        // 싱글톤 패턴
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // 매니저 컴포넌트 초기화
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        JellyMovement = GetComponent<JellyMovement>();
        JellyReward = GetComponent<JellyReward>();
        JellyManager = GetComponent<JellyManager>();

    }
}
