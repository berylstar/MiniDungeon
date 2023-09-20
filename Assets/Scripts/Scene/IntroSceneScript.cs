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

    [Header("Job")]
    [SerializeField] GameObject objectJob;

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
            GameManager.nickname = inputNickname.text;
            animator.SetTrigger(ButtonNext);
        }
    }

    public void SetJob(int idx)
    {
        //switch (idx)
        //{
        //    case 0:
        //        Debug.Log("검사");
        //        break;

        //    case 1:
        //        Debug.Log("전사");
        //        break;

        //    case 2:
        //        Debug.Log("도적");
        //        break;
        //}
        GameManager.character = idx;
        SceneManager.LoadScene("MainScene");
    }
}
