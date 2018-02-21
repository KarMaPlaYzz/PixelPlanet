using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public GameObject mainMenuOverlay;
    public GameObject aboutOverlay;
    public GameObject shipOverlay;
    public GameObject timer;

    public GameObject planet;
    public GameObject landerShip;

	public void Play()
    {
        mainMenuOverlay.SetActive(false);
        planet.SetActive(true);
        landerShip.SetActive(true);
        timer.SetActive(true);
    }

    public void About()
    {
        aboutOverlay.SetActive(true);
        mainMenuOverlay.SetActive(false);
    }

    public void Ship()
    {
        shipOverlay.SetActive(true);
        mainMenuOverlay.SetActive(false);
    }

    public void Back()
    {
        mainMenuOverlay.SetActive(true);
        aboutOverlay.SetActive(false);
        shipOverlay.SetActive(false);
        planet.SetActive(false);
        landerShip.SetActive(false);
    }
}
