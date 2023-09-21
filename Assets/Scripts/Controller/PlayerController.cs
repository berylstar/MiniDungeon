using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stat")]
    public UnitStatsSO stats;
    public int hp;
    public int exp;
    public List<ItemSO> items = new List<ItemSO>() { null, null, null, null };

    private void Awake()
    {
        hp = stats.MaxHp;
        exp = 0;
    }

    public void ChangeStats(ItemSO other, bool onoff)
    {
        int pm = onoff ? 1 : -1;

        stats.MaxHp += other.maxHp * pm;
        hp = Mathf.Min(hp, stats.MaxHp);

        stats.ap += other.ap * pm;
        stats.dp += other.dp * pm;
        stats.speed += other.speed * pm;
    }
}
