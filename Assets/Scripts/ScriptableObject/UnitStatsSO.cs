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


    public void ChangeStats(UnitStatsSO other, bool onoff)
    {
        int pm = onoff ? 1 : -1;

        MaxHp += other.MaxHp * pm;
        ap += other.ap * pm;
        dp += other.dp * pm;
        speed += other.speed * pm;
    }
}
