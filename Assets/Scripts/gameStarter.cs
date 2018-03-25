using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStarter : MonoBehaviour {

    public mainMenu mainMenuUI;

	// Use this for initialization
	void Start () {
        if (mainMenuUI.landAndLeave == true)
        {
            mainMenuUI.LandAndLeave();
            mainMenuUI.countdownStart = true;
        }

        if (mainMenuUI.collectCoinLevel == true)
        {
            mainMenuUI.CollectCoin();
            mainMenuUI.countdownStart = true;
        }
	}
}
