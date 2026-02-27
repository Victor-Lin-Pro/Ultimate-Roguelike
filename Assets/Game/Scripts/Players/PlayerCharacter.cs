using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    /*
    [SerializeField] private bool isPlayerDead = false;
    [SerializeField] private bool isPlayerCanHealth = false;
    [SerializeField] private bool isPlayerCanAddShield = false;
    */

    private PlayerStats ps;

    private void Awake()
    {
        ps = GameManager.Get.playerStats;
    }

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

        if (ps.PlayerLifeHeart() >= ps.PlayerMaxHeart())
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

        if (ps.PlayerLifeHeart() <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
