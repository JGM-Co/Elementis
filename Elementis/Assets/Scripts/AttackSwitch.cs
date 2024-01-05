using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSwitch : MonoBehaviour
{
    public GameObject attack;
    public GameObject use;
    public GameObject cards;
    public GameObject items;
    // Start is called before the first frame update
    private void Start()
    {
        attack.SetActive(true);
        use.SetActive(true);
        cards.SetActive(false);
        items.SetActive(false);
    }

    public void AttackClick()
    {
        use.SetActive(true);
        attack.SetActive(false);
        cards.SetActive(true);
        items.SetActive(false);
    }
}
