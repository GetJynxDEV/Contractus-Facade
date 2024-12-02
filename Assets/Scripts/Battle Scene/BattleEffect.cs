using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffect : MonoBehaviour
{
    #region Fields and Properties

    [Header("Player Bleed Effect")]
    [SerializeField] public GameObject PlayerBleedEffect;
    [SerializeField] public GameObject PlayerMiss;

    [Header("Monster Bleed Effect")]
    [SerializeField] public GameObject MonsterBleedEffect;
    [SerializeField] public GameObject MonsterMiss;

    //BOOLEAN

    public static bool isPlayerBleeding = false;
    public static bool isPlayerMiss = false;

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

            Invoke("PlayerBleedAnim", 2);
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
