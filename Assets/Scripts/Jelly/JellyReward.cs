using System.Numerics;
using UnityEngine;

public class JellyReward : MonoBehaviour
{
    public BigInteger jellatin = BigInteger.Zero;
    public BigInteger gold = BigInteger.Zero;

    private void UpdateUI()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.ui.UpdateUI();
        }
    }
    public void AddJellatin(BigInteger amount)
    {
        jellatin += amount;
        DataManager.Instance.SaveData();
        UpdateUI();
        Debug.Log($"����ƾ �߰�: {amount}, �� ����ƾ: {jellatin}");
    }

    public void SpendJellatin(BigInteger amount)
    {
        if (jellatin >= amount)
        {
            jellatin -= amount;
            DataManager.Instance.SaveData();
            UpdateUI();
            Debug.Log($"����ƾ ���: {amount}, ���� ����ƾ: {jellatin}");
        }
        else
        {
            Debug.Log("����ƾ�� �����մϴ�!");
        }
    }

    public void AddGold(BigInteger amount)
    {
        gold += amount;
        DataManager.Instance.SaveData();
        UpdateUI();
        Debug.Log($"��� �߰�: {amount}, �� ���: {gold}");
    }

    public void SpendGold(BigInteger amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            DataManager.Instance.SaveData();
            UpdateUI();
            Debug.Log($"��� ���: {amount}, ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }
}
