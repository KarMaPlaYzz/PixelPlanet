using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {
	
	 
	private int Score;
	public Text scoreText;
	public Text highScoreText;
	private bool hasExited;

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
		if (col.gameObject.tag == "scoreOrbit"  && !hasExited) {
			Score++;
			hasExited = true;
		}
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
}
