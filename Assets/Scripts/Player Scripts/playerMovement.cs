using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    #region Field and Properties

    [Header("Player Movements")]
    //PLAYER MOVEMENT
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] private float playerSpeed;

    //PLAYER RIGID BODY
    [SerializeField] public Rigidbody2D rb;
   
    //PLAYER ANIMATOR
    //[SerializeField] public Animator anim;

   

    [SerializeField] Vector2 movement;

    [Header("MONSTER APPROACH")]

    [SerializeField] GameObject firstMob;

    #endregion

    #region Start Updated Method

    void Update()
    {
        playerSpeed = rb.velocity.magnitude;

        // Player Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Player Animator

        /*anim.SetBool("isWalk", true);

        anim.SetFloat("InputX", movement.x);
        anim.SetFloat("InputY", movement.y);    


        if (movement.x == 0 || movement.y == 0)
        {
            anim.SetBool("isWalk", false);
            anim.SetFloat("LastInputX", movement.x);
            anim.SetFloat("LastInputY", movement.y);
        } */


    }

    void FixedUpdate()
    {
        // Player Movements

        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    #endregion
}
