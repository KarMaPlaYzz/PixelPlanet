using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerDisplay : MonoBehaviour {

    public float timer;
    public Text timerText;
    private deathChecker deathChecker;
    private ScoreUpdate scoreUpdate;
	public bool addTime;
	public CollectCoin coin;
	// Use this for initialization
	void Start () {
		coin = gameObject.GetComponent<CollectCoin> ();
		if (SceneManager.GetActiveScene ().buildIndex == 1) 
		{
			timer = 30;
		} 
		else {
			timer = 30;
		}
        deathChecker = FindObjectOfType<deathChecker>();
        scoreUpdate = FindObjectOfType<ScoreUpdate>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pauseMenu.GameIsPaused) {
			timer -= Time.deltaTime;
		}
        timerText.text = "Time: " + timer.ToString("0");
		AddTime ();
		if (!pauseMenu.GameIsPaused) {
			if (timer < 0) {
				StartCoroutine (animationPlayer ());

				timer = 0;
			}

			if (scoreUpdate.timerReset == true) {
				
				timer = 30;
			}
		} 
		 
	}
	void AddTime()
	{
		if (addTime == true) {
			timer += 5;
		}
	}

    IEnumerator animationPlayer()
    {
        timerText.text = "YOU LOST!";

        deathChecker.landerShipAnim.SetBool("Dead", true);

        deathChecker.landersh.enabled = false;

        yield return new WaitForSeconds(0.2f);
    }
}