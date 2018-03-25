using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {
	//private int coinsCollected;
	public bool isCollected;
	 
	// Use this for initialization
	void Start () {
		//coinsCollected = 0;
		isCollected=false;
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{ 
		if (col.gameObject.tag=="Player") {
			isCollected = true;
			Debug.Log ("Yeah!!");
			gameObject.SetActive (false);

		}
	}
}
