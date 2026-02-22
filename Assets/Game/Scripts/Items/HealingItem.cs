using UnityEngine;

public class HealingItem : Item
{
    [SerializeField] private int addHealth = 5;

    public override string ItemName()
    {
        return "Item Name";
    }

    public override void Update(PlayerCharacter player, Item item)
    {
        int currentPlayerHealth = player.GetPlayerHealth() + addHealth;
        player.SetPlayerHealth(currentPlayerHealth);
    }
}
