using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    #region Field and Properties

    

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
    }

    public void playerAttack()
    {

    }

    #endregion
}
