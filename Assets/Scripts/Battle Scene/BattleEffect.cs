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

    #endregion

    #region Methods

    public void end()
    {
        
    }

    #endregion
}
