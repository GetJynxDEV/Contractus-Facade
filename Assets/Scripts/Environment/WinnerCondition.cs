using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCondition : MonoBehaviour
{
    #region 

    public static bool isWinner = false;
    public static bool isLoser = false;

    public GameObject WinPanel;
    public GameObject LosePanel;

    void Start()
    {

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
