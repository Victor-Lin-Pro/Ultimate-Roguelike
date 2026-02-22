using System;
using UnityEngine;

[Serializable]
public abstract class Item
{
    public abstract string ItemName();
    public virtual void Update(PlayerCharacter player, Item item)
    {

    }
}
