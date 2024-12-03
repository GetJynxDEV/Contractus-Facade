using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBattleManager : MonoBehaviour
{
    [Header("Audio Source")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip for START Scene")]

    public AudioClip forestBG;
    public AudioClip darkForestBG;
    public AudioClip caveBG;
    public AudioClip mageSpecialAttack2;

    //AUDIO STARTS HERE

    void Start()
    {
        if (BattleScript.isForest == true)
        {
            ForestMusic();
        }

        if (BattleScript.isDarkForest == true)
        {
            DarkForestMusic();
        }

        if (BattleScript.isCave == true)
        {
            CaveMusic();
        }
    }

    public void ForestMusic()
    {
        musicSource.clip = forestBG;
        musicSource.Play();
    }
    public void DarkForestMusic()
    {
        musicSource.clip = darkForestBG;
        musicSource.Play();
    }
    public void CaveMusic()
    {
        musicSource.clip = caveBG;
        musicSource.Play();
    }

    public void SAttack2()
    {
        if (BattleScript.characterName == "Mage")
        {
            SFXSource.clip = mageSpecialAttack2;
            SFXSource.Play();
        }
    }
}
