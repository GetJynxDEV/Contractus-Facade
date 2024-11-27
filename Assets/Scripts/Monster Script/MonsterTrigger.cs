using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
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
            //SaveLoad.Save();
            GoblinFightPanel();
        }
    }

#endregion


#region Monster Fight Scene
    void GoblinFightPanel()
    {
            GoblinFightScene.SetActive(true);

    }

#endregion


}
