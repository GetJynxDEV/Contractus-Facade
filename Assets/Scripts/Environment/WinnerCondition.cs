using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCondition : MonoBehaviour
{
    #region 

    public static bool isWinner = false;
    public static bool isLoser = false;

    GameObject WinPanel;
    GameObject LosePanel;

    void Start()
    {
        WinPanel = GameObject.Find("Win");
        LosePanel = GameObject.Find("Lose");

        if (isWinner == true)
        {
            WinPanel.SetActive(true);
        }

        if (isLoser == true)
        {
            LosePanel.SetActive(true);
        }

    }

    #endregion
}
