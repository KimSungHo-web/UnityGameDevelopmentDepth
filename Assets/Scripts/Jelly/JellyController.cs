using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{
    public JellyData jellyData;
    private JellyMovement movement;
    private SpriteRenderer spriteRenderer;
    private JellyReward jellyReward;

    private void Awake()
    {
        movement = GetComponent<JellyMovement>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        jellyReward = FindObjectOfType<JellyReward>();

        // ���� �����Ϳ��� ��������Ʈ ����
        if (jellyData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = jellyData.jellySprite;
        }
    }

    private void OnDestroy()
    {
        // ���� ���� ���� (�ʿ� �� �߰�)
    }

    private void OnMouseDown()
    {
        // ���� Ŭ�� �� ���� �߰�
        movement.OnTouch();
        if (jellyData != null && jellyReward != null)
        {
            jellyReward.AddJellatin(jellyData.rewardAmount);
            Debug.Log($"{jellyData.jellyName} ��ġ! ����: {jellyData.rewardAmount}");
        }
    }
}
