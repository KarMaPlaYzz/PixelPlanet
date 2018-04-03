using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    public GameObject particleSystem;
    public ParticleSystem pSystem;

    //private int coinsCollected;
    public bool isCollected;

    // Use this for initialization
    void Start() {

        //coinsCollected = 0;
        isCollected = false;

    }

    // Update is called once per frame
    void Update() {
		if (this.transform.parent.gameObject.activeSelf) {
			particleSystem = GameObject.Find ("Particle System");
			pSystem = particleSystem.GetComponent<ParticleSystem> ();
		}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {

            pSystem.Play();

            isCollected = true;
            if (FindObjectOfType<timerDisplay>().timer < 30f)
            {
                FindObjectOfType<timerDisplay>().timer += 5;

                if (FindObjectOfType<timerDisplay>().timer > 30f)
                {
                    FindObjectOfType<timerDisplay>().timer = 30;
                }
            }
            gameObject.SetActive(false);

        }
    }
}
