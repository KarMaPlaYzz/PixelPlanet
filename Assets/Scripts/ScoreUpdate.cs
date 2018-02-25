using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {
	
	
	private int Score;
	public Text scoreText;
	public Text highScoreText;
	private bool hasExited;
    public GameObject planetRandom;
	public GameObject player;

	void Start()
	{
		Score = 0;
		highScoreText.text = "High Score : "+PlayerPrefs.GetInt ("HighScore", 0).ToString ();
	}
	void Update()
	{
		scoreText.text = "Score: " + Score;
		HighScoreUpdate ();
	}

    void OnTriggerExit2D(Collider2D col)//score Update trigger
	{
		if (col.gameObject.tag == "scoreOrbit"  && !hasExited && !player.GetComponent<playerController>().needToLand && player.GetComponent<playerController>().landed) {
			Score++;
			hasExited = true;
            StartCoroutine(switchPlanet());
            player.GetComponent<playerController>().landed = false;
        }
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		hasExited = false;
		player.GetComponent<playerController> ().needToLand = true;
	}

	void HighScoreUpdate()
	{
		if (Score > PlayerPrefs.GetInt ("HighScore", 0)) {
			PlayerPrefs.SetInt ("HighScore", Score);
			highScoreText.text = "High Score : "+Score.ToString ();

		}
	}
	public void ResetHighScore()
	{
		PlayerPrefs.DeleteAll ();
		highScoreText.text = "High Score : " + 0;
	}

    IEnumerator switchPlanet()
    {
        Destroy(GameObject.FindWithTag("PlanetRandomizer"));
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindWithTag("Planet"));
        yield return new WaitForSeconds(0.5f);
        Instantiate(planetRandom, new Vector3 (0,0), Quaternion.identity);
    }
}
