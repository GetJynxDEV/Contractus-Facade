using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffect : MonoBehaviour
{
    #region Fields and Properties

    [Header("Player Effect")]
    [SerializeField] public GameObject PlayerBleedEffect;
    [SerializeField] public GameObject PlayerMiss;

    [Header("Player Moves")]

    [SerializeField] public GameObject PaladinBasic;
    [SerializeField] public GameObject PaladinSAttack1;
    [SerializeField] public GameObject PaladinSAttack2;
    [SerializeField] public GameObject PaladinSAttackField;

    [Space(10)]

    [SerializeField] public GameObject MageBasic;
    [SerializeField] public GameObject MageSAttack1;
    [SerializeField] public GameObject MageSAttack2strike;

    [Space(10)]

    [SerializeField] public GameObject SwordsmanBasic;
    [SerializeField] public GameObject SwordsmanSAttack1;
    [SerializeField] public GameObject SwordsmanSAttack2;

    [Header("Monster Effect")]
    [SerializeField] public GameObject MonsterBleedEffect;
    [SerializeField] public GameObject MonsterMiss;

    [Header("Area Object")]
    [SerializeField] public GameObject Forest;
    [SerializeField] public GameObject Cave;

    //BOOLEAN

    //PLAYER EFFECTS

    public static bool isPlayerBleeding = false;
    public static bool isPlayerMiss = false;

    //PALADIN 

    public static bool isPaladinBasic = false;
    public static bool isPaladinSAttack1 = false;
    public static bool isPaladinSAttack2 = false;

    //MAGE
    public static bool isMageBasic = false;
    public static bool isMageSAttack1 = false;
    public static bool isMageSAttack2 = false;

    //SWORDSMAN
    public static bool isSwordsmanBasic = false;
    public static bool isSwordsmanSAttack1 = false;
    public static bool isSwordsmanSAttack2 = false;

    //MONSTER EFFECTS

    public static bool isMonsterBleeding = false;
    public static bool isMonsterMiss = false;

    #endregion

    #region Start and Update

    void Update()
    {   
        //IF EFFECT IS TRUE ANIM WILL PLAY THEN CLOSE

        //PLAYER EFFECTS

        if (isPlayerBleeding == true)
        {
            PlayerBleedEffect.SetActive(true);

            Invoke("PlayerBleedAnim", 2);
        }

        if (isPlayerMiss == true)
        {
            PlayerMiss.SetActive(true);

            Invoke("PlayerMissAnim", 2);
        }

        //PLAYER ATTACK ANIMATION

        //PALADIN

        if (isPaladinBasic == true)
        {
            isPaladinBasic = false;
            PaladinBasic.SetActive(true);

            PaladinEffect.isMove = true; //BATTLE EFFECT
            Invoke("PaladinBasicAnim", 2);

        }

        if (isPaladinSAttack1 == true)
        {
            isPaladinSAttack1 = false;
            PaladinSAttack1.SetActive(true);

            PaladinEffect.isMove = true; //BATTLE EFFECT

            Invoke("PaladinSAttack1Anim,", 2);

        }

        if (isPaladinSAttack2 == true)
        {
            isPaladinSAttack2 = false;
            PaladinSAttack2.SetActive(true);
            PaladinSAttackField.SetActive(true);

            PaladinEffect.isMove2 = true; //BATTLE EFFECT

            Invoke("PaladinSAttack2Anim", 2);

        }

        //MAGE

        if (isMageBasic == true)
        {
            isMageBasic = false;
            MageBasic.SetActive(true);

            Invoke("MageBasicAnim", 2);

        }

        if (isMageSAttack1 == true)
        {
            isMageSAttack1 = false;
            MageSAttack1.SetActive(true);

            MageEffect.isMove = true; //battle animation

            Invoke("MageSAttack1Anim", 2);

        }

        if (isMageSAttack2 == true)
        {
            isMageSAttack2 = false;
            MageSAttack2strike.SetActive(true);

            MageEffect.isMove2 = true;

            Invoke("MageSAttack2Anim", 2);

            Animator ForestAnim = Forest.GetComponent<Animator>();
            ForestAnim.SetTrigger("shake");

            Animator CaveAnim = Cave.GetComponent<Animator>();
            CaveAnim.SetTrigger("shake");

        }

        //SWORDSMAN

        if (isSwordsmanBasic == true)
        {
            isSwordsmanBasic = false;
            SwordsmanBasic.SetActive(true);

            Invoke("SwordsmanBasicAnim", 2);

        }

        if (isSwordsmanSAttack1 == true)
        {
            isSwordsmanSAttack1 = false;
            SwordsmanSAttack1.SetActive(true);

            Invoke("SwordsmanSAttack1Anim,", 2);

        }

        if (isSwordsmanSAttack2 == true)
        {
            isSwordsmanSAttack2 = false;
            SwordsmanSAttack2.SetActive(true);

            Invoke("SwordsmanSAttack2Anim", 2);

        }


        //MONSTER EFFECT

        if (isMonsterBleeding == true)
        {
            MonsterBleedEffect.SetActive(true);

            Invoke("MonsterBleedAnim", 2);
        }

        if (isMonsterMiss == true)
        {
            MonsterMiss.SetActive(true);

            Invoke("MonsterMissAnim", 2);
        }
    }

    #endregion

    #region Player Effects

    void PlayerBleedAnim()
    {
        isPlayerBleeding = false;

        PlayerBleedEffect.SetActive(false);
    }

    void PlayerMissAnim()
    {
        isPlayerMiss = false;

        PlayerMiss.SetActive(false);
    }

    //PALADIN

    void PaladinBasicAnim()
    {
        PaladinBasic.SetActive(false);
    }

    void PaladinSAttack1Anim()
    {
        PaladinSAttack1.SetActive(false);
    }

    void PaladinSAttack2Anim()
    {
        PaladinSAttack2.SetActive(false);
        PaladinSAttackField.SetActive(false);
    }

    //MAGE

    void MageBasicAnim()
    {
        MageBasic.SetActive(false);
    }

    void MageSAttack1Anim()
    {
        MageSAttack1.SetActive(false);
    }

    void MageSAttack2Anim()
    {
        MageSAttack2strike.SetActive(false);
    }

    //SWORDSMAN

    void SwordsmanBasicAnim()
    {
        SwordsmanBasic.SetActive(false);
    }

    void SwordsmanSAttack1Anim()
    {
        SwordsmanSAttack1.SetActive(false);
    }

    void SwordsmanSAttack2Anim()
    {
        SwordsmanSAttack2.SetActive(false);
    }


    #endregion

    #region Monster Effects

    void MonsterBleedAnim()
    {
        isMonsterBleeding = false;

        MonsterBleedEffect.SetActive(false);
    }

    void MonsterMissAnim()
    {
        isMonsterMiss = false;

        MonsterMiss.SetActive(false);
    }

    #endregion
}
