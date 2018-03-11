using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveRandomiser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localRotation = new Quaternion (transform.localRotation.x, transform.localRotation.y, Random.value, transform.localRotation.w); ;
		int directionRandomiser=Random.Range(0,2);

		//int speedRandomiser = Random.Range (12, 16); //

		foreach (Transform asteroid in transform){

			asteroid.GetComponent<revolve> ().rotationSpeedPlanet =Random.Range (13, 17);	

		if (directionRandomiser == 0) {
				asteroid.GetComponent<revolve> ().clockwise = true;
			} else {
				asteroid.GetComponent<revolve> ().clockwise = false;
			}
			 
		}
	}
}