using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
    public Slider Slider;
    
    public void SetMaxMP(int mana)
    {
        Slider.maxValue = mana;
        Slider.value = mana;
    }

    public void SetMana(int mana)
    {
        Slider.value = mana;
    }
}
