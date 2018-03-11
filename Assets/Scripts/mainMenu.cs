using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mainMenu : MonoBehaviour {

    public GameObject mainMenuOverlay;
    public GameObject deathOverlay;
    public GameObject aboutOverlay;
    public GameObject shipOverlay;
    public GameObject countdownMenuOverlay;
    public GameObject timer;
    public GameObject planetRandomizer;
    public GameObject landerShip;
	public GameObject score;
	public GameObject highScore;
	public GameObject ResetHighScore;

    public GameObject countdownTimerGb;
    public Text countdownTimer;
    public float countdownNumber = 3;
	public float countDownSpeed = 1.5f;
    public string countdownTimerDisp;
    public bool countdownStart = false;

    private void Start()
    {
        mainMenuOverlay.SetActive(true);
    }

    private void Update()
    {
        if (countdownStart == true)
		{
			mainMenuOverlay.SetActive(false);
			countdownNumber -= Time.deltaTime /countDownSpeed;
			countdownTimerDisp = Mathf.Ceil(countdownNumber).ToString();

			//countdownTimer.text = countdownTimerDisp;
			if (countdownNumber < 5 && countdownNumber >= 3) {
				countdownTimer.text ="Controls";
			} else {
				countdownTimer.text = countdownTimerDisp;
			}
            
            if (countdownNumber < 0.1f)
            {
                mainMenuOverlay.SetActive(false);
                planetRandomizer.SetActive(true);
            }

			if (countdownNumber <0)
			{
				countdownNumber = 0;
				countdownMenuOverlay.SetActive(false);
                
				landerShip.SetActive(true);
				timer.SetActive(true);
				score.SetActive(true);
				highScore.SetActive(true);
                //ResetHighScore.SetActive(true);
			}
		}
    }

    public void Play()
    {
        countdownMenuOverlay.SetActive(true);
        countdownStart = true;
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

    public void Died()
    {
        deathOverlay.SetActive(true);
    }
}
