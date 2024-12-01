using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTurn : MonoBehaviour
{
    int roundValue = 0;

    public SaveLoad loadPos;
    public void Start ()
    {
        roundValue++;

        Round();

        MonsterKilled();
    }

    public void Round()
    {
        Debug.Log("------------------------ROUND " + roundValue + "------------------------\n");
    }


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

                SceneManager.LoadSceneAsync("scn TOWN");  
            }
        }
    }

    public void PlayerWins()
    {
        playerStats.playerHP = playerStats.adminHP;
    }
}
