using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        StrPotion,
        MagicPotion,
        HealthPotion,
        ManaPotion,
        Key,
    }

    public ItemType itemType;
    public int amount;

}
