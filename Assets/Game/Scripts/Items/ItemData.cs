using UnityEngine;
using System;

public enum ItemType
{
    CONSUMABLE = 0,
    PASSIFY = 1,
    MATERIALS = 2,
    QUEST = 3,
    NONE = 4
}

public enum ItemRarity
{
    COMMON = 0,
    UNCOMMON = 1,
    RARE = 2,
    EPIC = 3,
    LEGENDARY = 4,
    NONE = 5
}

[Serializable]

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int value;
    public bool isStackable = true;

    // Virtual method - can be overridden by specific items if needed
    public virtual void Use(PlayerCharacter player) { }
}
