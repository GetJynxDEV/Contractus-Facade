using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanEffect : MonoBehaviour
{
    [SerializeField] public GameObject Char;
    [SerializeField] public Animator anim;
    
    public static bool isMove2 = false;
    
    void Update()
    {
        if (isMove2 == true)
        {
            isMove2 = false;

            anim.SetTrigger("sAtk2");
        }
    }
}
