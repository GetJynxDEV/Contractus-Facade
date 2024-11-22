using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterTrigger : MonoBehaviour
{
    playerMovement plyMS;

    #region Player Collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        //miniBoss.fightPanelScene();

        if (collision.gameObject.name == "enemy1")
        {
            Debug.Log("First Monster Hit");
            
        }
    }

    #endregion
}
