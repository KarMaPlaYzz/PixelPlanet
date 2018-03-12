using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerDisplay : MonoBehaviour {

    public float timer;
    public Text timerText;

    public playerController playerContr;

	// Use this for initialization
	void Start () {
        timer = 30;
        playerContr = FindObjectOfType<playerController>();
	}
	
	// Update is called once per frame
	void Update () {

            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0");

        if (!pauseMenu.GameIsPaused)
        {
            if (timer < 0)
            {
                timerText.text = "YOU LOST!";

                timer = 0;
            }

            if (playerContr.radius > 12.4f)
            {
                timer = 30;
            }
        }
	}
}