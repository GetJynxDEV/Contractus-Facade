using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterTrigger : MonoBehaviour
{
#region Fields and Properties

    //GAME OBJECT

    //SCRIPT


#endregion

#region Start and Update


#endregion


#region Player Collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Goblin")
        {
            Debug.Log("PLAYER COLLIDED WITH GOBLIN");

            BattleScript.isGoblin = true;

            SceneManager.LoadSceneAsync("scn BATTLE");
            

        }
    }

#endregion
}
