using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyManager : MonoBehaviour
{
    [SerializeField] private JellyReward rewardManager;
    private Dictionary<int, List<JellyController>> jellyDictionary = new Dictionary<int, List<JellyController>>();

    private void Start()
    {
        if (rewardManager == null)
        {
            rewardManager = FindObjectOfType<JellyReward>();
        }
    }

    public void RegisterJelly(JellyController jelly)
    {
        int jellyID = jelly.jellyData.jellyID;

        // 젤리 종류별 리스트가 없다면 새로 생성
        if (!jellyDictionary.ContainsKey(jellyID))
        {
            jellyDictionary[jellyID] = new List<JellyController>();
        }

        // 젤리가 리스트에 없으면 추가
        if (!jellyDictionary[jellyID].Contains(jelly))
        {
            jellyDictionary[jellyID].Add(jelly);
        }
    }

    public void UnregisterJelly(JellyController jelly)
    {
        int jellyID = jelly.jellyData.jellyID;

        // 젤리 종류별 리스트에서 제거
        if (jellyDictionary.ContainsKey(jellyID))
        {
            jellyDictionary[jellyID].Remove(jelly);

            // 리스트가 비어 있으면 딕셔너리에서 제거
            if (jellyDictionary[jellyID].Count == 0)
            {
                jellyDictionary.Remove(jellyID);
            }
        }
    }

    public void CollectReward(int rewardAmount)
    {
        rewardManager.AddReward(rewardAmount);
    }

    // 특정 종류의 젤리 리스트 반환
    public List<JellyController> GetJelliesByType(int jellyID)
    {
        if (jellyDictionary.ContainsKey(jellyID))
        {
            return jellyDictionary[jellyID];
        }
        return null;
    }
}
