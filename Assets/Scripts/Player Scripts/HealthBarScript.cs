using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider hpSlider;
    
    public static float maxHealth;
    public static float health;

    public void SetMaxHealth()
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

    public void SetHealth()
    {
        hpSlider.value = health;
    }
}
