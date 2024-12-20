using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    #region Fields and Methods

    //MAGE STATs
    float mageSTR = 6;
    float mageAGI = 10;
    float mageINT = 20;
    float mageDEX = 15;
    float mageHP = 195;
    float mageMP = 200;
    float mageMREG = 50; //Mana Regen
    float mageHC = 67.5f; //Hit Chance
    float mageDODGE = 23.5f; //Dodge Chance
    float magePDEF = 3.2f; //Physical Defense
    float mageMDEF = 12.5f; //Magic Defense
    float mageMBONUS = 30; //Magic Bonus
    float magePBONUS = 31; //Physical Bonus

    //BLACK SWORDSMAN STATs
    float swordSTR = 20;
    float swordAGI = 9;
    float swordINT = 4;
    float swordDEX = 10;
    float swordHP = 220;
    float swordMP = 120;
    float swordMREG = 30; //Mana Regen
    float swordHC = 55; //Hit Chance
    float swordDODGE = 55; //Dodge Chance
    float swordPDEF = 10.2f; //Physical Defense
    float swordMDEF = 4.5f; //Magic Defense
    float swordMBONUS = 24; //Magic Bonus
    float swordPBONUS = 40; //Physical Bonus

    //PALADIN STATs
    float paladinSTR = 15;
    float paladinAGI = 9;
    float paladinINT = 10;
    float paladinDEX = 17;
    float paladinHP = 221.5f;
    float paladinMP = 150;
    float paladinMREG = 35; //Mana Regen
    float paladinHC = 55; //Hit Chance
    float paladinDODGE = 24.3f; //Dodge Chance
    float paladinPDEF = 7.7f; //Physical Defense
    float paladinMDEF = 7.5f; //Magic Defense
    float paladinMBONUS = 20; //Magic Bonus
    float paladinPBONUS = 42; //Physical Bonus

    #endregion

    #region Character Selection
    public void selectMAGE()
    {
        //PLAYER STATS
        playerStats.playerSTR = mageSTR;
        playerStats.playerAGI = mageAGI;
        playerStats.playerINT = mageINT;
        playerStats.playerDEX = mageDEX;
        playerStats.playerHP = mageHP;
        playerStats.playerMP = mageMP;
        playerStats.playerMREG = mageMREG;
        playerStats.playerHC = mageHC;
        playerStats.playerDODGE = mageDODGE;
        playerStats.playerPDEF = magePDEF;
        playerStats.playerMDEF = mageMDEF;
        playerStats.playerMBONUS = mageMBONUS;
        playerStats.playerPBONUS = magePBONUS;

        CharacterSelected.charName = "Mage";
    }

    public void selectSWORDSMAN()
    {
        //PLAYER STATS

        playerStats.playerSTR = swordSTR;
        playerStats.playerAGI = swordAGI;
        playerStats.playerINT = swordINT;
        playerStats.playerDEX = swordDEX;
        playerStats.playerHP = swordHP;
        playerStats.playerMP = swordMP;
        playerStats.playerMREG = swordMREG;
        playerStats.playerHC = swordHC;
        playerStats.playerDODGE = swordDODGE;
        playerStats.playerPDEF = swordPDEF;
        playerStats.playerMDEF = swordMDEF;
        playerStats.playerMBONUS = swordMBONUS;
        playerStats.playerPBONUS = swordPBONUS;

        CharacterSelected.charName = "Swordsman";
    }

    public void selectPALADIN()
    {
        //PLAYER STATS

        playerStats.playerSTR = paladinSTR;
        playerStats.playerAGI = paladinAGI;
        playerStats.playerINT = paladinINT;
        playerStats.playerDEX = paladinDEX;
        playerStats.playerHP = paladinHP;
        playerStats.playerMP = paladinMP;
        playerStats.playerMREG = paladinMREG;
        playerStats.playerHC = paladinHC;
        playerStats.playerDODGE = paladinDODGE;
        playerStats.playerPDEF = paladinPDEF;
        playerStats.playerMDEF = paladinMDEF;
        playerStats.playerMBONUS = paladinMBONUS;
        playerStats.playerPBONUS = paladinPBONUS;

        CharacterSelected.charName = "Paladin";
    }

    #endregion
}
