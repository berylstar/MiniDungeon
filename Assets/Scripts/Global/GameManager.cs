using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
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

    private void Start()
    {
        textNickname.text = player.Stats.nickname;
        textLevel.text = $"Lv.{player.Stats.level}";
        imagePlayer.sprite = player.Stats.image;
        textHP.text = $"{player.Stats.MaxHp}/{player.Stats.MaxHp}";
    }
}
