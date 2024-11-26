using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleScript : MonoBehaviour
{
    #region Field and Properties

    [SerializeField] public TextMeshProUGUI hpTextValue; //Health Bar Text Value
    [SerializeField] public TextMeshProUGUI mpTextValue; //Mana Points Text Value

    [SerializeField] public TextMeshProUGUI textDesc; //Reference the Player and Monster Move

    string hpText; //Health Bar Text
    string mpText; //Mana Points Text

    float currentHP; //Current HP
    float currentMP; //Current MP

    float basicDMG; //Player Basic Damage
    float specialAttack; //Player Special Attack

    string moveDesc; //Move Information

    bool isPlayerTurn = false;

    string characterName = CharacterSelected.charName;
    GameObject Player; //References the Player Game Object

    //AVATAR SPRITE
    [SerializeField] public Sprite MageSprite;
    [SerializeField] public Sprite PaladinSprite;
    [SerializeField] public Sprite SwordsmanSprite;

    #endregion

    #region Methods

    void Start()
    {
        currentHP = playerStats.playerHP;
        currentMP = playerStats.playerMP;

        Debug.Log("Player's Current HP is " + currentHP);

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

    public void turn()
    {
        
    }

    public void playerAttack()
    {
        if (MonsterTrigger.isGoblin == true)
        {
            
        }
    }
    

    #endregion
}
