using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacadeScript : MonoBehaviour
{
    #region Fields and Properties

    //GOBLIN STATS
    public static float facadeHP = 250;
    public static float facadeMP = 180;

    public static float maxMP;

    float facadeSTR = 20;
    float facadeAGI = 15;
    float facadeINT = 16;
    float facadeDEX = 25;

    public static float facadeMGEN = 40;
    float facadeMS = 40.3f;
    float facadeHC = 92.5f;
    float facadeDODGE = 37.5f;
    float facadePDEF = 4.5f;
    float facadeMDEF = 40.5f;
    float facadePBONUS = 26;
    float facadeMBONUS = 55;
    
    #endregion

    // BATTLE SCRIPT STARTS HERE

    #region Turn Base Fight

    public void facadeTurn()
    {
        if (facadeMP > maxMP)
        {
            facadeMP = maxMP;
        }

        facadeHealthUpdate();

        facadeAttackComputation();
    }

    void facadeHealthUpdate()
    {
        if (BattleScript.isPlayerApplyBleedEffect == true)
        {
            BattleEffect.isMonsterBleeding = true;

            facadeHP -= playerStats.playerBleedEffect;

            BattleScript.isPlayerApplyBleedEffect = false;

            Debug.Log("Updated Goblin HP: " + facadeHP);
        }

    }

    void facadeAttackComputation()
    {
        float facadeBasicAtk; //Basic Attack
        float facadeEldrich; //Special Attack

        //Basic Attack Computation

        facadeBasicAtk = facadeSTR + (facadeDEX * 2);
        facadeEldrich = facadeMBONUS + (facadeINT * 3);

        int facadeTurn = Random.Range(1, 2);

        int facadeHitChance = Random.Range(1, 3);

        facadeAttack:

        if (facadeTurn == 1)
        {
            if (facadeHitChance >= 2)
            {
                if (playerStats.isPlayerDeBuffEffect == true)
                {

                    playerStats.playerIncomingDMG = facadeBasicAtk;

                    playerStats.playerHP -= playerStats.playerDeBuff;

                    playerStats.isPlayerDeBuffEffect = false;

                    
                }
                else
                {
                    playerStats.playerHP -= facadeBasicAtk;

                    Debug.Log("Facade used Punch!\n");
                }
            }

            else if (facadeHitChance == 1)
            {
                BattleEffect.isMonsterMiss = true;

                Debug.Log("FACADE MISSED!\n");
            }
        }

        if (facadeTurn == 2)
        {
            if (facadeMP >= 60)
            {
                facadeMP -= 60;

                if (facadeHitChance >= 2)
                {
                    playerStats.playerHP -= facadeEldrich;
                    BattleScript.isPlayerBleeding = true;

                    Debug.Log("Facade used Eldrich Shock!\n");
                }

                else if (facadeHitChance == 1)
                {
                    BattleEffect.isMonsterMiss = true;
                    
                    Debug.Log("FACADE MISSED!\n");
                }
            }

            else if (facadeMP <= 59)
            {
                goto facadeAttack;
            }
        }
    }

    public void ManaRegen()
    {
        Debug.Log("FACADE regained " + facadeMGEN);

        facadeMP += facadeMGEN;

        if (maxMP >= facadeMP)
        {
            facadeMP = maxMP;
        }
    }
    #endregion
}
