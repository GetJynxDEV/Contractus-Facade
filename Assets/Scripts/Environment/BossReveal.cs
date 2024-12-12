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

    bool isCollide = false;

    // Update is called once per frame
    void Update()
    {
        if (isCollide == true)
        {
            if (isKid == true)
            {
                Video.SetActive(false);
                VideoPlayer.SetActive(false);

                Boss.SetActive(false);
                Kid.SetActive(true);
            }

            if (isKid == false)
            {

                playerMovement.movementSpeed = 0;
                Video.SetActive(true);
                VideoPlayer.SetActive(true);

                Destroy(Kid);

                Boss.SetActive(true);
                Kid.SetActive(false);

                Invoke("VideoPlay", 16);
            }

            isCollide = false;
        }

        else if (isCollide == false)
        {
            
        }

        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isCollide = true;

            isKid = false;

            Destroy(ColliderObject);
        }
    }

    void VideoPlay()
    {
        Video.SetActive(false);
        VideoPlayer.SetActive(false);

        playerMovement.movementSpeed = 3;
        CameraShake();
    }

    void CameraShake()
    {
        PlayerCameraShake.isFacade = true;
    }
}
