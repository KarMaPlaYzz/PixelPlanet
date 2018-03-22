using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUpdate : MonoBehaviour {
	
	private int Score;

	public Text scoreText;
	public Text highScoreText;
    public GameObject planetRandom;
	public GameObject player;

    private deathChecker deathChecker;
    private timerDisplay timerDisplay;

    public bool timerReset;

	void Start()
	{
        deathChecker = FindObjectOfType<deathChecker>();
		Score = 0;
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			highScoreText.text = "High Score : " + PlayerPrefs.GetInt ("HighScoreModeL_A_L", 0).ToString ();
		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			highScoreText.text = "High Score : " + PlayerPrefs.GetInt ("HighScoreModeC_C", 0).ToString ();
		}
	}
	void Update()
	{
		scoreText.text = "Score: " + Score;
		HighScoreUpdate ();
	}

    void OnTriggerExit2D(Collider2D col)//score Update trigger
	{
        if (!deathChecker.dead)
        {
            if (col.gameObject.tag == "scoreOrbit" && FindObjectOfType<playerController>().nextPlanet)
            {
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
		PlayerPrefs.SetInt("HighScore",0);
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
