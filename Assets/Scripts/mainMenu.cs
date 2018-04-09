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
    public GameObject landAndLeave;
    public GameObject collectCoin;
    public GameObject backButton;

	public Text highScoreLandNLeave;
	public Text highScoreCollectCoins;

    private deathChecker deathChecker;

    public GameObject controlsInstr;

    public GameObject countdownTimerGb;
    public Text countdownTimer;
    private float countdownNumber;
    public float countDownSpeed = 1.5f;
    public string countdownTimerDisp;
    public bool countdownStart = false;

    public bool landAndLeaveLevel;
    public bool collectCoinLevel;

	/*void Awake()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 1 || SceneManager.GetActiveScene ().buildIndex == 2) 
		{
			countdownStart = true;
		}
	}*/

    private void Start()

	{
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			DisplayHighScore ();
		}
		if (PlayerPrefs.GetInt("firstTimeCheck") == 0)
		{
			countdownNumber = 5;
		} else {
			countdownNumber = 3;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			mainMenuOverlay.SetActive (true);
		} else {
			countdownStart = true;
		}
	
        deathChecker = FindObjectOfType<deathChecker>();
	}

    private void Update()
    {
        if (countdownStart == true)
        {
			
			countdownMenuOverlay.SetActive (true);
            countdownNumber -= Time.deltaTime / countDownSpeed;
            countdownTimerDisp = Mathf.Ceil(countdownNumber).ToString();

            if (PlayerPrefs.GetInt("firstTimeCheck") == 0) {
				
                if (countdownNumber < 5 && countdownNumber >= 3) {
                    //countdownTimer.text = "Controls";
					countdownTimer.text = countdownTimerDisp;
					controlsInstr.SetActive(true);
                } else {
					
                    countdownTimer.text = countdownTimerDisp;
                }
            }
            else {
				controlsInstr.SetActive (false);
                countdownTimer.text = countdownTimerDisp;
            }

//			if (countdownNumber < 2f && countdownNumber<3)
//            {
//               // mainMenuOverlay.SetActive(false);
//                planetRandomizer.SetActive(true);
//                PlayerPrefs.SetInt("firstTimeCheck", 1);
//            }
//
//            if (countdownNumber > 2.9f && countdownNumber < 3f)
//            {
//                controlsInstr.SetActive(false);
//                countdownTimerGb.SetActive(true);
//            }
//
//            if (countdownNumber > 1.9f && countdownNumber < 2f)
//            {
//                countdownTimerGb.SetActive(false);
//                countdownTimerGb.SetActive(true);
//            }
//
//            if (countdownNumber > 0.9f && countdownNumber < 1f)
//            {
//                countdownTimerGb.SetActive(false);
//                countdownTimerGb.SetActive(true);
//            }

            if (countdownNumber < 0)
            {
                countdownNumber = 0;
                countdownMenuOverlay.SetActive(false);

                landerShip.SetActive(true);
                timer.SetActive(true);
                score.SetActive(true);
                highScore.SetActive(true);
                PlayerPrefs.SetInt("firstTimeCheck", 1);
                //ResetHighScore.SetActive(true);
            }
        }
    }

    public void Play()
    {
        landAndLeave.SetActive(true);
        collectCoin.SetActive(true);
        backButton.SetActive(true);

        if (landAndLeaveLevel == true || collectCoinLevel == true)
        {
            
        }
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        
        if (sceneName == "MenuUI")
        {
            if (landAndLeaveLevel == true)
            {
                SceneManager.LoadScene(1);
            }

            if (collectCoinLevel == true)
            {
                SceneManager.LoadScene(2);
            }
        }
        
        if (landAndLeaveLevel == true || collectCoinLevel == true)
        {
            countdownMenuOverlay.SetActive(true);
            if (PlayerPrefs.GetInt("firstTimeCheck") == 0)
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
            }
            countdownStart = true;
        }

        mainMenuOverlay.SetActive(false);
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

    public void Menu()
    {
        SceneManager.LoadScene("MenuUI");
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
        landAndLeave.SetActive(false);
        collectCoin.SetActive(false);
        backButton.SetActive(false);
    }

    public void TryAgain()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void LandAndLeave()
	{
        landAndLeaveLevel = true;
        
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MenuUI")
        {
            if (landAndLeaveLevel == true)
            {
                SceneManager.LoadScene(1);
            }
        }
        
        if (collectCoinLevel == true)
        {
            mainMenuOverlay.SetActive(false);
            countdownMenuOverlay.SetActive(true);
            if (PlayerPrefs.GetInt("firstTimeCheck") == 0)
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
            }
            countdownStart = true;
        }
    }

    public void CollectCoin()
    {
		 
        collectCoinLevel = true;

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MenuUI")
        {
            if (collectCoinLevel == true)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (collectCoinLevel == true)
        {
            mainMenuOverlay.SetActive(false);
            countdownMenuOverlay.SetActive(true);
            if (PlayerPrefs.GetInt("firstTimeCheck") == 0)
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                countdownMenuOverlay.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
            }
            countdownStart = true;
        }
    }

	void DisplayHighScore()
	{
		highScoreLandNLeave.text = highScoreLandNLeave.text+" "+PlayerPrefs.GetInt ("HighScoreModeL_A_L").ToString();
		highScoreCollectCoins.text=highScoreCollectCoins.text+" "+PlayerPrefs.GetInt ("HighScoreModeC_C").ToString();
	}
}
