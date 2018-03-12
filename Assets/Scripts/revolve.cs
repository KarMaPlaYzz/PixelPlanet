using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {

    public GameObject landerShip;
    private mainMenu _mainMenu;

    public bool removePlayer = false;

    public GameObject planet;
    public GameObject asteroid;
	public float rotationSpeedPlanet;
	public bool clockwise;

    public float randomRotate;

	void Start()
	{
        asteroid = gameObject;
        randomRotate = Random.Range(-0.2f, 1f);
    }
	void Update()
	{
        if (!pauseMenu.GameIsPaused)
        {
            if (removePlayer == true)
            {
                landerShip.SetActive(false);
            }

            _mainMenu = FindObjectOfType<mainMenu>();
            landerShip = GameObject.Find("LanderShip");

            if (clockwise)
            {

                asteroid.transform.Rotate(0, 0, randomRotate);
                transform.RotateAround(planet.transform.position, transform.forward, -rotationSpeedPlanet * Time.deltaTime);
            }
            else
            {

                asteroid.transform.Rotate(0, 0, randomRotate);
                transform.RotateAround(planet.transform.position, transform.forward, rotationSpeedPlanet * Time.deltaTime);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            removePlayer = true;
            landerShip.SetActive(false);
            _mainMenu.Died();
        }
    }
}
