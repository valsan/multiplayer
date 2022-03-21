using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text health;
    [SerializeField] Image damageImage;

    private void Start()
    {
        damageImage.enabled = false;
    }
    public void SetHealthBar(int amount)
    {
        health.text = "HEALTH: " + amount;
    }

    public void DisplayDamageOutline()
    {
        StartCoroutine(CrossFade());
    }

    private IEnumerator CrossFade()
    {
        damageImage.enabled = true;
        damageImage.CrossFadeAlpha(0f, 0, false);
        damageImage.CrossFadeAlpha(0.3f, 0.15f, false);
        yield return new WaitForSeconds(0.2f);
        damageImage.CrossFadeAlpha(0f, 0.15f, false);
    }
}
