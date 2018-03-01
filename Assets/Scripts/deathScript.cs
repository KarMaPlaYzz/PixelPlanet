using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

    private GameObject landerShip;

    private void Start()
    {
        landerShip = GameObject.Find("LanderShip");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            landerShip.SetActive(false);
        }
    }
}
