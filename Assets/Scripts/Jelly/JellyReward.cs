using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyReward : MonoBehaviour
{
    private int totalReward;

    public void AddReward(int amount)
    {
        totalReward += amount;
        Debug.Log($"재화 획득: {amount}, 총 재화: {totalReward}");
    }

    public void SpendReward(int amount)
    {
        if (totalReward >= amount)
        {
            totalReward -= amount;
            Debug.Log($"재화 사용: {amount}, 남은 재화: {totalReward}");
        }
        else
        {
            Debug.Log("재화 부족!");
        }
    }

    public int GetTotalReward() => totalReward;
}
