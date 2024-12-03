using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public static bool MonsterTriggered = false;

    public GameObject facadeConfront;

    public void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.name == "Player")
        {
            CameraShake.MonsterTrigger = true;

            Destroy(facadeConfront);
        }
    }
}
