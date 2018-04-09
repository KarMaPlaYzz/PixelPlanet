using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
	public GameObject landership;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (landership.activeSelf && landership.GetComponent<playerController> ().mainThruster.activeSelf ) {
			if (Camera.main.orthographicSize <= 25f) {
				Camera.main.orthographicSize += landership.GetComponent<playerController> ().radius * Time.deltaTime * 0.05f;
			}
		} else if(landership.activeSelf && !landership.GetComponent<playerController> ().mainThruster.activeSelf)  {
			if (Camera.main.orthographicSize >= 15f) {
				Camera.main.orthographicSize -= landership.GetComponent<playerController> ().radius * Time.deltaTime * 0.05f;
			}
		}
}
}
