using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    
using UnityEngine.UI;

public class merchantShop : MonoBehaviour
{
    #region Fields and Properties

    [SerializeField] public GameObject buyBtn;
    [SerializeField] public TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI itemDesc;

    [SerializeField] public TextMeshProUGUI currentGold;

    string Name;
    string Desc;

    int STRprice = 25;
    int MGUPrice = 25;
    int HPPrice = 25;
    int MPPrice = 25;

    bool isSTR = false;
    bool isMGU = false;
    bool isHP = false;
    bool isMP = false;

    int plyCurrentGold;
    string plyCurrentGoldValue;

    #endregion

    #region Methods

    void Update()
    {
        //CHECK PLAYER MONEY
        if (playerStats.playerGold <= 24)
        {
            buyBtn.GetComponent<Button>().interactable = false;
        }

        int PlyGold = playerStats.playerGold;

        plyCurrentGold = PlyGold;
        plyCurrentGoldValue = plyCurrentGold.ToString();
        currentGold.text = plyCurrentGoldValue;
    }

    //CLEAR SELECTED ITEM
    public void clearSelected()
    {
        itemName.text = "";
        itemDesc.text = "";

        isSTR = false;
        isMGU = false;
        isHP = false;
        isMP = false;
    }

    //ITEM BUTTON
    public void STRBtn()
    {
        Name = "STRENGTH POTION";
        Desc = "INCREASES YOUR STRENGTH BY 30 for 25 Gold";

        itemName.text = Name;
        itemDesc.text = Desc;

        isSTR = true;
    }

    public void MGUBtn()
    {
        Name = "MAGIC UP POTION";
        Desc = "INCREASES YOUR MAGIC BY 30 for 25 Gold";

        itemName.text = Name;
        itemDesc.text = Desc;

        isMGU = true;
    }


    public void HPBtn()
    {
        Name = "HEALTH POTION";
        Desc = "GIVES YOU 30 HP for 25 Gold";

        itemName.text = Name;
        itemDesc.text = Desc;

        isHP = true;
    }

    public void MPBtn()
    {
        Name = "MANA POTION";
        Desc = "GIVES YOU 30 MP for 25 Gold";

        itemName.text = Name;
        itemDesc.text = Desc;

        isMP = true;
    }

    //BUY BUTTON
    public void BuyBtn()
    {
        if (isSTR == true)
        {
            playerStats.playerGold -= 25;

            InventorySystem.STRAmount++;
        }

        if (isMGU == true)
        {
            playerStats.playerGold -= 25;

            InventorySystem.MGUPAmount++;
        }

        if (isHP == true)
        {
            playerStats.playerGold -= 25;

            InventorySystem.HPPotionAmount++;
        }

        if (isMP == true)
        {
            playerStats.playerGold -= 25;

            InventorySystem.MPPotionAmount++;
        }
    }

    #endregion

}
