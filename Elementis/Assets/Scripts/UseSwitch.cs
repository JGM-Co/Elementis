using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSwitch : MonoBehaviour
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
        items.SetActive(false);
        cards.SetActive(false);
    }

    public void useClick()
    {
        use.SetActive(false);
        attack.SetActive(true);
        items.SetActive(true);
        cards.SetActive(false);
    }
}
