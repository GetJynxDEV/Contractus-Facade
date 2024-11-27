using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    #region Fields and Properties

    //GOBLIN STATS
    public static float goblinHP = 195;
    public static float goblinMP = 110;

    float goblinSTR = 10;
    float goblinAGI = 9;
    float goblinINT = 2;
    float goblinDEX = 10;

    float goblinMGEN = 25;
    float goblinMS = 19.3f;
    float goblinHC = 55;
    float goblinDODGE = 18;
    float goblinPDEF = 2.5f;
    float goblinMDEF = 5.5f;
    float goblinPBonus = 30;
    float goblinMBonus = 12;

    //SCRIPTS
    

    #endregion

    // BATTLE SCRIPT STARTS HERE

    #region Turn Base Fight

    public void goblinTurn()
    {
        GoblinAttackComputation();
    }

    void GoblinAttackComputation()
    {
        float gobBasicAtk; //Basic Attack
        float gobRabidBite; //Special Attack

        //Basic Attack Computation

        gobBasicAtk = 25;
        gobRabidBite = 25;

        int goblinTurn = Random.Range(1, 2);

        if (goblinTurn == 1)
        {
            playerStats.playerHP -= gobBasicAtk;
        }

        if (goblinTurn == 2)
        {
            playerStats.playerHP -= gobRabidBite;
            
        }
    }

    #endregion
}
