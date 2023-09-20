using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroSceneScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int InputError = Animator.StringToHash("InputError");
    private static readonly int ButtonNext = Animator.StringToHash("ButtonNext");

    [Header("Nickname")]
    [SerializeField] GameObject objectNickname;
    [SerializeField] private TMP_InputField inputNickname;
    private string nickname = "";

    [Header("Job")]
    [SerializeField] GameObject objectJob;

    [Header("Characters")]
    [SerializeField] private List<UnitStatsSO> characters = new List<UnitStatsSO>();
    public UnitStatsSO nowPlayer;

    private void Start()
    {
        objectNickname.SetActive(true);
        objectJob.SetActive(false);
    }

    public void OnButtonNext()
    {
        if (inputNickname.text.Length <= 0)
        {
            animator.SetTrigger(InputError);
        }
        else
        {
            nickname = inputNickname.text;
            animator.SetTrigger(ButtonNext);
        }
    }

    public void SetCharacter(int idx)
    {
        nowPlayer.nickname = nickname;
        nowPlayer.image = characters[idx].image;
        nowPlayer.level = characters[idx].level;
        nowPlayer.MaxHp = characters[idx].MaxHp;
        nowPlayer.ap = characters[idx].ap;
        nowPlayer.dp = characters[idx].dp;
        nowPlayer.speed = characters[idx].speed;
        nowPlayer.gold = characters[idx].gold;

        SceneManager.LoadScene("MainScene");
    }
}
