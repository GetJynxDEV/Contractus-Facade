using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Source")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip for START Scene")]

    public AudioClip bgStart;
    public AudioClip horrorBtn;

    //AUDIO STARTS HERE

    public void homeScreen()
    {
        musicSource.clip = bgStart;
        musicSource.Play();
    }

    public void horrorClickSound()
    {
        SFXSource.clip = horrorBtn;
        SFXSource.Play();
    }
}
