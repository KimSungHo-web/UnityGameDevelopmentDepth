using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jelly Data", menuName = "Scriptable Object/Jelly Data")]
public class JellyData : ScriptableObject
{
    public int jellyID;
    public int rewardAmount = 10;
    public int buyJelly = 10;
    public int unlockJelly = 10;
    public int sellGold = 100;
    public string jellyName;
    public Sprite jellySprite;
}
