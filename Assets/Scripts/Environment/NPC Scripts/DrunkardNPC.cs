using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkardNPC : MonoBehaviour
{
    [Header("NPC")]

    [SerializeField] public GameObject npc;

    [Header("ICON")]

    [SerializeField] public GameObject notif;

    //BOOLEAN
    bool isNear = false;

    //UPDATE
    void Update()
    {
        if (isNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("HELLO");
                
                closeDialogue.isTalking = true;
                closeDialogue.isInformat = true;
            }
        }
    }

    //ON TRIGGER COLLIDER
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        { 
            isNear = true;
            notif.SetActive(true);
        }

        else
        {
            isNear = false;
            notif.SetActive(false);
        }
    }
}
