using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUpdate : MonoBehaviour {
	
	private int Score;
	public GameObject mainMenu;
	public Text scoreText;
	public Text highScoreText;
    public GameObject planetRandom;
	public GameObject player;
	public bool stillAlive;
    
    private deathChecker deathChecker;
    private timerDisplay timerDisplay;

    public bool timerReset;

	void Start()
	{stillAlive = true;
        deathChecker = FindObjectOfType<deathChecker>();
		timerDisplay = FindObjectOfType<timerDisplay> ();
		Score = 0;
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			highScoreText.text = "High Score : " + PlayerPrefs.GetInt ("HighScoreModeL_A_L", 0).ToString ();
		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			highScoreText.text = "High Score : " + PlayerPrefs.GetInt ("HighScoreModeC_C", 0).ToString ();
		}

	}
	void Update()
	{
		if (deathChecker.dead == true) {
			Debug.Log ("The player is dead");
			 
		
		}
		else
		{
			Debug.Log ("The player is still alive");
			 
		}
		scoreText.text = "Score: " + Score;
		HighScoreUpdate ();
	}

    void OnTriggerExit2D(Collider2D col)//score Update trigger
	{
		if (!deathChecker.dead && timerDisplay.timer > 1)
        {
            if (col.gameObject.tag == "scoreOrbit" && FindObjectOfType<playerController>().nextPlanet)
			{ Debug.Log ("The value is " + FindObjectOfType<playerController> ().nextPlanet);
				 
					Score++;

                StartCoroutine(switchPlanet());
				planetRandom.SetActive (true);
                timerReset = true;
            }
        }
	}
	void OnTriggerEnter2D(Collider2D col)
	{
        FindObjectOfType<playerController>().nextPlanet = false;
        timerReset = false;
    }

	void HighScoreUpdate()
	{if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (Score > PlayerPrefs.GetInt ("HighScoreModeL_A_L", 0)) {
				PlayerPrefs.SetInt ("HighScoreModeL_A_L", Score);
				highScoreText.text = "High Score : " + Score.ToString ();

			}
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (Score > PlayerPrefs.GetInt ("HighScoreModeC_C", 0)) {
				PlayerPrefs.SetInt ("HighScoreModeC_C", Score);
				highScoreText.text = "High Score : " + Score.ToString ();

			}
		}
	}
	public void ResetHighScore()
	{
		PlayerPrefs.SetInt("HighScoreModeC_C",0);
		PlayerPrefs.SetInt("HighScoreModeL_A_L",0);
		mainMenu.GetComponent<mainMenu> ().highScoreCollectCoins.text = mainMenu.GetComponent<mainMenu> ().highScoreCollectCoins.text + " " + 0;
		mainMenu.GetComponent<mainMenu> ().highScoreLandNLeave.text = mainMenu.GetComponent<mainMenu> ().highScoreLandNLeave.text + " " + 0;
		PlayerPrefs.SetInt ("firstTimeCheck", 0);
		highScoreText.text = "High Score : " + 0;
	}

    IEnumerator switchPlanet()
    {
        Destroy(GameObject.FindWithTag("PlanetRandomizer"));
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindWithTag("Planet"));
        yield return new WaitForSeconds(0.5f);
		Instantiate(planetRandom, new Vector3 (0,0), Quaternion.identity);
		//planetRandom.SetActive (true);



    }
}
