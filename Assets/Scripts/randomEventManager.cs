using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class randomEventManager : MonoBehaviour {
    
    //Inspector Variables/////////////////////////////
    [SerializeField]
    private GameObject planetObject;
    [SerializeField]
    private float minRotationSpeed;
    [SerializeField]
    private float maxRotationSpeed;
    //Inspector Variables/////////////////////////////

    public float rotationSpeed;

    /////////////////////////////////////////////////////////////////////////////////////////////
    //Method called once at the start of the scene or object creation.
    private void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed) * randomFactor();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    //Method called every frame while the object is active
    private void Update()
	{if (!pauseMenu.GameIsPaused) {
			planetObject.transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
		} 
	
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    //Returns a random number either 1 or -1
    private float randomFactor ()
    {
        if (Random.Range(0, 1) > 0.5)
        {
            return 1f;
        }
        else
        {
            return -1f;
        }
    }
}
