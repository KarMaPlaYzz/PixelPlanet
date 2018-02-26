using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {

	public GameObject planet;
    public GameObject asteroid;
	public float rotationSpeedPlanet;
	public bool clockwise;

    public int randomPlace;

	void Start()
	{
        asteroid = gameObject;
        randomPlace = Random.Range(1, 8);
    }
	void Update()
	{
        if (clockwise) {

            asteroid.transform.Rotate(0, 0, 1f);
            transform.RotateAround(planet.transform.position, transform.forward, -rotationSpeedPlanet * Time.deltaTime);
		} else {

            asteroid.transform.Rotate(0, 0, 0.5f);
            transform.RotateAround (planet.transform.position, transform.forward, rotationSpeedPlanet * Time.deltaTime);
        }
	}

}
