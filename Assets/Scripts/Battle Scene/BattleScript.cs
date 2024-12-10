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

    [SerializeField] public GameObject MageAvatar;
    [SerializeField] public GameObject PaladinAvatar;
    [SerializeField] public GameObject SwordsmanAvatar;

    [Header("ENEMY GAME OBJECT")]
    [SerializeField] public GameObject GoblinEnemy;
    [SerializeField] public GameObject CorneaEnemy;
    [SerializeField] public GameObject FacadeEnemy;

    [Header("Attack Button")]

    [SerializeField] public GameObject specialAtkBtn1;
    [SerializeField] public GameObject specialAtkBtn2;

    [Header("Health and Mana Bar")]

    public static float currentHP; //Current HP
    public static float currentMP; //Current MP

    public static float maxHP;
    public static float maxMP;

    public HealthBarScript hpBar;
    public float hpValue;
    public float maximumHP;
    public float currentHealthValue;

    public ManaBarScript mpBar;
    public float mpValue;
    public float maximumMP;
    public float currentManaValue;

    [Header("Monster Health Bar")]
    public static float monsterCurrentHP;
    public static float monsterMaxHP;

    public MonsterHP monsterHP;

    public float monsterHpValue;
    public float monsterCurrentHealthValue;


    //MISC

    string hpText; //Health Bar Text
    string mpText; //Mana Points Text

    string sAttack1Name;
    string sAttack2Name;

    string moveName;
    string moveDesc;

    float basicDMG; //Player Basic Damage
    float specialAttack; //Player Special Attack

    public static float bleedDMG;

    public static bool isPlayerBleeding = false; //IF Player has Bleed Effect
    public static bool isPlayerApplyBleedEffect = false;
    public static bool isPlayerBuffEffect = false;

    public static string characterName = CharacterSelected.charName;
    GameObject Player; //References the Player Game Object

    public static bool isForest = false;
    public static bool isDarkForest = false;
    public static bool isCave = false;

    #endregion

    #region Methods

    void Start()
    {
        InventorySystem.isBattle = true;
        InventorySystem.isTown = false;

        //HP AND MP
        maxHP = playerStats.playerHP;

        maxMP = playerStats.playerMP;

        maximumHP = maxHP; //
        maximumMP = maxMP; //

        hpValue = maximumHP;
        mpValue = maximumMP;

        hpBar.SetMaxHealth(hpValue);
        mpBar.SetMaxMP(mpValue);

        //MONSTER HP
        if (MonsterTrigger.isGoblin == true)
        {
            monsterMaxHP = GoblinScript.goblinHP;

            monsterHpValue = monsterMaxHP;

            monsterHP.SetMaxHealth(monsterHpValue);
        }

        else if (MonsterTrigger.isCornea == true)
        {
            monsterMaxHP = CorneaScript.corneaHP;

            monsterHpValue = monsterMaxHP;

            monsterHP.SetMaxHealth(monsterHpValue);
        }

        else if (MonsterTrigger.isFacade == true)
        {
            monsterMaxHP = FacadeScript.facadeHP;

            monsterHpValue = monsterMaxHP;

            monsterHP.SetMaxHealth(monsterHpValue);
        }

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

        if (MonsterTrigger.isCornea == true)
        {
            Debug.Log("YOUR ENEMY IS A CORNEA!\n");
            GoblinEnemy.SetActive(false);
            CorneaEnemy.SetActive(true);
            FacadeEnemy.SetActive(false);

            Debug.Log("------------------------------------\n");
        }

        if (MonsterTrigger.isFacade == true)
        {
            Debug.Log("YOUR ENEMY IS A FACADE!\n");
            GoblinEnemy.SetActive(false);
            CorneaEnemy.SetActive(false);
            FacadeEnemy.SetActive(true);

            Debug.Log("------------------------------------\n");
        }

        StatsUpdate();
        

        

        Player = GameObject.Find("Avatar");

        //THE SWITCH CASE WILL FIND WHICH CHARACTER IS ACTIVATED
        //THEN THE AVATAR GAME OBJECT WILL SHOW WHICH IS ACTIVATED
        switch (characterName)
        {
            case "Mage":

                //Player.GetComponent<SpriteRenderer>().sprite = MageSprite;
                MageAvatar.SetActive(true);

                break;
            
            case "Swordsman":

                //Player.GetComponent<SpriteRenderer>().sprite = SwordsmanSprite;
                SwordsmanAvatar.SetActive(true);
                break;

            case "Paladin":

                //Player.GetComponent<SpriteRenderer>().sprite = PaladinSprite; 
                PaladinAvatar.SetActive(true);
                break;
        }

    }

    void Update()
    {
        MoveStatsUpdate();

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

        //CHECKS MONSTER CURRENT HP

        if (MonsterTrigger.isGoblin == true)
        {
            monsterCurrentHP = GoblinScript.goblinHP;

            monsterCurrentHealthValue = monsterCurrentHP;

            monsterHP.SetHealth(monsterCurrentHealthValue);
        }

        else if (MonsterTrigger.isCornea == true)
        {
            monsterCurrentHP = CorneaScript.corneaHP;

            monsterCurrentHealthValue = monsterCurrentHP;

            monsterHP.SetHealth(monsterCurrentHealthValue);
        }

        else if (MonsterTrigger.isFacade == true)
        {
            monsterCurrentHP = FacadeScript.facadeHP;

            monsterCurrentHealthValue = monsterCurrentHP;

            monsterHP.SetHealth(monsterCurrentHealthValue);
        }

        moveDesc = "What will you do?"; //Default Move Description Name
        moveName = ""; //Default Move Name 

        textDesc.text = moveDesc;
        textMove.text = moveName;

        //CHECK PLAYER HEALTH
        Debug.Log("Player's Current Health is " + currentHP + "\n");
        Debug.Log("Player's Current Mana is " + currentMP + "\n");

        //CHECK IF PLAYER IS BLEEDING
        if (isPlayerBleeding == true)
        {
            BattleEffect.isPlayerBleeding = true;

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

        MonsterStatsUpdate();

        //RESET DEBUFF
        playerStats.playerIncomingDMG = 0;
        playerStats.playerDeBuff = 0;

    }

    public void MonsterStatsUpdate()
    {
        //CHECK MONSTER STATS

        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin regained " + GoblinScript.goblinMGEN + "MP\n");

            GoblinScript.goblinMP += GoblinScript.goblinMGEN;

            if (GoblinScript.maxMP >= GoblinScript.goblinMP)
            {
                GoblinScript.goblinMP = GoblinScript.maxMP;
            }
        }

        else if (MonsterTrigger.isCornea == true)
        {
            Debug.Log("Cornea regained " + CorneaScript.corneaMGEN + "MP\n");

            CorneaScript.corneaMP += CorneaScript.corneaMGEN;

            if (CorneaScript.maxMP >= CorneaScript.corneaMP)
            {
                CorneaScript.corneaMP = CorneaScript.maxMP;
            }
        }

        else if (MonsterTrigger.isFacade == true)
        {
            Debug.Log("Facade regained " + FacadeScript.facadeMGEN + "MP\n");

            FacadeScript.facadeMP += FacadeScript.facadeMGEN;

            if (FacadeScript.maxMP >= FacadeScript.facadeMP)
            {
                FacadeScript.facadeMP = FacadeScript.maxMP;
            }
        }


        //CHECK ENEMY HEALTH
        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin's Current Health is " + GoblinScript.goblinHP + "\n");
            Debug.Log("Goblin's Current Mana is " + GoblinScript.goblinMP + "\n");
        }

        else if (MonsterTrigger.isCornea == true)
        {
            Debug.Log("Cornea's Current Health is " + CorneaScript.corneaHP + "\n");
            Debug.Log("Cornea's Current Mana is " + CorneaScript.corneaMP + "\n");
        }

        else if (MonsterTrigger.isFacade == true)
        {
            Debug.Log("Facade's Current Health is " + FacadeScript.facadeHP + "\n");
            Debug.Log("Facade's Current Mana is " + FacadeScript.facadeMP + "\n");
        }
    }
    public void MoveStatsUpdate()
    {   
        //CHECK IF SPECIAL ATTACK 1 AND 2 MP Cost is Up
        sAttack1Update();
        sAttack2Update();
    }
    public void bleedEffect() //Monster gave Player Bleed Effect
    {
        Debug.Log("Player Bleed Effect ended\n");
        isPlayerBleeding = false;
    }

    public void sAttack1Update()
    {
        if (characterName == "Paladin")
        {
            //SPECIAL ATTACK 1
            if (currentMP <= 64f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = false; 
            }
            else if (playerStats.playerMP >= 65f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }

        else if (characterName == "Swordsman")
        {
            //SPECIAL ATTACK 1
            if (currentMP <= 49f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = false;
            }

            else if (playerStats.playerMP >= 50f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }

        if (characterName == "Mage")
        {
            //SPECIAL ATTACK 1
            if (currentMP <= 59f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = false;
            }

            else if (currentMP >= 60f)
            {
                specialAtkBtn1.GetComponent<Button>().interactable = true;
            }
        }
        
    }

    public void sAttack2Update()
    {
        //PALADIN 
        if (characterName == "Paladin")
        {
            //SPECIAL ATTACK 2
            if (currentMP <= 109f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }

            else if (currentMP >= 110f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }

        //SWORDSMAN
        else if (characterName == "Swordsman")
        {
            //SPECIAL ATTACK 2
            if (currentMP < 99f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }

            else if (currentMP >= 100f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }

        //MAGE
        else if (characterName == "Mage")
        {
            //SPECIAL ATTACK 2
            if (currentMP <= 149f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = false;
            }

            else if (currentMP >= 150f)
            {
                specialAtkBtn2.GetComponent<Button>().interactable = true;
            }
        }
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
            BattleEffect.isPaladinBasic = true;

            if (hitChance <= 7)
            {
                Debug.Log("YOU HIT THE MONSTER!");

                //MONSTER DAMAGE
                
                //GOBLIN 
                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";  
                }

                //CORNEA

                if (MonsterTrigger.isCornea == true)
                {
                    CorneaScript.corneaHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";  
                }

                //FACADE

                if (MonsterTrigger.isFacade == true)
                {
                    FacadeScript.facadeHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";
                }  

            }

            else if (hitChance >= 8)
            {
                Debug.Log("PLAYER MISSED");

                BattleEffect.isPlayerMiss = true;
                moveDesc = "You Missed!";
            }

            textDesc.text = moveDesc;
        }

        //MAGE
        if (characterName == "Mage")
        {
            BattleEffect.isMageBasic = true;

            if (hitChance <= 8)
            {
                //MONSTER DAMAGE

                //GOBLIN 
                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;
                }

                //CORNEA

                if (MonsterTrigger.isCornea == true)
                {
                    CorneaScript.corneaHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";  
                }

                //FACADE

                if (MonsterTrigger.isFacade == true)
                {
                    FacadeScript.facadeHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";
                } 
            }

            else if (hitChance >= 9)
            {
                Debug.Log("YOU MISSED!\n");   
                
                BattleEffect.isPlayerMiss = true;

                moveDesc = "You Missed!";
            }

            textDesc.text = moveDesc;
        }

        //BLACK SWORDSMAN
        if (characterName == "Swordsman")
        {
            BattleEffect.isSwordsmanBasic = true;

            if (hitChance >= 6)
            {
                //MONSTER DAMAGE

                //GOBLIN 
                if (MonsterTrigger.isGoblin == true)
                {
                    GoblinScript.goblinHP -= playerStats.playerBattack;

                    moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
                    textDesc.text = moveDesc;
                }

                //CORNEA

                if (MonsterTrigger.isCornea == true)
                {
                    CorneaScript.corneaHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";  
                }

                //FACADE

                if (MonsterTrigger.isFacade == true)
                {
                    FacadeScript.facadeHP -= playerStats.playerBattack;
                    moveDesc = "You did " + playerStats.playerBattack + " To the Cornea";
                } 
            }

            else if (hitChance >= 7)
            {
                Debug.Log("YOU MISSED!\n");   
                
                BattleEffect.isPlayerMiss = true;

                moveDesc = "You Missed!";
            }

            textDesc.text = moveDesc;
        }
    }

    public void playerSpecialAttack1()
    {
        moveName = "You used " + sAttack1Name;

        int hitChance = Random.Range(1,10);

        if (MonsterTrigger.isGoblin == true)
        {
            //Paladin Special Attack 1

            if (characterName == "Paladin") //Applies DeBuff
            {

                BattleEffect.isPaladinSAttack1 = true;

                playerStats.playerMP -= 65;

                if (hitChance >= 7)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER
                    playerStats.isPlayerDeBuffEffect = true;

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";
                }

                else if (hitChance <= 8)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 1
 
            if (characterName == "Mage")
            {
                BattleEffect.isMageSAttack1 = true;

                playerStats.playerMP -= 80;

                if(hitChance <= 8)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";

                }

                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 1

            if (characterName == "Swordsman")
            {
                BattleEffect.isSwordsmanSAttack1 = true;

                playerStats.playerMP -= 50;

                if (hitChance <= 6)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack1; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Goblin";

                }
                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
                
            }
        }
        
        //----------------- CORNEA ----------------------

        if (MonsterTrigger.isCornea == true)
        {
            //Paladin Special Attack 1

            if (characterName == "Paladin") //Applies DeBuff
            {
                BattleEffect.isPaladinSAttack1 = true;

                playerStats.playerMP -= 65;

                if (hitChance <= 7)
                {
                    if (playerStats.playerMP >= 65 )
                    {
                        CorneaScript.corneaHP -= playerStats.playerSattack1; //MONSTER
                        playerStats.isPlayerDeBuffEffect = true; 

                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Cornea";
                    }
                }

                else if (hitChance >= 8)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 1
 
            if (characterName == "Mage")
            {
                BattleEffect.isMageSAttack1 = true;
                
                playerStats.playerMP -= 80;

                if(hitChance <= 8)
                {
                    CorneaScript.corneaHP -= playerStats.playerSattack1; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Cornea";
                }

                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;

                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 1

            if (characterName == "Swordsman")
            {
                playerStats.playerMP -= 50;

                if (hitChance <= 6)
                {
                    CorneaScript.corneaHP -= playerStats.playerSattack1; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Cornea";
                }
                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;

                    moveName = "You used " + sAttack2Name;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }
        }
        
        //----------------- FACADE ----------------------

        if (MonsterTrigger.isFacade == true)
        {
            //Paladin Special Attack 1

            if (characterName == "Paladin") //Applies DeBuff
            {
                BattleEffect.isPaladinSAttack1 = true;

                playerStats.playerMP -= 65;

                if (hitChance <= 7)
                {
                    FacadeScript.facadeHP -= playerStats.playerSattack1; //MONSTER
                    playerStats.isPlayerDeBuffEffect = true;

                    moveDesc = "You did " + playerStats.playerSattack1 + " To the Facade";
                }

                else if (hitChance >= 8)
                {
                    BattleEffect.isPlayerMiss = true;

                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 1
 
            if (characterName == "Mage")
            {
                moveName = "You used " + sAttack1Name;

                BattleEffect.isMageSAttack1 = true;             

                playerStats.playerMP -= 80;

                if(hitChance <= 8)
                {
                    if (playerStats.playerMP > 80 )
                    {
                        FacadeScript.facadeHP -= playerStats.playerSattack1; //MONSTER

                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Facade";
                    }
                }

                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 1

            if (characterName == "Swordsman")
            {
                BattleEffect.isSwordsmanSAttack1 = true;

                playerStats.playerMP -= 50;

                if (hitChance <= 6)
                {
                    if (playerStats.playerMP >= 50 )
                    {
                        FacadeScript.facadeHP -= playerStats.playerSattack1; //MONSTER

                        moveName = "You used " + sAttack1Name;
                        moveDesc = "You did " + playerStats.playerSattack1 + " To the Facade";
                        textDesc.text = moveDesc;
                        textMove.text = moveName;

                    }
                }
                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;

                    moveName = "You used " + sAttack2Name;
                    moveDesc = "You Missed!";

                    textDesc.text = moveDesc;
                    textMove.text = moveName;
                }
                
            }
        }
    }


    public void playerSpecialAttack2()
    {   
        moveName = "You used " + sAttack2Name;

        int hitChance = Random.Range(1,10);

        //THIS COMBAT IS CALCULATION IS FOR GOBLIN
        if (MonsterTrigger.isGoblin == true)
        {
            //Paladin Special Attack 2

            if (characterName == "Paladin") //Applies DeBuff
            {
                BattleEffect.isPaladinSAttack2 = true;

                playerStats.playerMP -= 110;

                if (hitChance <= 7)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                }

                else if (hitChance >= 8)
                {
                    BattleEffect.isPlayerMiss = true;

                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 2
 
            if (characterName == "Mage")
            {
                BattleEffect.isMageSAttack2 = true;

                playerStats.playerMP -= 150;
                if (hitChance <= 8)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                }
                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 2

            if (characterName == "Swordsman")
            {
                BattleEffect.isSwordsmanSAttack2 = true;

                playerStats.playerMP -= 100;

                if (hitChance <= 6)
                {
                    GoblinScript.goblinHP -= playerStats.playerSattack2; //MONSTER

                    isPlayerApplyBleedEffect = true;

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Goblin";
                }
                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }
        }

        //THIS COMBAT IS CALCULATION IS FOR CORNEA
        else if (MonsterTrigger.isCornea == true)
        {
            //Paladin Special Attack 2

            if (characterName == "Paladin") //Applies DeBuff
            {
                BattleEffect.isPaladinSAttack2 = true;

                playerStats.playerMP -= 110;

                if (hitChance <= 7)
                {
                    CorneaScript.corneaHP -= playerStats.playerSattack2; //MONSTER
                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Cornea";
                }
                else if (hitChance >= 8)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 2
 
            if (characterName == "Mage")
            {
                moveName = "You used " + sAttack2Name;

                BattleEffect.isMageSAttack2 = true;

                playerStats.playerMP -= 150;

                if (hitChance <= 8)
                {
                    CorneaScript.corneaHP -= playerStats.playerSattack2; //MONSTER

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Cornea";
                }
                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 2

            if (characterName == "Swordsman")
            {
                BattleEffect.isSwordsmanSAttack2 = true;

                playerStats.playerMP -= 100;

                if (hitChance <= 6)
                {
                    CorneaScript.corneaHP -= playerStats.playerSattack2; //MONSTER

                    isPlayerApplyBleedEffect = true;

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Cornea";

                }

                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }
        }

        //THIS COMBAT IS CALCULATION IS FOR FACADE
        if (MonsterTrigger.isFacade == true)
        {
            //Paladin Special Attack 2

            if (characterName == "Paladin") //Applies DeBuff
            {
                BattleEffect.isPaladinSAttack2 = true;

                playerStats.playerMP -= 110;

                if (hitChance <= 7)
                {
                        FacadeScript.facadeHP -= playerStats.playerSattack2; //MONSTER

                        moveName = "You used " + sAttack2Name;
                        moveDesc = "You did " + playerStats.playerSattack2 + " To the Facade";
                }
                
                else if (hitChance >= 8)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                }

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Mage Special Attack 2
 
            if (characterName == "Mage")
            {
                BattleEffect.isMageSAttack2 = true;

                playerStats.playerMP -= 150;

                if (hitChance <= 8)
                {
                    FacadeScript.facadeHP -= playerStats.playerSattack2; //MONSTER
            
                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Facade";
                }
                else if (hitChance >= 9)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }

            //Black Swordsman Special Attack 2

            if (characterName == "Swordsman")
            {
                BattleEffect.isSwordsmanSAttack2 = true;

                playerStats.playerMP -= 100;

                if (hitChance <= 6)
                {
                    FacadeScript.facadeHP -= playerStats.playerSattack2; //MONSTER

                    isPlayerApplyBleedEffect = true;

                    moveDesc = "You did " + playerStats.playerSattack2 + " To the Facade";
                }

                else if (hitChance >= 7)
                {
                    BattleEffect.isPlayerMiss = true;
                    moveDesc = "You Missed!";
                } 

                textDesc.text = moveDesc;
                textMove.text = moveName;
            }
        }
    }

    #endregion
}
