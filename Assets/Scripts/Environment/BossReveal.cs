using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReveal : MonoBehaviour
{
    [SerializeField] public GameObject ColliderObject;
    [SerializeField] public GameObject VideoPlayer;
    [SerializeField] public GameObject Boss;
    [SerializeField] public GameObject Kid;
    bool isKid = true;

    // Update is called once per frame
    void Update()
    {
        if (isKid == false)
        {
            Boss.SetActive(true);
            Kid.SetActive(false);
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        
    }
}
