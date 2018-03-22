using UnityEngine;
using UnityEngine.SceneManagement;
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

    private deathChecker deathChecker;

    public GameObject controlsInstr;
    
    public GameObject countdownTimerGb;
    public Text countdownTimer;
    public float countdownNumber = 3;
	public float countDownSpeed = 1.5f;
    public string countdownTimerDisp;
    public bool countdownStart = false;

    private void Start()
    {
        mainMenuOverlay.SetActive(true);
        deathChecker = FindObjectOfType<deathChecker>();
    }

    private void Update()
	{
        if (countdownStart == true)
		{
			mainMenuOverlay.SetActive(false);
			countdownNumber -= Time.deltaTime /countDownSpeed;
			countdownTimerDisp = Mathf.Ceil(countdownNumber).ToString();

			//countdownTimer.text = countdownTimerDisp;
			if (PlayerPrefs.GetInt ("firstTimeCheck") == 0) {
				if (countdownNumber < 5 && countdownNumber >= 3) {
					countdownTimer.text = "Controls";
				} else {
					countdownTimer.text = countdownTimerDisp;
				}
			} 
			else {
				countdownTimer.text = countdownTimerDisp;
			}

            if (countdownNumber < 2f)
            {
                mainMenuOverlay.SetActive(false);
                planetRandomizer.SetActive(true);
				PlayerPrefs.SetInt ("firstTimeCheck", 1);
            }

            if (countdownNumber > 2.9f && countdownNumber < 3.1f)
            {
                controlsInstr.SetActive(false);
            }

            if (countdownNumber > 2.0f && countdownNumber <2.1f)
            {
                countdownTimerGb.SetActive(false);
                countdownTimerGb.SetActive(true);
            }

            if (countdownNumber > 1.0f && countdownNumber < 1.1f)
            {
                countdownTimerGb.SetActive(false);
                countdownTimerGb.SetActive(true);
            }

            if (countdownNumber <0)
			{
				countdownNumber = 0;
				countdownMenuOverlay.SetActive(false);
                
				landerShip.SetActive(true);
				timer.SetActive(true);
				score.SetActive(true);
				highScore.SetActive(true);
				PlayerPrefs.SetInt ("firstTimeCheck", 1);
                //ResetHighScore.SetActive(true);
			}
		}
    }

    public void Play()
    {
		if (PlayerPrefs.GetInt ("firstTimeCheck") == 0) {
			countdownNumber = 5;
		} else {
			countdownNumber = 3;	
		}
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MenuUI")
        {
            SceneManager.LoadSceneAsync("LandAndLeave");
        }

        countdownMenuOverlay.SetActive(true);
		if (PlayerPrefs.GetInt ("firstTimeCheck") == 0) {
			countdownMenuOverlay.GetComponent<Transform> ().GetChild (1).gameObject.SetActive (true);
		} else {
			countdownMenuOverlay.GetComponent<Transform> ().GetChild (1).gameObject.SetActive (false); 
		}
        countdownStart = true;
    }

    IEnumerator animStart()
    {
        yield return new WaitForSeconds(1);
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

    public void TryAgain()
    {
        SceneManager.LoadScene("LandAndLeave");
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MenuUI");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Died()
    {
        deathOverlay.SetActive(true);
        deathChecker.dead = true;
    }
}
