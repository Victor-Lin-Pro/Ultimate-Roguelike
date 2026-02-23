using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int playerHealth = 0;
    [SerializeField] private int playerMaxHealth = 3;
    [SerializeField] private int playerShield = 0;

    /*
    [SerializeField] private bool isPlayerDead = false;
    [SerializeField] private bool isPlayerCanHealth = false;
    [SerializeField] private bool isPlayerCanAddShield = false;
    */

    public List<ItemList> items = new List<ItemList>();

    private void Start()
    {
        playerHealth = playerMaxHealth;

        HealingItem healingItem = new HealingItem();
        items.Add(new ItemList(healingItem, healingItem.ItemName()));
    }

    private void Update()
    {
        
    }

    public bool IsPlayerCanHealth()
    {
        if (GameManager.Get.playerCharacter == null)
        {
            return false;
        }

        if (playerHealth >= playerMaxHealth)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsPlayerCanAddShield()
    {
        return false;
    }

    public bool IsPlayerDead()
    {
        if (GameManager.Get.playerCharacter == null)
        {
            return false;
        }

        if (playerHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Getters
    public int GetPlayerHealth() { return playerHealth; }
    public int GetPlayerMaxHealth() { return playerMaxHealth; }

    // Setters
    public int SetPlayerHealth(int health) { return playerHealth = health; }
}
