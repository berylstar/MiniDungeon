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
        textAP.text = $"���ݷ� : {player.Stats.ap}";
        textDP.text = $"���� : {player.Stats.dp}";
        textSpeed.text = $"���ǵ� : {player.Stats.speed}";
    }
}
