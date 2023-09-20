using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string nickname;
    public static int character;

    public TextMeshProUGUI textNickname;
    public TextMeshProUGUI textLevel;

    private void Start()
    {
        textNickname.text = nickname;
    }
}
