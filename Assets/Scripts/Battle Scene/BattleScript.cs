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

    [SerializeField] public string hpText; //Health Bar Text
    [SerializeField] public string mpText; //Mana Points Text

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
        Player = GameObject.Find("Avatar");

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

        hpText
    }

    public void playerAttack()
    {

    }

    #endregion
}
