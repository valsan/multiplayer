using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 100;
    UIController uiController;

    private void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        uiController.SetHealthBar(playerHealth);
    }


    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        uiController.SetHealthBar(playerHealth);
        uiController.DisplayDamageOutline();
        if (playerHealth <= 0)
        {
            // handle death
        }
    }
}
