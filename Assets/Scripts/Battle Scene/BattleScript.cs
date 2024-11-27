using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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





    string hpText; //Health Bar Text
    string mpText; //Mana Points Text

    string moveName;
    string moveDesc;

    public static float currentHP; //Current HP
    public static float currentMP; //Current MP

    float basicDMG; //Player Basic Damage
    float specialAttack; //Player Special Attack

    public static float bleedDMG;

    bool isPlayerBleeding = false; //IF Player has Bleed Effect
    public static bool isPlayerBleedEffect = false;
    public static bool isPlayerBuffEffect = false;

    string characterName = CharacterSelected.charName;
    GameObject Player; //References the Player Game Object

    #endregion

    #region Methods

    void Start()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("YOUR ENEMY IS A GOBLIN!\n");
            GoblinEnemy.SetActive(true);
            CorneaEnemy.SetActive(false);
            FacadeEnemy.SetActive(false);

            Debug.Log("------------------------------------\n");
        }

        HealthUpdate();

        

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
        hpText = currentHP.ToString(); //current HP to Text

        hpTextValue.text = hpText;

        mpText = currentMP.ToString(); //current MP to Text

        mpTextValue.text = mpText;


    }

    

    public void HealthUpdate()
    {
        currentHP = playerStats.playerHP;
        currentMP = playerStats.playerMP;

        //CHECK PLAYER HEALTH
        Debug.Log("Player's Current HP is " + currentHP + "\n");

        //CHECK ENEMY HEALTH
        if (MonsterTrigger.isGoblin == true)
        {
            Debug.Log("Goblin's Current HP is " + GoblinScript.goblinHP + "\n");
        }

        if (isPlayerBleeding == true)
        {
            playerStats.playerHP -= 5;
            bleedEffect();
        }


    }

    //------------------- MONSTER EFFECT -------------------------------

    public void bleedEffect() //Monster gave Player Bleed Effect
    {
        Debug.Log("Player Bleed Effect ended");
        isPlayerBleeding = false;
    }

    //------------------- PLAYER APPLIED EFFECT -------------------------------

    public void appliedBleedEffect() //Player gives Monster Bleed Effect
    {

    }

    public void appliedbuffEffect() //Player gives Monster Debuff Effect
    {
        Debug.Log("Player Debuff applied");

        if (characterName == "Paladin" && playerStats.isPlayerDeBuffEffect == true)
        {

        }
        
    }

    //------------------- PLAYER MOVE -------------------------------
    public void playerBasicAttack()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            GoblinScript.goblinHP -= playerStats.playerBattack;

            moveDesc = "You did " + playerStats.playerBattack + " To the Goblin";
        }   
    }

    public void playerSpecialAttack1()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            GoblinScript.goblinHP -= playerStats.playerSattack1;

            if (characterName == "Paladin") //Applies DeBuff
            {
                playerStats.playerMP -= 65;
            }
        }
    }

    public void playerSpecialAttack2()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            GoblinScript.goblinHP -= playerStats.playerSattack2;
        }
    }
    

    #endregion
}
