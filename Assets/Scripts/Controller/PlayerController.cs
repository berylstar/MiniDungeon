using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] UnitStatsSO stats;
    public UnitStatsSO Stats { get; private set; }
    public int HP { get; private set; }

    private void Awake()
    {
        Stats = stats;
        HP = stats.MaxHp;
    }
}
