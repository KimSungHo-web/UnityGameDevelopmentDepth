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

        // ���� ������ ����Ʈ�� ���ٸ� ���� ����
        if (!jellyDictionary.ContainsKey(jellyID))
        {
            jellyDictionary[jellyID] = new List<JellyController>();
        }

        // ������ ����Ʈ�� ������ �߰�
        if (!jellyDictionary[jellyID].Contains(jelly))
        {
            jellyDictionary[jellyID].Add(jelly);
        }
    }

    public void UnregisterJelly(JellyController jelly)
    {
        int jellyID = jelly.jellyData.jellyID;

        // ���� ������ ����Ʈ���� ����
        if (jellyDictionary.ContainsKey(jellyID))
        {
            jellyDictionary[jellyID].Remove(jelly);

            // ����Ʈ�� ��� ������ ��ųʸ����� ����
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

    // Ư�� ������ ���� ����Ʈ ��ȯ
    public List<JellyController> GetJelliesByType(int jellyID)
    {
        if (jellyDictionary.ContainsKey(jellyID))
        {
            return jellyDictionary[jellyID];
        }
        return null;
    }
}
