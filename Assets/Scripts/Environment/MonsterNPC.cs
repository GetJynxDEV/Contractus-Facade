using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNPC : MonoBehaviour
{
    public static GameObject GoblinNPC;
    public static GameObject CorneaNPC;
    public static GameObject FacadeNPC;

    public static bool isGoblinDead = false;
    public static bool isCorneaDead = false;
    public static bool isFacadeDead = false;

    void Start()
    {
        GoblinNPC = GameObject.Find("Goblin");
        CorneaNPC = GameObject.Find("Cornea");
        FacadeNPC = GameObject.Find("Facade");

        //Checks if Monster is Dead then Destroy Game Object
        
        if (isGoblinDead == true)
        {
            Debug.Log("GOBLIN IS DEAD");
            Destroy(GoblinNPC);
        }

        if (isCorneaDead == true)
        {
            Debug.Log("CORNEA IS DEAD");
            Destroy(GoblinNPC);
        }

        if (isFacadeDead == true)
        {
            Debug.Log("FACADE IS DEAD");
            Destroy(GoblinNPC);
        }
    }
}
