using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string jellatin; // BigInteger 값을 문자열로 저장
    public string gold;     // BigInteger 값을 문자열로 저장
    public List<int> unlockedJellies;

    public PlayerData()
    {
        jellatin = "0";
        gold = "0";
        unlockedJellies = new List<int>();
    }
}
