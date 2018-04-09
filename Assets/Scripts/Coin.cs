using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour {

	public int coinsCollected;
	public bool coinsStillLeft;

	// Use this for initialization
	void Start () {
		coinsStillLeft = true;
		coinsCollected = 0;
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			this.gameObject.SetActive (true);
		} else {
			this.gameObject.SetActive (false);
		}
	}
	void CoinCheck()
	{
		foreach (Transform coin in transform) {
			if (coin.gameObject.activeSelf) {
				coinsStillLeft = true;
				break;
			} else {
				coinsStillLeft = false;
			}
				
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		CoinCheck ();
	}
}
