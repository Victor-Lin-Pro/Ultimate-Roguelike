using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "UnltimateRoguelike/Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite icon;

    public void Use()
    {
        Debug.Log(itemName + " used.");
        int playerHP = GameManager.Get.playerCharacter.GetPlayerHealth();
        GameManager.Get.playerCharacter.SetPlayerHealth(playerHP + 1);
    }
}
