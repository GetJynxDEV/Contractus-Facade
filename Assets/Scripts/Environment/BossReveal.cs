using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReveal : MonoBehaviour
{
    [SerializeField] public GameObject ColliderObject;
    [SerializeField] public GameObject Video;
    [SerializeField] public GameObject VideoPlayer;
    [SerializeField] public GameObject Boss;
    [SerializeField] public GameObject Kid;
    bool isKid = true;

    // Update is called once per frame
    void Update()
    {
        if (isKid == true)
        {
            Video.SetActive(false);
            VideoPlayer.SetActive(false);

            Boss.SetActive(false);
            Kid.SetActive(true);
        }

        else if (isKid == false)
        {

            playerMovement.movementSpeed = 0;
            Video.SetActive(true);
            VideoPlayer.SetActive(true);

            Boss.SetActive(true);
            Kid.SetActive(false);

            Invoke("VideoPlay", 14);
        }

        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isKid = false;
        }
    }

    void VideoPlay()
    {
        Video.SetActive(false);
        VideoPlayer.SetActive(false);

        Destroy(Kid);
        Destroy(ColliderObject);

        playerMovement.movementSpeed = 3;
        CameraShake();
    }

    void CameraShake()
    {
        PlayerCameraShake.isFacade = true;
    }
}
