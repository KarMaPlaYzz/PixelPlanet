using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {
    
    private mainMenu _mainMenu;

    public GameObject planet;
    public GameObject asteroid;
	public float rotationSpeedPlanet;
	public bool clockwise;

    public float randomRotate;

	void Start()
	{
        asteroid = gameObject;
        randomRotate = Random.Range(-0.2f, 1f);
        _mainMenu = FindObjectOfType<mainMenu>();
    }
	void Update()
	{
        if (!pauseMenu.GameIsPaused)
        {
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
            _mainMenu.Died();
        }
    }
}
