using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="statData", menuName ="ScriptableObject/Stat")]
public class StatSO : ScriptableObject
{
    [Header("Unit Info")]
    public string unitName;
    public int level;
    public int ap;
    public int dp;
    public int speed;
}
