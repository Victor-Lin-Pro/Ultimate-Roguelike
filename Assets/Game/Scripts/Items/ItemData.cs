using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Base Item")]
public class ItemData : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite itemSprite;
    public GameObject pickupPrefab;
    public string description = "It's a item";

    public virtual void OnPickup(GameObject player)
    {
        Debug.Log($"Item pick : {itemName}");
    }
}