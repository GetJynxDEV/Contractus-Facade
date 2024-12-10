using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class closeDialogue : MonoBehaviour
{
    public static bool isTalking = false;

    public static bool isWife = false;

    public static bool isKnight = false;

    public static bool isInformat = false;
    
    public static bool isLeader = false;

    [Header("DIALOGUE UI")]

    [SerializeField] public GameObject DialogueUI;

    [Header("TEXTMESH PRO")]
    
    [SerializeField] public TextMeshProUGUI dialoguesText;

    public static string Dialogues;

    void Update()
    {
        if (isTalking == true)
        {
            playerMovement.movementSpeed = 0;

            openUI();
        }

        if (isTalking == false)
        {
            Dialogues = "";
            DialogueUI.SetActive(false); 
        }
    }

    public void openUI()
    {
        if (isWife == true)
        {
            Dialogues = "I haven't seen my husband ever since he went to that Cave";
            dialoguesText.text = Dialogues;
            DialogueUI.SetActive(true);
        }

        else if (isKnight == true)
        {
            Dialogues = "Adventurer beyond this Path lies Monsters in the Forest";
            dialoguesText.text = Dialogues;
            DialogueUI.SetActive(true);
        }

        else if (isInformat == true)
        {
            Dialogues = "Go above the Market and you'd find what you're looking for";
            dialoguesText.text = Dialogues;
            DialogueUI.SetActive(true);
        }

        else if (isLeader == true)
        {
            Dialogues = "Adventurer follow the Signs....";
            dialoguesText.text = Dialogues;
            DialogueUI.SetActive(true);
        }
        
    }

    public void closeUI()
    {
        playerMovement.movementSpeed = 3;

        isWife = false;
        isKnight = false;
        isInformat = false;
        isLeader = false;

        isTalking = false;

        Dialogues = "";
        dialoguesText.text = "";
        DialogueUI.SetActive(false); 
    }
}
