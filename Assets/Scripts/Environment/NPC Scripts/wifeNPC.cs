using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifeNPC : MonoBehaviour
{
    [Header("NPC")]

    [SerializeField] public GameObject WifeNPC;

    [Header("ICON")]

    [SerializeField] public GameObject wifeNotif;

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
                closeDialogue.isWife = true;
            }
        }
    }

    //ON TRIGGER COLLIDER
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        { 
            isNear = true;
            wifeNotif.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isNear = false;
        wifeNotif.SetActive(false);
    }
}
