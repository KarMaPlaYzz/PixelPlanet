using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject asteroid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(asteroid, transform.position, transform.rotation);

            StartCoroutine(Destroy());
        }
        
	}

    IEnumerator Destroy ()
    {
        yield return new WaitForSeconds(1.5f);
        asteroid.SetActive(false);
    }
}
