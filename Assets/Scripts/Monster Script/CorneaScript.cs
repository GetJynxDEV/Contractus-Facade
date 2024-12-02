using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorneaScript : MonoBehaviour
{
    #region Fields and Properties

    //GOBLIN STATS
    public static float corneaHP = 209;
    public static float corneaMP = 150;

    public static float maxMP;

    float corneaSTR = 10;
    float corneaAGI = 15;
    float corneaINT = 10;
    float corneaDEX = 17;

    public static float corneaMGEN = 45;
    float corneaMS = 32.3f;
    float corneaHC = 72.5f;
    float corneaDODGE = 30.3f;
    float corneaPDEF = 2.5f;
    float corneaMDEF = 10.5f;
    float corneaPBONUS = 20;
    float corneaMBONUS = 37;
    
    #endregion

    // BATTLE SCRIPT STARTS HERE

    #region Turn Base Fight

    public void corneaTurn()
    {
        if (corneaMP > maxMP)
        {
            corneaMP = maxMP;
        }

        corneaHealthUpdate();

        corneaAttackComputation();
    }

    void corneaHealthUpdate()
    {
        if (BattleScript.isPlayerApplyBleedEffect == true)
        {
            BattleEffect.isMonsterBleeding = true;

            corneaHP -= playerStats.playerBleedEffect;

            BattleScript.isPlayerApplyBleedEffect = false;

            Debug.Log("Updated Goblin HP: " + corneaHP);
        }

    }

    void corneaAttackComputation()
    {
        float corneaBasicAtk; //Basic Attack
        float corneaPsionicBeam; //Special Attack

        //Basic Attack Computation

        corneaBasicAtk = corneaSTR + corneaINT;
        corneaPsionicBeam = corneaDEX + (corneaPBONUS * 0.2f);

        int corneaTurn = Random.Range(1, 2);

        int corneaHitChance = Random.Range(1, 5);

        corneaAttack:

        if (corneaTurn == 1)
        {
            if (corneaHitChance <= 3)
            {
                if (playerStats.isPlayerDeBuffEffect == true)
                {

                    playerStats.playerIncomingDMG = corneaBasicAtk;

                    playerStats.playerHP -= playerStats.playerDeBuff;

                    playerStats.isPlayerDeBuffEffect = false;
                }
                else
                {
                    playerStats.playerHP -= corneaBasicAtk;

                    Debug.Log("Cornea used its Tentacles!\n");
                }
            }

            else if (corneaHitChance >= 4)
            {
                BattleEffect.isMonsterMiss = true;

                Debug.Log("CORNEA MISSED!\n");
            }
        }

        if (corneaTurn == 2)
        {
            if (corneaMP >= 70)
            {
                corneaMP -= 70;

                if (corneaHitChance >= 2)
                {
                    playerStats.playerHP -= corneaPsionicBeam;
                    BattleScript.isPlayerBleeding = true;

                    Debug.Log("Cornea used Psionic Beam!\n");
                }

                else if (corneaHitChance == 1)
                {
                    BattleEffect.isMonsterMiss = true;
                    
                    Debug.Log("CORNEA MISSED");
                }
            }

            else if (corneaMP <= 59)
            {
                goto corneaAttack;
            }
        }
    }

    public void ManaRegen()
    {
        Debug.Log("Cornea regained " + corneaMGEN);

        corneaMP += corneaMGEN;

        if (maxMP >= corneaMP)
        {
            corneaMP = maxMP;
        }
    }
    #endregion
}
