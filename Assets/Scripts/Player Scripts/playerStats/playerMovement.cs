using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    #region Field and Properties

    //PLAYER MOVEMENT
    public static float movementSpeed = 5;

    Rigidbody2D rb; //PLAYER RIGID BODY

    Animator animator; //PLAYER ANIMATOR

    public GameObject InventoryPanel;


    #endregion

    #region Start Updated Method

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            InventoryPanel.SetActive(true);

            movementSpeed = 0;
        }

        else
        {
            movementSpeed = 5;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") ,0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        
        transform.position = transform.position + movement * movementSpeed * Time.deltaTime;
    }

    #endregion
}
