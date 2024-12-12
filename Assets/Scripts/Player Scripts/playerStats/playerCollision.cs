using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
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
            Debug.Log("PLAYER COLLIDED WITH GOBLIN\n");

            MonsterTrigger.isGoblin = true;

            SceneManager.LoadSceneAsync("scn BATTLE");
        }

        if (collision.gameObject.name == "Cornea")
        {
            Debug.Log("PLAYER COLLIDED WITH CORNEA\n");

            MonsterTrigger.isCornea = true;

            SceneManager.LoadSceneAsync("scn BATTLE");
        }

        if (collision.gameObject.name == "Facade")
        {
            Debug.Log("PLAYER COLLIDED WITH FACADE\n");

            MonsterTrigger.isFacade = true;

            SceneManager.LoadSceneAsync("scn BATTLE");
        }

        if (collision.gameObject.name == "SoundCollider")
        {
            audioTownManager.isCry = true;
        }
    }

#endregion
}
