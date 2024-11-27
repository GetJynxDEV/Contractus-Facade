using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    #region Fields and Properties
    //PLAYER STATS
    
    public static string playerClass;

    float maxHP = playerHP;


    public static float playerSTR;
    public static float playerAGI;
    public static float playerINT;
    public static float playerDEX;
    public static float playerHP;
    public static float playerMP;
    public static float playerMREG;
    public static float playerHC;
    public static float playerDODGE;
    public static float playerPDEF;
    public static float playerMDEF;
    public static float playerPBONUS;
    public static float playerMBONUS;
    
    public static float playerBattack;

    public static float playerSattack1; //Special Attack 1
    public static float playerSattack2; //Special Attack 2

    public static string playerSattackName1;
    public static string playerSattackName2;

    public static float playerIncomingDMG; //This refers to ENEMY DAMAGE

    public static float playerDeBuff;
    public static bool isPlayerDeBuffEffect = false;
    public static float playerBleedEffect;
    public static bool isPlayerBleedEffect = false;

    #endregion

    #region Computation

    public void Start ()
    {

        ComputationUpdate();
        
        
        //--------------------------- ANNOUNCEMENT ------------------------
        playerClass = CharacterSelected.charName;

        Debug.Log("PLAYER BASIC ATTACK: " + playerBattack + "\n");
        Debug.Log("PLAYER SPECIAL ATTACK " + playerSattackName1 + ": " + playerSattack1 + "\n");
        Debug.Log("PLAYER SPECIAL ATTACK " + playerSattackName2 + ": " + playerSattack2 + "\n");
    }

    void ComputationUpdate()
    {
        //--------------------------- COMPUTATION ------------------------

        if (playerClass == "Mage")
        {
            //Basic Attack 

            double basicAttack = playerINT + ((playerMBONUS + playerDEX) * 0.1 );
            playerBattack = (float)basicAttack;

            //Special Attack 1

            playerSattackName1 = "Plasma Ball"; //Mana Cost 60

            double specialAttack1 = playerMBONUS + ((playerINT + playerDEX) * 0.1);

            playerSattack1 = (float)specialAttack1;

            //Special Attack2

            playerSattackName2 = "Lightning Strike"; //Mana Cost 150

            double specialAttack2 = ((playerMBONUS + playerINT) * 0.8) + playerDEX;

            playerSattack2 = (float)specialAttack2;
        }

        else if (playerClass == "Paladin")
        {
            //Basic Attack

            double basicAttack = playerSTR + (playerPBONUS * 0.2);
            playerBattack = (float)basicAttack;

            //Special Attack 1

            playerSattackName1 = "Penance"; //Mana Cost 65

            double specialAttack1 = playerMBONUS + playerINT * (playerSTR * 0.5);
            playerSattack1 = (float)specialAttack1;

            double debuff = playerIncomingDMG - ( playerIncomingDMG * 0.3);
            playerDeBuff = (float)debuff;
            
            //Special Attack 2

            playerSattackName2 = "Holy Rain"; //Mana Cost 110

            double specialAttack2 = ((playerMBONUS + playerSTR) * 0.25) * 5;
            playerSattack2 = (float)specialAttack2;
        }

        else if (playerClass == "Swordsman")
        {
            //Basic Attack

            double basicAttack = playerSTR + (playerPBONUS * 0.2);
            playerBattack = (float)basicAttack;

            //Special Attack 1

            playerSattackName1 = "Berserk Slash"; //Mana Cost 50

            double specialAttack1 = playerSTR + ( playerPBONUS * 0.2) * 2;
            playerSattack1 = (float)specialAttack1;

            //Special Attack 2

            playerSattackName2 = "Pierce Strike"; //Mana Cost 100

            double specialAttack2 = playerSTR + ( playerPBONUS / 2);

            playerSattack2 = (float)specialAttack2;

            double bleedDMG = (playerPBONUS - 0.2) / 2;

            playerBleedEffect = (float)bleedDMG;
        }

    }

    #endregion
}
