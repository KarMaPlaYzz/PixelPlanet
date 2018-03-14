using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {
    
    private mainMenu _mainMenu;

    private void Start()
    {
        _mainMenu = FindObjectOfType<mainMenu>();
    }

    public void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _mainMenu.Died();
        }
    }
}
