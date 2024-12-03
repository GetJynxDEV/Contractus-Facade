using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    #region Fields and Properties

    //GOBLIN STATS
    public static float goblinHP = 195;
    public static float goblinMP = 110;

    public static float maxMP;

    float goblinSTR = 10;
    float goblinAGI = 9;
    float goblinINT = 2;
    float goblinDEX = 10;

    public static float goblinMGEN = 25;
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

    void Start()
    {
        BattleScript.isForest = true;
    }

    public void goblinTurn()
    {
        if (goblinMP > maxMP)
        {
            goblinMP = maxMP;
        }

        goblinHealthUpdate();

        GoblinAttackComputation();
    }

    void goblinHealthUpdate()
    {
        if (BattleScript.isPlayerApplyBleedEffect == true)
        {
            BattleEffect.isMonsterBleeding = true;

            goblinHP -= playerStats.playerBleedEffect;

            BattleScript.isPlayerApplyBleedEffect = false;

            Debug.Log("Updated Goblin HP: " + goblinHP);
        }

    }

    void GoblinAttackComputation()
    {
        float gobBasicAtk; //Basic Attack
        float gobRabidBite; //Special Attack

        //Basic Attack Computation

        gobBasicAtk = 16;
        gobRabidBite = 25;

        int goblinTurn = Random.Range(1, 2);

        int gobHitChance = Random.Range(1, 5);

        gobAttack:

        if (goblinTurn == 1)
        {
            if (gobHitChance <= 3)
            {
                if (playerStats.isPlayerDeBuffEffect == true)
                {

                    playerStats.playerIncomingDMG = gobBasicAtk;

                    playerStats.playerHP -= playerStats.playerDeBuff;

                    playerStats.isPlayerDeBuffEffect = false;
                }
                else
                {
                    playerStats.playerHP -= gobBasicAtk;

                    Debug.Log("Goblin used Club Smash!\n");
                }
            }

            else if (gobHitChance >= 4)
            {
                BattleEffect.isMonsterMiss = true;

                Debug.Log("GOBLIN MISSED!\n");
            }
        }

        if (goblinTurn == 2)
        {
            if (goblinMP >= 60)
            {
                goblinMP -= 60;

                if (gobHitChance >= 2)
                {
                    playerStats.playerHP -= gobRabidBite;
                    BattleScript.isPlayerBleeding = true;

                    Debug.Log("Goblin used Rabid Bite!\n");
                }

                else if (gobHitChance == 1)
                {
                    BattleEffect.isMonsterMiss = true;
                    
                    Debug.Log("GOBLIN MISSED");
                }
            }

            else if (goblinMP <= 59)
            {
                goto gobAttack;
            }
        }
    }

    public void ManaRegen()
    {
        Debug.Log("Goblin regained " + goblinMGEN);

        goblinMP += goblinMGEN;

        if (maxMP >= goblinMP)
        {
            goblinMP = maxMP;
        }
    }

    #endregion
}
