using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [Header("GAME OBJECT")]
    [SerializeField] public GameObject STRPotion;
    [SerializeField] public GameObject MagicUpPotion;
    [SerializeField] public GameObject HealthPotion;
    [SerializeField] public GameObject ManaPotion;
    [SerializeField] public GameObject Key;

    [Header("Buttons")]
    [SerializeField] public GameObject STRBtn;
    [SerializeField] public GameObject MagicUpBtn;
    [SerializeField] public GameObject HealthBtn;
    [SerializeField] public GameObject ManaBtn;
    [SerializeField] public GameObject KeyBtn;

    //GAME OBJECT AMOUNT
    public static int STRAmount;
    public static int MGUPAmount;
    public static int HPPotionAmount;
    public static int MPPotionAmount;
    public static int KeyAmount;

    [Header("TMPRO")]

    [SerializeField] public TextMeshProUGUI Name;
    [SerializeField] public TextMeshProUGUI Desc;

    //STRING FOR TMPRO
    string STRName = "STRENGTH POTION";
    string STRDesc = "Increases your Strength Damage by 25 for a short duration of time";

    string MGUPName = "Magic Up Potion";
    string MGUPDesc = "Increases your Magic Damage by 25 for a short duration of time";

    string HPName = "Health Potion";
    string HPDesc = "Gives you 30 Health";

    string MPName = "Mana Potion";
    string MPDesc = "Gives you 30 Mana";

    string KeyName = "Dungeon Key";
    string KeyDesc = "Who knows what it can Unlock";

    //SCENE BOOLEAN
    public static bool isTown = false;
    public static bool isBattle = false;

    //POTION BOOLEAN

    bool isSTR = false;
    bool isMGU = false;
    bool isHP = false;
    bool isMP = false;
    bool isKey = false;

    void Start()
    {
        Name.text = "";
        Desc.text = "";
    }

    void Update()
    {
        //STR POTION

        if (STRAmount >= 1)
        {
            STRPotion.SetActive(true);
        }

        else if (STRAmount == 0)
        {
            STRPotion.SetActive(false);
        }

        //MAGIC UP POTION

        if (MGUPAmount >= 1)
        {
            MagicUpPotion.SetActive(true);
        }

        else if (MGUPAmount == 0)
        {
            MagicUpPotion.SetActive(false);
        }

        //HEALTH POTION

        if (HPPotionAmount >= 1)
        {
            HealthPotion.SetActive(true);
        }

        else if (HPPotionAmount == 0)
        {
            HealthPotion.SetActive(false);
        }

        //MANA POTION

        if (MPPotionAmount >= 1)
        {
            ManaPotion.SetActive(true);
        }

        else if (MPPotionAmount == 0)
        {
            ManaPotion.SetActive(false);
        }
        
        //KEY

        if (KeyAmount >= 1)
        {
            Key.SetActive(true);
        }

        else if (KeyAmount == 0)
        {
            Key.SetActive(false);
        }

    }

    public void confirmBtn()
    {
        if (isSTR == true)
        {
            if (isTown == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
                playerStats.isSTRPotion = false;
            }

            if (isBattle == true)
            {
                playerStats.isSTRPotion = true;
            }
        }

        if (isMGU == true)
        {
            if (isTown == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
                playerStats.isMGUPPotion = false;
            }

            if (isBattle == true)
            {
                playerStats.isMGUPPotion = true;
            }
        }

        if (isHP == true)
        {
            if (isTown == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
            }

            if (isBattle == true)
            {
                playerStats.playerHP += 30;
            }
        }

        if (isMP == true)
        {
            if (isTown == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
            }

            if (isBattle == true)
            {
                playerStats.playerMP += 30;
            }
        }

        if (isKey == true)
        {
            if (isTown == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
            }

            if (isBattle == true)
            {
                Name.text = "";
                Desc.text = "IT'S NOT THE RIGHT TIME TO USE THAT HERE!";
            }
        }
        
    }

    public void clearBtn()
    {
        isSTR = false;
        isMGU = false;
        isHP = false;
        isMP = false;
        isKey = false;
    }

//POTIONS

    public void strBtn()
    {
        Name.text = STRName;
        Desc.text = STRDesc;
    }

    public void mgupBtn()
    {
        Name.text = MGUPName;
        Desc.text = MGUPDesc;
    }

    public void hpBtn()
    {
        Name.text = HPName;
        Desc.text = HPDesc;
    }


    public void mpBtn()
    {
        Name.text = MPName;
        Desc.text = MPDesc;
    }

    public void keyBtn()
    {
        Name.text = KeyName;
        Desc.text = KeyDesc;
    }
    
}
