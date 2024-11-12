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
        Debug.Log($"Á©¸®Æ¾ Ãß°¡: {amount}, ÃÑ Á©¸®Æ¾: {jellatin}");
    }

    public void SpendJellatin(BigInteger amount)
    {
        if (jellatin >= amount)
        {
            jellatin -= amount;
            DataManager.Instance.SaveData();
            UpdateUI();
            Debug.Log($"Á©¸®Æ¾ »ç¿ë: {amount}, ³²Àº Á©¸®Æ¾: {jellatin}");
        }
        else
        {
            Debug.Log("Á©¸®Æ¾ÀÌ ºÎÁ·ÇÕ´Ï´Ù!");
        }
    }

    public void AddGold(BigInteger amount)
    {
        gold += amount;
        DataManager.Instance.SaveData();
        UpdateUI();
        Debug.Log($"°ñµå Ãß°¡: {amount}, ÃÑ °ñµå: {gold}");
    }

    public void SpendGold(BigInteger amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            DataManager.Instance.SaveData();
            UpdateUI();
            Debug.Log($"°ñµå »ç¿ë: {amount}, ³²Àº °ñµå: {gold}");
        }
        else
        {
            Debug.Log("°ñµå°¡ ºÎÁ·ÇÕ´Ï´Ù!");
        }
    }
}
