using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTurn : MonoBehaviour
{
    [SerializeField] public GameObject EndTurnButton;
    [SerializeField] public GameObject EndTurnButtonCornea;
    [SerializeField] public GameObject EndTurnButtonFacade;
    [SerializeField] public GameObject FadeIn;
    playerStats PlayerStats;
    

    int roundValue = 0;

    public void Start ()
    {
        roundValue++;

        Round();

        MonsterKilled();

        if (playerStats.isSTRPotion == true)
        {
            PlayerStats.StrenghtPotion();
        }
    }

    public void Round()
    {
        Debug.Log("------------------------ROUND " + roundValue + "------------------------\n");
    }

    public void EndTurnAnim()
    {
        Invoke("EndTurnBtn", 3);
    }

    void EndTurnBtn()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            EndTurnButton.SetActive(true);
        }

        else if (MonsterTrigger.isGoblin == false)
        {
            EndTurnButton.SetActive(false);
        }

        if (MonsterTrigger.isCornea == true)
        {
            EndTurnButtonCornea.SetActive(true);
        }

        else if (MonsterTrigger.isCornea == false)
        {
            EndTurnButtonCornea.SetActive(false);
        }

        if (MonsterTrigger.isFacade == true)
        {
            EndTurnButtonFacade.SetActive(true);
        }

        else if (MonsterTrigger.isFacade == false)
        {
            EndTurnButtonFacade.SetActive(false);
        }
        
    }

#region Win Condition
    public void MonsterKilled() //IF MONSTER IS KILLED DESTROY GAME OBJECT
    {
        if (playerStats.playerHP <= 0)
        {
            WinnerCondition.isLoser = true;

            SceneManager.LoadSceneAsync("scn EndGame");

            Debug.LogWarning("YOU LOST!\n");
        }

        if (MonsterTrigger.isGoblin == true)
        {
            if (GoblinScript.goblinHP <= 0)
            {
                PlayerWins();

                MonsterNPC.isGoblinDead = true;

                Debug.Log("Goblin Killed\n");

                FadeIn.SetActive(true);

                Invoke("PlayerWins", 3);
            }
        }

        if (MonsterTrigger.isCornea == true)
        {
            if (CorneaScript.corneaHP <= 0)
            {
                PlayerWins();

                MonsterNPC.isCorneaDead = true;

                Debug.Log("Cornea Killed\n");

                FadeIn.SetActive(true);

                Invoke("PlayerWins", 3);
            }
        }

        if (MonsterTrigger.isFacade == true)
        {
            if (FacadeScript.facadeHP <= 0)
            {
                PlayerWins();

                MonsterNPC.isFacadeDead = true;

                Debug.Log("Cornea Killed\n");

                FadeIn.SetActive(true);

                Invoke("PlayerWins", 3);
            }
        }
        
    }

    public void PlayerWins()
    {
        
        playerStats.playerHP = playerStats.adminHP;

        SceneManager.LoadSceneAsync("scn TOWN"); 
    }

    #endregion
}
