using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthInit : MonoBehaviour
{
    [SerializeField] public static int playerHealth, enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        enemyHealth = 100;
    }
}
