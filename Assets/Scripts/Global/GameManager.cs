using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }
}
