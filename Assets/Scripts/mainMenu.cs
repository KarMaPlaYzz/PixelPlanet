using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public GameObject mainMenuOverlay;
    public GameObject aboutOverlay;
    public GameObject shipOverlay;
    public GameObject timer;

    public GameObject planetRandomizer;
    public GameObject landerShip;
	public GameObject score;
	public GameObject highScore;
	public GameObject ResetHighScore;


	public void Play()
    {
        mainMenuOverlay.SetActive(false);
        planetRandomizer.SetActive(true);
        landerShip.SetActive(true);
        timer.SetActive(true);
		score.SetActive (true);
		highScore.SetActive (true);
		ResetHighScore.SetActive (true);
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
        planetRandomizer.SetActive(false);
        landerShip.SetActive(false);
    }
}
