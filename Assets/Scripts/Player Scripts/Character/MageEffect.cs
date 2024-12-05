using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEffect : MonoBehaviour
{
    [SerializeField] public GameObject Char;
    [SerializeField] public Animator anim;
    
    public static bool isMove = false;
    public static bool isMove2 = false;

    void Update()
    {
        if (isMove == true)
        {
            isMove = false;

            anim.SetTrigger("sAtk");
        }

        if (isMove2 == true)
        {
            isMove2 = false;

            anim.SetTrigger("sAtk2");
        }
    }
}
