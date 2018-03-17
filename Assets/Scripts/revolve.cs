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
        planet = GameObject.FindGameObjectWithTag("Planet");
        asteroid = gameObject;
        randomRotate = Random.Range(-0.2f, 1f);
        _mainMenu = FindObjectOfType<mainMenu>();
		//Vector3 randomHeight = new Vector3 (planet.transform.position.x + Random.Range (-.1f, .1f), planet.transform.position.y + Random.Range (-.1f, .1f), planet.transform.position.z);
    }
	void Update()
	{
        if (!pauseMenu.GameIsPaused)
        {
            if (clockwise)
            {

                asteroid.transform.Rotate(0, 0, randomRotate);
				transform.RotateAround(planet.transform.position+new Vector3(Random.Range(-1,1f),Random.Range(-1f,.1f),0), transform.forward, -rotationSpeedPlanet * Time.deltaTime);
            }
            else
            {

                asteroid.transform.Rotate(0, 0, randomRotate);
				transform.RotateAround(planet.transform.position+new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0), transform.forward, rotationSpeedPlanet * Time.deltaTime);
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
