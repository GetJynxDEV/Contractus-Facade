using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    GameObject playerOBJ;

   float x,y,z;

    public void Start()
    {
        playerOBJ = GameObject.Find("Player");
        Load();
    }

    public void Save() //CONTINUE HERE
   {
    x = playerOBJ.transform.position.x;
    y = playerOBJ.transform.position.y;
    z = playerOBJ.transform.position.z;

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

   void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.gameObject.tag == "Enemy")
    {
        Debug.Log("POSITION SAVED!\n");

        Save();
    }
   }


}
