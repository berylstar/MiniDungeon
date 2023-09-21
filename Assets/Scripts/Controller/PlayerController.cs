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
}
