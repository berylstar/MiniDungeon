using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats", menuName = "Scriptable Object/Unit Stats")]
public class UnitStatsSO : ScriptableObject
{
    [Header("Unit Info")]
    public string nickname;
    public Sprite image;
    public int level;
    public int MaxHp;
    public int ap;
    public int dp;
    public int speed;
    public int gold;
}
