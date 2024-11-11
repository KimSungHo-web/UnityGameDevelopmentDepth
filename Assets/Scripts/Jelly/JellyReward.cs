using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyReward : MonoBehaviour
{
    private int totalReward;

    public void AddReward(int amount)
    {
        totalReward += amount;
        Debug.Log($"��ȭ ȹ��: {amount}, �� ��ȭ: {totalReward}");
    }

    public void SpendReward(int amount)
    {
        if (totalReward >= amount)
        {
            totalReward -= amount;
            Debug.Log($"��ȭ ���: {amount}, ���� ��ȭ: {totalReward}");
        }
        else
        {
            Debug.Log("��ȭ ����!");
        }
    }

    public int GetTotalReward() => totalReward;
}
