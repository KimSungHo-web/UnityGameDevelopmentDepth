using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jelly Data", menuName = "Scriptable Object/Jelly Data")]
public class JellyData : ScriptableObject
{
    public int jellyID;
    public int rewardAmount = 10;
    public string jellyName;
    public Sprite jellySprite;
}
