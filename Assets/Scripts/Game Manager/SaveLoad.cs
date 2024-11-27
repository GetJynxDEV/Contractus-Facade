using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
   float x,y,z;

    public static SaveLoad Saved;

    public SaveLoad()
    {
        Saved = this;
    }

    public void Save() //CONTINUE HERE
   {
    x = transform.position.x;
    y = transform.position.y;
    z = transform.position.z;

    PlayerPrefs.SetFloat("x", x);
    PlayerPrefs.SetFloat("y", y);
    PlayerPrefs.SetFloat("z", z);
   }

   public void Load()
   {
    x = PlayerPrefs.GetFloat("x");
    y = PlayerPrefs.GetFloat("y");
    z = PlayerPrefs.GetFloat("z");

    Vector3 LoadPosition = new Vector3(x, y, z);
    transform.position = LoadPosition;
   }
}
