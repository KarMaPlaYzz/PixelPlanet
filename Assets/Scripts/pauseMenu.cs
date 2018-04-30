using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
	public GameObject landerShip;
	 
    public AudioSource audioSource;
	private deathChecker death;
 

	void Start()
	{
		death = FindObjectOfType<deathChecker> ();
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
        GameIsPaused = false;
        audioSource.volume += 1f;
    }

    public void Pause()

	{
       // landerShip = GameObject.Find ("LanderShip");

		if (GameObject.Find ("LanderShip").activeSelf && death.dead == false) {
			pauseMenuUI.SetActive (true);
			Time.timeScale = 0.01f;
			GameIsPaused = true;
			audioSource.volume = 0.25f;
		} 
    }
}
