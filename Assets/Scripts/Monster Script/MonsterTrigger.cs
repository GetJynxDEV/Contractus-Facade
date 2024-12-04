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

    void Start()
    {
        if (isGoblin == true)
        {
            GoblinFightPanel();
        }

        else if (isGoblin == false && MonsterNPC.isGoblinDead == true)
        {
            GoblinFightScene.SetActive(false);
        }

        if (isCornea == true)
        {
            CorneaFightPanel();
        }

        else if (isCornea == false && MonsterNPC.isCorneaDead == true)
        {
            CorneaFightScene.SetActive(false);
        }

        if (isFacade == true)
        {
            FacadeFightPanel();
        }

        else if (isFacade == false && MonsterNPC.isFacadeDead == true)
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
        CorneaFightScene.SetActive(true);

    }

    void FacadeFightPanel()
    {
        FacadeFightScene.SetActive(true);

    }
#endregion


}
