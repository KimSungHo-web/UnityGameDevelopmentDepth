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
        // ΩÃ±€≈Ê ∆–≈œ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        JellyMovement = GetComponent<JellyMovement>();
        JellyReward = GetComponent<JellyReward>();
        JellyManager = GetComponent<JellyManager>();
    }

}
