using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Get.playerCharacter.IsPlayerCanHealth())
        {
            Debug.Log($"Picked up: {itemData.itemName}");
            itemData.Use();
            gameObject.SetActive(false);
        }
    }
}
