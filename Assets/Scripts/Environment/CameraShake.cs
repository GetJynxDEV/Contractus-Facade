using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject ShakeFX;
    float ShakeDuration = 1.5f;

    public static bool MonsterTrigger = false;

    void Start()
    {
        ShakeFX.SetActive(false);
    }

    public void Update()
    {
        if(MonsterTrigger == true)
        {
            StartCoroutine(shake(ShakeDuration));
        }

        else if (MonsterTrigger == false)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator shake(float time)
    {
        ShakeFX.SetActive(true);
        
        playerMovement.movementSpeed = 0;

        yield return new WaitForSeconds(time);

        playerMovement.movementSpeed = 5;
        
        ShakeFX.SetActive(false);
    }
}
