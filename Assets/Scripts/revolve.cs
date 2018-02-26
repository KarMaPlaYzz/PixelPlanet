using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {

	public GameObject planet;
    public GameObject asteroid;
	public float rotationSpeedPlanet;
	public bool clockwise;
	void Start()
	{
        asteroid = gameObject;
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
