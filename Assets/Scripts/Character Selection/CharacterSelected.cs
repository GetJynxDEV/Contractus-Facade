using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    #region Fields and Properties

    //PLAYER OBJECT
    GameObject Player;
    public static string charName;

    //PLAYER ANIM CONTROLLER
    [SerializeField] public RuntimeAnimatorController MageController;
    [SerializeField] public RuntimeAnimatorController PaladinController;
    [SerializeField] public RuntimeAnimatorController SwordsmanController;

    [Space(10)]

    //PLAYER SPRITES
    [SerializeField] public Sprite MageSprite;
    [SerializeField] public Sprite PaladinSprite;
    [SerializeField] public Sprite SwordsmanSprite;

    #endregion

    #region Methods

    void Start()
    {
        Player = GameObject.Find("Player");

        Debug.Log("PLAYER SELECTED " + charName);

        Animator PlayerAnim = Player.GetComponent<Animator>(); 

        switch(charName)
        {
            case "Mage":
                Debug.Log("Player Selected " + charName + "\n");

                Player.GetComponent<SpriteRenderer>().sprite = MageSprite;
                PlayerAnim.runtimeAnimatorController = MageController; 
                break;
            
            case "Swordsman":
                Debug.Log("Player Selected " + charName + "\n");

                Player.GetComponent<SpriteRenderer>().sprite = SwordsmanSprite;
                PlayerAnim.runtimeAnimatorController = SwordsmanController; 
                break;

            case "Paladin":
                Debug.Log("Player Selected " + charName + "\n");

                Player.GetComponent<SpriteRenderer>().sprite = PaladinSprite;
                PlayerAnim.runtimeAnimatorController = PaladinController; 
                break;
        }
        
    }
    #endregion
}
