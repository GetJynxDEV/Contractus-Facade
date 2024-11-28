using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider hpSlider;
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
