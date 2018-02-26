using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveRandomiser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
			int directionRandomiser=Random.Range(0,2);
		int speedRandomiser = Random.Range (12, 16); 
		foreach (Transform asteroid in transform){
			asteroid.GetComponent<revolve> ().rotationSpeedPlanet = speedRandomiser;	
		if (directionRandomiser == 0) {
				asteroid.GetComponent<revolve> ().clockwise = true;
			} else {
				asteroid.GetComponent<revolve> ().clockwise = false;
			}
			 
		}
		 }
	
	 
}
