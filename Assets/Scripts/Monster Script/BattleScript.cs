using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{

#region Fields and Properties

    //BOOL
    public static bool isGoblin = false;    

    //GAME OBJECT
    public GameObject GoblinFightScene;

#endregion

#region Start and Update
    void Start()
    {
        if (isGoblin == true)
        {
            GoblinFightPanel();
        }
    }

#endregion


#region Monster Fight Scene
    void GoblinFightPanel()
    {
            Debug.Log("FIGHT SCENE ACTIVATED");
            GoblinFightScene.SetActive(true);

    }

#endregion


}
