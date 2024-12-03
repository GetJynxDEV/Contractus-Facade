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
    public GameObject CorneaFightScene;
    public GameObject FacadeFightScene;

#endregion

#region Start and Update
    void Update()
    {
        if (isGoblin == true)
        {
            GoblinFightPanel();
        }

        else if (isGoblin == false)
        {
            GoblinFightScene.SetActive(false);
        }

        if (isCornea == true)
        {
            CorneaFightPanel();
        }

        else if (isCornea == false)
        {
            CorneaFightScene.SetActive(false);
        }

        if (isFacade == true)
        {
            FacadeFightPanel();
        }

        else if (isFacade == false)
        {
            FacadeFightScene.SetActive(false);
        }
    }

#endregion


#region Monster Fight Scene
    void GoblinFightPanel()
    {
            GoblinFightScene.SetActive(true);

    }

    void GoblinDeath()
    {
        GoblinFightScene.SetActive(false);
    }

    void CorneaFightPanel()
    {
            GoblinFightScene.SetActive(true);

    }

    void FacadeFightPanel()
    {
            GoblinFightScene.SetActive(true);

    }
#endregion


}
