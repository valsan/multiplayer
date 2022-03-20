using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text health;

    public void SetHealthBar(int amount)
    {
        health.text = "HEALTH: " + amount;
    }
}
