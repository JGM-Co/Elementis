using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class itemUse : MonoBehaviour
{
    [SerializeField]private Text playerHealthCount; 
    public void lowHeal()
    {
        healthInit.playerHealth += 15;
        if (healthInit.playerHealth > 100)
        {
            healthInit.playerHealth -= (healthInit.playerHealth - 100);
        }
        playerHealthCount.text = "Health: " + healthInit.playerHealth;
        gameObject.SetActive(false);
    }

    public void midHeal()
    {
        healthInit.playerHealth += 30;
        if (healthInit.playerHealth > 100)
        {
            healthInit.playerHealth -= (healthInit.playerHealth - 100);
        }
        playerHealthCount.text = "Health: " + healthInit.playerHealth;
        gameObject.SetActive(false);
    }

    public void hiHeal()
    {
        healthInit.playerHealth += 45;
        if (healthInit.playerHealth > 100)
        {
            healthInit.playerHealth -= (healthInit.playerHealth - 100);
        }
        playerHealthCount.text = "Health: " + healthInit.playerHealth;
        gameObject.SetActive(false);
    }
}
