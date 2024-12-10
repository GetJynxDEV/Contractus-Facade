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
    public AudioClip cryingChild;
    public AudioClip facadeScream;

    public static bool isCry = false;
    public static bool isFacade = false;

    //AUDIO STARTS HERE

    void Start()
    {
        TownMusic();
    }

    void Update()
    {
        Cry();
        FacadeShout();
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

    void Cry()
    {
        if (isCry == true)
        {   
            Debug.Log("CRYING CHILD SOUND PLAYED");
            SFXSource.clip = cryingChild;
            SFXSource.Play();
        }

        else if (isCry == false)
        {
            SFXSource.clip = cryingChild;
            SFXSource.Stop();
        }

        
    }

    void FacadeShout()
    {
        if (isFacade == true)
        {
            SFXSource.clip = facadeScream;
            SFXSource.Play();
        }

        else if (isFacade == false)
        {
            SFXSource.clip = facadeScream;
            SFXSource.Stop();
        }
        
    }
}
