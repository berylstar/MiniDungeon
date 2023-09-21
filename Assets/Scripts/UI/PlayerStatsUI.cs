using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [Header("Default UI")]
    public TextMeshProUGUI textNickname;
    public TextMeshProUGUI textLevel;
    public Image imagePlayer;
    public Slider hpBar;
    public TextMeshProUGUI textHP;
    public Slider expBar;
    public TextMeshProUGUI textEXP;

    [Header("Status UI")]
    [SerializeField] private TextMeshProUGUI textAP;
    [SerializeField] private TextMeshProUGUI textDP;
    [SerializeField] private TextMeshProUGUI textSpeed;
    [SerializeField] private List<Image> imageItems;

    private void Start()
    {
        ShowDefaultUI();
    }

    public void ShowDefaultUI()
    {
        textNickname.text = player.stats.nickname;
        textLevel.text = $"Lv.{player.stats.level}";
        imagePlayer.sprite = player.stats.image;
        hpBar.value = player.hp / (float)player.stats.MaxHp;
        textHP.text = $"{player.hp}/{player.stats.MaxHp}";
        expBar.value = player.exp / (float)(player.stats.level + 5);
        textEXP.text = $"{player.exp}/{player.stats.level + 5}";
    }

    public void ShowPlayerStatus()
    {
        textAP.text = $"공격력 : {player.stats.ap}";
        textDP.text = $"방어력 : {player.stats.dp}";
        textSpeed.text = $"스피드 : {player.stats.speed}";

        for (int i = 0; i < 4; i++)
        {
            if (player.items[i] != null)
            {
                imageItems[i].sprite = player.items[i].image;
            }
            else
            {
                imageItems[i].sprite = null;
            }
        }
    }
}
