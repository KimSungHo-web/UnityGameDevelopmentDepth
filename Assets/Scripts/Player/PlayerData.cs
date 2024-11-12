using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string jellatin; // BigInteger ���� ���ڿ��� ����
    public string gold;     // BigInteger ���� ���ڿ��� ����
    public List<int> unlockedJellies;

    public PlayerData()
    {
        jellatin = "0";
        gold = "0";
        unlockedJellies = new List<int>();
    }
}
