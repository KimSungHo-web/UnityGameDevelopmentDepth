using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{
    public JellyData jellyData;
    private JellyMovement movement;
    private JellyManager jellyManager;

    private void Awake()
    {
        movement = GetComponent<JellyMovement>();
        jellyManager = FindObjectOfType<JellyManager>();

        if (jellyData != null)
        {
            GetComponent<SpriteRenderer>().sprite = jellyData.jellySprite;
        }

        // JellyManager에 젤리 등록
        jellyManager.RegisterJelly(this);
    }

    private void OnDestroy()
    {
        // JellyManager에서 젤리 제거
        jellyManager.UnregisterJelly(this);
    }

    private void OnMouseDown()
    {
        movement.OnTouch();
        jellyManager.CollectReward(jellyData.rewardAmount);
        Debug.Log($"{jellyData.jellyName} 터치! 보상: {jellyData.rewardAmount}");
    }
}
