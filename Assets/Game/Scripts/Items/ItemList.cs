using System;
using UnityEngine;

[Serializable]
public class ItemList
{
    public Item item;
    public string itemName;

    public ItemList(Item newItem, string newItemName)
    {
        item = newItem;
        itemName = newItemName;
    }
}
