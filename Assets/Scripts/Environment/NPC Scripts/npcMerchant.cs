using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class npcMerchant : MonoBehaviour
{
    #region Field and Method
    [SerializeField] public GameObject npcMerch;
    [SerializeField] public GameObject shopIcon;
    [SerializeField] public GameObject shopUI;
    [SerializeField] public GameObject bag;

    bool shopOpen = false;

    #endregion

    #region Methods
    void Update()
    {
        if (shopOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("PLAYER OPENED THE SHOP PANEL");
                shopUI.SetActive(true);

                bag.SetActive(false);
            }
        }
    }

    public void closeShop()
    {
        Debug.Log("PLAYER CLOSED THE SHOP PANEL");

        shopUI.SetActive(false);

        bag.SetActive(true);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("SHOP ICON OPEN");
            shopIcon.SetActive(true);

            shopOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        shopIcon.SetActive(false);
        shopOpen = false;
    }

    #endregion

}
