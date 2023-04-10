using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth = 200f;
    public float playerCurrentHealth;

    private void OnAwake()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    private void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;
        if (playerCurrentHealth <= 0)
        {
            PlayerDeathProcess();
        }
    }

    private void PlayerDeathProcess()
    {
        //Game over falan mustafa halleder
    }
}
