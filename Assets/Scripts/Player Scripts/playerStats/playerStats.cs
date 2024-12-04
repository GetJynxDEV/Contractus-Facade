using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    #region Fields and Properties
    //PLAYER STATS
    
    public static string playerClass;

    public static float maxHP = playerHP;
    public static float currentHP;


    public static float playerSTR;
    public static float playerAGI;
    public static float playerINT;
    public static float playerDEX;
    public static float playerHP = 200;
    public static float playerMP = 200;
    public static float playerMREG;
    public static float playerHC;
    public static float playerDODGE;
    public static float playerPDEF;
    public static float playerMDEF;
    public static float playerPBONUS;
    public static float playerMBONUS;

    public static float adminHP;
    public static float adminMP;

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

    public static bool isSTRPotion = false;
    public static bool isMGUPPotion = false;

    #endregion

    #region Computation
    public void Start ()
    {
        playerClass = CharacterSelected.charName;
        
        currentHP = maxHP;

        adminHP = playerHP;

        adminMP = playerMP;

        ComputationUpdate();
        
        
        //--------------------------- ANNOUNCEMENT ------------------------
        
        Debug.Log("PLAYER HELATH: " + playerHP + "\n");
        Debug.Log("PLAYER BASIC ATTACK: " + playerBattack + "\n");
        Debug.Log("PLAYER SPECIAL ATTACK " + playerSattackName1 + ": " + playerSattack1 + "\n");
        Debug.Log("PLAYER SPECIAL ATTACK " + playerSattackName2 + ": " + playerSattack2 + "\n");
    }

    void ComputationUpdate()
    {
        //--------------------------- COMPUTATION ------------------------

        if (isSTRPotion == true)
        {
            playerSTR += 30;
        }

        if (playerClass == "Mage")
        {
            //Basic Attack 

            playerBattack = playerINT + ((playerMBONUS + playerDEX) * 0.1f );

            //Special Attack 1

            playerSattackName1 = "Plasma Ball"; //Mana Cost 60

            playerSattack1 = playerMBONUS + ((playerINT + playerDEX) * 0.1f);

            //Special Attack2

            playerSattackName2 = "Lightning Strike"; //Mana Cost 150

            playerSattack2 = ((playerMBONUS + playerINT) * 0.8f) + playerDEX;
        }

        else if (playerClass == "Paladin")
        {
            //Basic Attack

            playerBattack = playerSTR + (playerPBONUS * 0.2f);

            //Special Attack 1

            playerSattackName1 = "Penance"; //Mana Cost 65

            playerSattack1 = playerMBONUS + (playerSTR * 0.5f);

            playerDeBuff = playerIncomingDMG - ( playerIncomingDMG * 0.3f);
            
            //Special Attack 2

            playerSattackName2 = "Holy Rain"; //Mana Cost 110

            playerSattack2 = ((playerMBONUS + playerSTR) * 0.25f) * 5;
        }

        else if (playerClass == "Swordsman")
        {
            //Basic Attack

            playerBattack = playerSTR + (playerPBONUS * 0.2f);

            //Special Attack 1

            playerSattackName1 = "Berserk Slash"; //Mana Cost 50

            playerSattack1 = playerSTR + ( playerPBONUS * 0.2f) * 2;

            //Special Attack 2

            playerSattackName2 = "Pierce Strike"; //Mana Cost 100

            playerSattack2 = playerSTR + ( playerPBONUS / 2);

            playerBleedEffect = (playerPBONUS - 0.2f) / 2;
        }

    }

    public void StrenghtPotion()
    {
        if (isSTRPotion == true)
        {
            isSTRPotion = false;

            playerSTR -= 30;
        }
    }
    #endregion
}
