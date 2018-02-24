using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {

	public GameObject planet;
	public float rotationSpeed;
	public bool clockwise;
	 
	void Update()
	{
		if (clockwise) {
		
			transform.RotateAround (planet.transform.position, transform.forward, -rotationSpeed * Time.deltaTime);
		} else {
			transform.RotateAround (planet.transform.position, transform.forward, rotationSpeed * Time.deltaTime);
		}
	}

}
