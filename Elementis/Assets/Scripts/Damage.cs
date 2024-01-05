using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class damage : MonoBehaviour
{
    [SerializeField] private Text healthCount2;
    [SerializeField] private Text playerHealthCount;
    public Text playerCombatIndicator;
    public Text combatIndicator2;
    public Animator anim;
    public GameObject cards;
    public GameObject items;
    bool isCard = false;
    //public GameObject arg;
    private enum hitState { idle, playerHit }
    //private enum enemyHitState { enemyIdle, enemyHit }
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim2 = GetComponent<Animator>();
        healthInit.enemyHealth = 100;
        healthInit.playerHealth = 100;
    }

    public void attack()
    {
        isCard = true;
        int dmgNum = RandomNumberGenerator.GetInt32(1, 5);
        if (healthInit.playerHealth > 0)
        {
            if (dmgNum == 1)
            {
                if (gameObject.CompareTag("lightning"))
                {
                    healthInit.enemyHealth -= 10;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Weak blow..";
                }
                else if (gameObject.CompareTag("water") || gameObject.CompareTag("fire"))
                {
                    playerCombatIndicator.text = "Ineffective";
                } 
                else
                {
                    healthInit.enemyHealth -= 5;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Glancing blow...";
                }
            } else if (dmgNum == 4)
            {
                if (gameObject.CompareTag("lightning"))
                {
                    healthInit.enemyHealth -= 50;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "DECIMATED!";
                } else if (gameObject.CompareTag("water") || gameObject.CompareTag("fire"))
                {
                    healthInit.enemyHealth -= 15;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Slightly more effective!";
                } else
                {
                    healthInit.enemyHealth -= 25;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Critical hit!";
                }
            } else
            {
                if (gameObject.CompareTag("lightning"))
                {
                    healthInit.enemyHealth -= 20;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Effective hit!";
                } else if (gameObject.CompareTag("water") || gameObject.CompareTag("fire"))
                {
                    healthInit.enemyHealth -= 5;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "Not very effective..";
                } else
                {
                    healthInit.enemyHealth -= 10;
                    healthCount2.text = "Health: " + healthInit.enemyHealth;
                    playerCombatIndicator.text = "bop";
                }
            }
            gameObject.SetActive(false);
            Invoke("enemyAttack", 1f);
            cards.SetActive(false);
        } else
        {
            playerHealthCount.text = "dead boi";
            gameObject.SetActive(false);
        }
    }

    public void enemyAttack()
    {
        int dmgNum = RandomNumberGenerator.GetInt32(1, 5);
        if (healthInit.enemyHealth > 0)
        {
            if (dmgNum == 1)
            {
                healthInit.playerHealth -= 5;
                playerHealthCount.text = "Health: " + healthInit.playerHealth;
                combatIndicator2.text = "Glancing blow...";
                gameObject.SetActive(true);
            } else if (dmgNum == 4)
            {
                healthInit.playerHealth -= 20;
                playerHealthCount.text = "Health: " + healthInit.playerHealth;
                combatIndicator2.text = "Critical hit!";
                gameObject.SetActive(true);
            } else
            {
                healthInit.playerHealth -= 10;
                playerHealthCount.text = "Health: " + healthInit.playerHealth;
                combatIndicator2.text = "bop";
                gameObject.SetActive(true);
            }
        if (isCard)
            {
                cards.SetActive(true);
            } else
            {
                items.SetActive(true);
            }
        
        } else
        {
            healthCount2.text = "Perishable";
            gameObject.SetActive(false);
        }
        
    }

    public void hitAnim()
    {
        hitState hits;
        hits = hitState.playerHit;

        anim.SetInteger("hitState", (int)hits);
        Invoke("idleAnim", .5f);
    }

    public void idleAnim()
    {
        hitState hits;
        hits = hitState.idle;

        anim.SetInteger("hitState", (int)hits);
    }

    public void Delay()
    {
        isCard = false;
        Invoke("enemyAttack", 1);
        items.SetActive(false);
    }

    /*public void enemyHitAnim()
    {
        enemyHitState hits2;
        hits2 = enemyHitState.enemyHit;

        anim2.SetInteger("enemyHitState", (int)hits2);
        Invoke("enemyIdleAnim", .5f);
    }

    public void enemyIdleAnim()
    {
        hitState hits2;
        hits2 = hitState.idle;

        anim2.SetInteger("enemyHitState", (int)hits2);
    }
    */
}

