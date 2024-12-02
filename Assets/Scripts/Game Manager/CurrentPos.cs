using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPos : MonoBehaviour
{
    public static float x, y, z;

    public void currentPos()
    {
        InventorySystem.isBattle = false;
        InventorySystem.isTown = true;
    }
}
