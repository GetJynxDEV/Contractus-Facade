using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
    public Slider Slider;
    
    public void SetMaxMP(float mana)
    {
        Slider.maxValue = mana;
        Slider.value = mana;
    }

    public void SetMana(float mana)
    {
        Slider.value = mana;
    }
}
