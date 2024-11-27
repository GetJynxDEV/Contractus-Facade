using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNPC : MonoBehaviour
{
    public static GameObject GoblinNPC;
    public static GameObject CorneaNPC;
    public static GameObject FacadeNPC;

    void Start()
    {
        GoblinNPC = GameObject.Find("Goblin");
        CorneaNPC = GameObject.Find("Cornea");
        FacadeNPC = GameObject.Find("Facade");
    }
}
