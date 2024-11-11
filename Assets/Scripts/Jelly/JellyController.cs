using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{
    public JellyData jellyData;
    private JellyMovement movement;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement = GetComponent<JellyMovement>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (jellyData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = jellyData.jellySprite;
        }

            //���� ���
        }

    private void OnDestroy()
    {
        // ���� ����

    }

    private void OnMouseDown()
    {
        movement.OnTouch();
        Debug.Log($"{jellyData.jellyName} ��ġ! ����: {jellyData.rewardAmount}");
    }
}
