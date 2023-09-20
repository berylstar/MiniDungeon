using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [SerializeField] private TextMeshProUGUI textAP;
    [SerializeField] private TextMeshProUGUI textDP;
    [SerializeField] private TextMeshProUGUI textSpeed;

    private void OnEnable()
    {
        ShowPlayerStatus();
    }

    private void ShowPlayerStatus()
    {
        textAP.text = $"공격력 : {player.Stats.ap}";
        textDP.text = $"방어력 : {player.Stats.dp}";
        textSpeed.text = $"스피드 : {player.Stats.speed}";
    }
}
