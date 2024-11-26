using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{

#region Fields and Properties

    //BOOL
    public static bool isGoblin = false;    
    public static bool isCornea = false;
    public static bool isFacade = false;

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
