using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerDisplay : MonoBehaviour {

    public float timer;
    public Text timerText;
    
    private bool disableShip;

    private playerController playerContr;
    private deathChecker deathChecker;
    private ScoreUpdate scoreUpdate;

	// Use this for initialization
	void Start () {
        timer = 30;
        playerContr = FindObjectOfType<playerController>();
        deathChecker = FindObjectOfType<deathChecker>();
        scoreUpdate = FindObjectOfType<ScoreUpdate>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("0");

        if (!pauseMenu.GameIsPaused)
        {
            if (timer < 0)
            {
                StartCoroutine(animationPlayer());

                timer = 0;
            }

            if (scoreUpdate.timerReset == true)
            {
                timer = 30;
            }
        }
	}

    IEnumerator animationPlayer()
    {
        timerText.text = "YOU LOST!";

        deathChecker.landerShipAnim.SetBool("Dead", true);

        deathChecker.landersh.enabled = false;

        yield return new WaitForSeconds(0.2f);

        disableShip = true;
    }
}