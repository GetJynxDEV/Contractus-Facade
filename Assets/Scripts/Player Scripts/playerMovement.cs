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

    //PLAYER RIGID BODY
    [SerializeField] public Rigidbody2D rb;

    //PLAYER ANIMATOR
    [SerializeField] public Animator animator;


    #endregion

    #region Start Updated Method

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") ,0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        
        transform.position = transform.position + movement * movementSpeed * Time.deltaTime;
    }

    #endregion
}
