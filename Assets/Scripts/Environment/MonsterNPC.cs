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
            Destroy(GoblinNPC);
        }

        if (isCorneaDead == true)
        {
            Destroy(GoblinNPC);
        }

        if (isFacadeDead == true)
        {
            Destroy(GoblinNPC);
        }
    }
}
