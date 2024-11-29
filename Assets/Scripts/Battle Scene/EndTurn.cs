using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTurn : MonoBehaviour
{
    int roundValue = 0;
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

    public void ManaRegen()
    {
        Debug.Log("You regained " + playerStats.playerMREG + "MP\n");

        playerStats.playerMP += playerStats.playerMREG;

        if (BattleScript.maxMP >= playerStats.playerMP)
        {
            playerStats.playerMP = BattleScript.maxMP;
        }
        
        else
        {
            
        }

        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin regained " + GoblinScript.goblinMGEN + "MP\n");

            GoblinScript.goblinMP += GoblinScript.goblinMGEN;

            if (GoblinScript.maxMP >= GoblinScript.goblinMP)
            {
                GoblinScript.goblinMP = GoblinScript.maxMP;
            }
            
            else
            {
                
            }
        }
        


    }

    public void MonsterKilled() //IF MONSTER IS KILLED DESTROY GAME OBJECT
    {
        if (playerStats.playerHP <= 0)
        {
            SceneManager.LoadSceneAsync("scn TOWN");

            Debug.LogWarning("YOU LOST!\n");
        }

        if (MonsterTrigger.isGoblin == true)
        {
            if (GoblinScript.goblinHP <= 0)
            {
                Destroy(MonsterNPC.GoblinNPC);

                Debug.Log("You Killed the Goblin!");

                SceneManager.LoadSceneAsync("scn TOWN");
            }
        }
    }
}