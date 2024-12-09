using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTownManager : MonoBehaviour
{
    [Header("Audio Source")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip for START Scene")]

    public AudioClip townBG;
    public AudioClip BuyItem;

    //AUDIO STARTS HERE

    void Start()
    {
        TownMusic();
    }

    public void TownMusic()
    {
        musicSource.clip = townBG;
        musicSource.Play();
    }

    public void Buy()
    {
        SFXSource.clip = BuyItem;
        SFXSource.Play();
    }
}
