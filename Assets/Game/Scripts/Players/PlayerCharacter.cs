using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float playerHealth = 0f;
    [SerializeField] private float playerSoul = 0f;
    [SerializeField] private float playerMaxHeart = 3f;
    [SerializeField] private float playerLuck = 0f;

    /*
    [SerializeField] private bool isPlayerDead = false;
    [SerializeField] private bool isPlayerCanHealth = false;
    [SerializeField] private bool isPlayerCanAddShield = false;
    */

    private void Start()
    {
        
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

        if (playerHealth >= playerMaxHeart)
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
    public float GetPlayerHealth() { return playerHealth; }
    public float GetPlayerMaxHealth() { return playerMaxHeart; }

    // Setters
    public float SetPlayerHealth(float health) { return playerHealth = health; }
}
