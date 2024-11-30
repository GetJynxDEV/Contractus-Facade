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

    [Header("Health and Mana Bar")]

    public HealthBarScript hpBar;
    public float hpValue;
    public float maximumHP;
    public float currentHealthValue;

    public ManaBarScript mpBar;
    public float mpValue;
    public float maximumMP;
    public float currentManaValue;


    //MISC

    string hpText; //Health Bar Text
    string mpText; //Mana Points Text

    string sAttack1Name;
    string sAttack2Name;

    string moveName;
    string moveDesc;

    public static float currentHP; //Current HP
    public static float currentMP; //Current MP

  

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

    

    #endregion

    #region Methods

    void Start()
    {
        //HP AND MP
        maxHP = playerStats.playerHP;

        maxMP = playerStats.playerMP;

        maximumHP = maxHP; //
        maximumMP = maxMP; //

        hpValue = maximumHP;
        mpValue = maximumMP;

        hpBar.SetMaxHealth(hpValue);
        mpBar.SetMaxMP(mpValue);

        //MOVE NAMES
        sAttack1Name = playerStats.playerSattackName1;
        sAttack2Name = playerStats.playerSattackName2;

        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("YOUR ENEMY IS A GOBLIN!\n");
            GoblinEnemy.SetActive(true);
            CorneaEnemy.SetActive(false);
            FacadeEnemy.SetActive(false);

            Debug.Log("------------------------------------\n");
        }

        StatsUpdate();
        MoveStatsUpdate();

        

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
        
        if (playerStats.playerMP <= 0)
        {
            playerStats.playerMP = 0;
        }

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

        currentHealthValue = currentHP;
        currentManaValue = currentMP;

        hpBar.SetHealth(currentHealthValue);
        mpBar.SetMana(currentManaValue);

        moveDesc = "What will you do?"; //Default Move Description Name
        moveName = ""; //Default Move Name 

        //CHECK PLAYER HEALTH
        Debug.Log("Player's Current Health is " + currentHP + "\n");
        Debug.Log("Player's Current Mana is " + currentMP + "\n");

        //CHECK IF PLAYER IS BLEEDING
        if (isPlayerBleeding == true)
        {
            playerStats.playerHP -= 5;
            bleedEffect();
        }

        //CHECK AND REGAIN MANA
        Debug.Log("You regained " + playerStats.playerMREG + "MP\n");

        playerStats.playerMP += playerStats.playerMREG;

        if (playerStats.playerMP > BattleScript.maxMP)
        {
            playerStats.playerMP = BattleScript.maxMP;
        }
        
        if (playerStats.playerMP <= 0)
        {
            playerStats.playerMP = 0;
        }

        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin regained " + GoblinScript.goblinMGEN + "MP\n");

            GoblinScript.goblinMP += GoblinScript.goblinMGEN;

            if (GoblinScript.maxMP >= GoblinScript.goblinMP)
            {
                GoblinScript.goblinMP = GoblinScript.maxMP;
            }
        }


        //CHECK ENEMY HEALTH
        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin's Current Health is " + GoblinScript.goblinHP + "\n");
            Debug.Log("Goblin's Current Mana is " + GoblinScript.goblinMP + "\n");
        }

        //RESET DEBUFF
        playerStats.playerIncomingDMG = 0;
        playerStats.playerDeBuff = 0;

    }

    public void MoveStatsUpdate()
    {
        //IF MP is Down

        if (characterName == "Paladin")
        {
            if (playerStats.playerMP <= 64)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn1.GetComponent<Button>().interactable = false;
            }
        }

        if (characterName == "Swordsman")
        {
            if (playerStats.playerMP <= 49)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn1.GetComponent<Button>().interactable = false;
            }
        }

        if (characterName == "Mage")
        {
            if (playerStats.playerMP <= 59)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn1.GetComponent<Button>().interactable = false;
            }
        }

        //Move Update Special Attack 2
        
        if (characterName == "Paladin")
        {
            if (playerStats.playerMP <= 109)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }
        }

        if (characterName == "Swordsman")
        {
            if (playerStats.playerMP <= 99)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }
        }

        if (characterName == "Mage")
        {
            if (playerStats.playerMP <= 149)
            {
                Debug.Log("Player's MP is not enough");
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }
        }

        //If MP is up

        if (characterName == "Paladin")
        {
            if (playerStats.playerMP >= 65)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }

        if (characterName == "Swordsman")
        {
            if (playerStats.playerMP >= 50)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }

        if (characterName == "Mage")
        {
            if (playerStats.playerMP >= 60)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }

        //Move Update Special Attack 2
        
        if (characterName == "Paladin")
        {
            if (playerStats.playerMP >= 110)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }

        if (characterName == "Swordsman")
        {
            if (playerStats.playerMP >= 100)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }

        if (characterName == "Mage")
        {
            if (playerStats.playerMP >= 150)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }
    }
    //------------------- MONSTER EFFECT -------------------------------

    public void bleedEffect() //Monster gave Player Bleed Effect
    {
        Debug.Log("Player Bleed Effect ended\n");
        isPlayerBleeding = false;
    }

#endregion

#region Player Move
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
                
                //GOBLIN 
                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;

                    Debug.Log("YOU HIT THE MONSTER!\n");   
                }

                //MONSTER DAMAGE

                if (MonsterTrigger.isCornea == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;

                    Debug.Log("YOU HIT THE MONSTER!\n");   
                }   
            }

            else if (hitChance <= 3)
            {
                Debug.Log("YOU MISSED!\nb");   

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

                    Debug.Log("YOU HIT THE MONSTER!\n");   
                }   
            }

            else if (hitChance <= 4)
            {
                Debug.Log("YOU MISSED!\n");   

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
                Debug.Log("YOU MISSED!\n");   

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
                playerStats.playerMP -= 65;

                if (hitChance >= 4)
                {
                    if (playerStats.playerMP >= 65 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER
                        playerStats.isPlayerDeBuffEffect = true;

                        moveName = "You used " + sAttack1Name;
                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;

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
                playerStats.playerMP -= 60;

                if(hitChance >= 5)
                {
                    if (playerStats.playerMP > 60 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER

                        moveName = "You used " + sAttack1Name;
                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;
                    }
                }

                else if (hitChance <= 4)
                {

                    moveDesc = "You Missed!\n";
                    textDesc.text = moveDesc;
                }
            }

            //Black Swordsman Special Attack 1

            if (characterName == "Swordsman")
            {
                playerStats.playerMP -= 50;

                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 50 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER

                        moveName = "You used " + sAttack1Name;
                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;

                    }
                }
                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!\n";
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
                playerStats.playerMP -= 110;

                if (hitChance >= 4)
                {
                    if (playerStats.playerMP >= 110 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                        moveName = "You used " + sAttack2Name;
                        moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;

                    }
                }
                else if (hitChance <= 3)
                {

                    moveDesc = "You Missed!\n";
                    textDesc.text = moveDesc;
                }
            }

            //Mage Special Attack 2
 
            if (characterName == "Mage")
            {
                playerStats.playerMP -= 150;

                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 150 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                        moveName = "You used " + sAttack2Name + "\n";
                        moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;

                    }
                }
                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!\n";
                    textDesc.text = moveDesc;
                } 
            }

            //Black Swordsman Special Attack 2

            if (characterName == "Swordsman")
            {
                playerStats.playerMP -= 100;

                if (hitChance >= 5)
                {
                    if (playerStats.playerMP >= 100 )
                    {
                        GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                        isPlayerApplyBleedEffect = true;

                        moveName = "You used " + sAttack2Name;
                        moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;
                    }
                }
                else if (hitChance <= 4)
                {
                    moveDesc = "You Missed!\n";
                    textDesc.text = moveDesc;
                } 
            }
        }
    }

    #endregion
}
