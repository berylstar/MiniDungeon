using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }

    public void ReStart()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
