using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 100;
    UIController uiController;
    PhotonView view;

    private void Start()
    {
        print("INSTANTIATED");
        view = GetComponent<PhotonView>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        uiController.SetHealthBar(playerHealth);
    }
    [PunRPC]
    void TakeDamageRemote()
    {
        print("callerino");
        playerHealth -= 10;
        if (playerHealth <= 0)
        {
            HandleDeath();
        }
        if (view.IsMine)
        {
            uiController.SetHealthBar(playerHealth);
            uiController.DisplayDamageOutline();
        }
    }
    public void TakeDamage()
    {
        print("TAKING DAMAGE IS: " + PhotonNetwork.LocalPlayer.ToString());
        view.RPC("TakeDamageRemote", RpcTarget.All);
    }
    public void HandleDeath()
    {
        gameObject.SetActive(false);
    }
}
