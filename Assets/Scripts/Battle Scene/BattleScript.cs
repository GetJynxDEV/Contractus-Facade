using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class BattleScript : MonoBehaviour
{
    #region Field and Properties

    [Header("TMPRO")]
    [SerializeField] public TextMeshProUGUI hpTextValue; //Health Bar Text Value
    [SerializeField] public TextMeshProUGUI mpTextValue; //Mana Points Text Value

    [SerializeField] public TextMeshProUGUI textMove; //Reference the Player and Monster Move Name
    [SerializeField] public TextMeshProUGUI textDesc; //Reference the Player and Monster Move

    [Header("AVATAR SPRITES")]
    [SerializeField] public Sprite MageSprite;
    [SerializeField] public Sprite PaladinSprite;
    [SerializeField] public Sprite SwordsmanSprite;

    [Header("ENEMY GAME OBJECT")]
    [SerializeField] public GameObject GoblinEnemy;
    [SerializeField] public GameObject CorneaEnemy;
    [SerializeField] public GameObject FacadeEnemy;

    [Header("Attack Button")]

    [SerializeField] public GameObject specialAtkBtn1;
    [SerializeField] public GameObject specialAtkBtn2;

    

    public HealthBarScript healthBar;

    string hpText; //Health Bar Text
    string mpText; //Mana Points Text

    string moveName;
    string moveDesc;

    public static float currentHP; //Current HP
    public static float currentMP; //Current MP

    int hpValue;

    public static float maxHP;
    public static float maxMP;

    float basicDMG; //Player Basic Damage
    float specialAttack; //Player Special Attack

    public static float bleedDMG;

    public static bool isPlayerBleeding = false; //IF Player has Bleed Effect
    public static bool isPlayerApplyBleedEffect = false;
    public static bool isPlayerBuffEffect = false;

    string characterName = CharacterSelected.charName;
    GameObject Player; //References the Player Game Object

    HealthBarScript hpBar;

    #endregion

    #region Methods

    void Start()
    {
        hpValue = (int)currentHP;

        maxMP = playerStats.playerMP;

        hpBar.SetMaxHealth(hpValue);

        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("YOUR ENEMY IS A GOBLIN!\n");
            GoblinEnemy.SetActive(true);
            CorneaEnemy.SetActive(false);
            FacadeEnemy.SetActive(false);

            Debug.Log("------------------------------------\n");
        }

        StatsUpdate();

        

        Player = GameObject.Find("Avatar");

        //THE SWITCH CASE WILL FIND WHICH CHARACTER IS ACTIVATED
        //THEN THE AVATAR GAME OBJECT WILL SHOW WHICH IS ACTIVATED
        switch (characterName)
        {
            case "Mage":

                Player.GetComponent<SpriteRenderer>().sprite = MageSprite;
                break;
            
            case "Swordsman":

                Player.GetComponent<SpriteRenderer>().sprite = SwordsmanSprite;
                break;

            case "Paladin":

                Player.GetComponent<SpriteRenderer>().sprite = PaladinSprite; 
                break;
        }

    }

    void Update()
    {
        hpValue = (int)currentHP;

        hpText = currentHP.ToString(); //current HP to Text

        hpTextValue.text = hpText;

        mpText = currentMP.ToString(); //current MP to Text

        mpTextValue.text = mpText;


    }

    

    public void StatsUpdate()
    {

        //CHECKS CURRENT HEALTH AND MP

        currentHP = playerStats.playerHP;
        currentMP = playerStats.playerMP;

        hpBar.SetHealth(hpValue);

        moveDesc = "What will you do?"; //Default Move Description Name
        moveName = ""; //Default Move Name 

        //CHECK PLAYER HEALTH
        Debug.Log("Player's Current HP is " + currentHP + "\n");

        //CHECK ENEMY HEALTH
        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin's Current HP is " + GoblinScript.goblinHP + "\n");
        }

        if (isPlayerBleeding == true) //Goblin's Bleed Effect
        {
            playerStats.playerHP -= 5;
            bleedEffect();
        }

        //RESET DEBUFF
        playerStats.playerIncomingDMG = 0;

    }

    //------------------- MONSTER EFFECT -------------------------------

    public void bleedEffect() //Monster gave Player Bleed Effect
    {
        Debug.Log("Player Bleed Effect ended");
        isPlayerBleeding = false;
    }


    //------------------- PLAYER MOVE -------------------------------
    public void playerBasicAttack()
    {
        //HIT CHANCE
        int hitChance = Random.Range(1,10);

        //PALADIN
        if (characterName == "Paladin")
        {
            if (hitChance >= 4)
            {
                //MONSTER DAMAGE

                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;

                    Debug.Log("YOU HIT THE MONSTER!");   
                }   
            }

            else if (hitChance <= 3)
            {
                Debug.Log("YOU MISSED!");   

                moveDesc = "You Missed!";
                textDesc.text = moveDesc;
            }
        }

        //MAGE
        if (characterName == "Mage")
        {
            if (hitChance >= 5)
            {
                //MONSTER DAMAGE

                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;

                    Debug.Log("YOU HIT THE MONSTER!");   
                }   
            }

            else if (hitChance <= 4)
            {
                Debug.Log("YOU MISSED!");   

                moveDesc = "You Missed!";
                textDesc.text = moveDesc;
            }
        }

        //BLACK SWORDSMAN
        if (characterName == "Swordsman")
        {
            if (hitChance >= 5)
            {
                //MONSTER DAMAGE

                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;

                    Debug.Log("YOU HIT THE MONSTER!\n");   
                }   
            }

            else if (hitChance <= 4)
            {
                Debug.Log("YOU MISSED!");   

                moveDesc = "You Missed!";
                textDesc.text = moveDesc;
            }
        }
    }



    public void playerSpecialAttack1()
    {
        int hitChance = Random.Range(1,10);

        
        if (MonsterTrigger.isGoblin == true)
        {
            //Paladin Special Attack 1

            if (characterName == "Paladin") //Applies DeBuff
            {
                if (hitChance >= 4)
                {
                    if (playerStats.playerMP >= 65 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER
                        playerStats.playerMP -= 65;
                        specialAtkBtn1.GetComponent<Button>().enabled = true;

                        playerStats.isPlayerDeBuffEffect = true;

                    }
                    else if (playerStats.playerMP <= 64)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn1.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 3)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                }
            }

            //Mage Special Attack 1
 
            if (characterName == "Mage")
            {
                if(hitChance >= 5)
                {
                    if (playerStats.playerMP >= 60 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER
                        playerStats.playerMP -= 60;
                        specialAtkBtn1.GetComponent<Button>().enabled = true;


                    }
                else if (playerStats.playerMP <= 59)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn1.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                }
            }

            //Black Swordsman Special Attack 1

            if (characterName == "Swordsman")
            {
                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 50 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER
                        playerStats.playerMP -= 50;
                        specialAtkBtn1.GetComponent<Button>().enabled = true;


                    }
                    else if (playerStats.playerMP <= 49)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn1.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                }
                
            }
        }
    }

    public void playerSpecialAttack2()
    {   
        int hitChance = Random.Range(1,10);

        //THIS COMBAT IS CALCULATION IS FOR GOBLIN
        if (MonsterTrigger.isGoblin == true)
        {
            //Paladin Special Attack 2

            if (characterName == "Paladin") //Applies DeBuff
            {
                if (hitChance >= 4)
                {
                    if (playerStats.playerMP >= 110 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER
                        playerStats.playerMP -= 110;
                        specialAtkBtn2.GetComponent<Button>().enabled = true;

                        playerStats.isPlayerDeBuffEffect = true;

                    }
                    else if (playerStats.playerMP <= 109)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn2.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 3)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                }
            }

            //Mage Special Attack 2
 
            if (characterName == "Mage")
            {
                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 150 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER
                        playerStats.playerMP -= 150;
                        specialAtkBtn1.GetComponent<Button>().enabled = true;


                    }

                    else if (playerStats.playerMP <= 149)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn2.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                } 
            }

            //Black Swordsman Special Attack 2

            if (characterName == "Swordsman")
            {
                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 100 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER
                        playerStats.playerMP -= 100;
                        specialAtkBtn2.GetComponent<Button>().enabled = true;

                        isPlayerApplyBleedEffect = true;
                    }
                    else if (playerStats.playerMP <= 99)
                    {
                        Debug.Log("Player's MP is not enough");
                        specialAtkBtn2.GetComponent<Button>().enabled = false;
                    }
                }

                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!";
                    textDesc.text = moveDesc;
                } 
            }
        }
    }

    #endregion
}
