using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPos : MonoBehaviour
{
    public static float x, y, z;

    public void currentPos()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");
    }
}
