using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

    private GameObject landerShip;
    private mainMenu _mainMenu;

    private void Start()
    {
        landerShip = GameObject.Find("LanderShip");
        _mainMenu = FindObjectOfType<mainMenu>();
    }

    public void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            landerShip.SetActive(false);
            _mainMenu.Died();
        }
    }
}
