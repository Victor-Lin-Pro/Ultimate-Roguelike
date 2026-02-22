using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int playerHealth = 3;

    public List<ItemList> items = new List<ItemList>();

    private void Start()
    {
        HealingItem healingItem = new HealingItem();
        items.Add(new ItemList(healingItem, healingItem.ItemName()));
    }

    private void Update()
    {
        CallItemUpdate();
    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in items)
        {
            i.item.Update(this, i.item);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    // Getters
    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    // Setters
    public int SetPlayerHealth(int health)
    {
        return playerHealth = health;
    }
}
