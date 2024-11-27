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
    }

    public void Round()
    {
        Debug.Log("------------------------ROUND " + roundValue + "------------------------\n");
    }

    public void MonsterKilled() //IF MONSTER IS KILLED DESTROY GAME OBJECT
    {
        if (MonsterTrigger.isGoblin == true)
        {
            if (GoblinScript.goblinHP == 0)
            {
                Destroy(MonsterNPC.GoblinNPC);

                SceneManager.LoadSceneAsync("scn TOWN");
            }
        }
    }
}
