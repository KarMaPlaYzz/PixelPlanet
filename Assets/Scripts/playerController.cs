using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float radius = 9f;
    public float current;
    public float currentVelocity;
    public float smoothTime;
    public float maxSpeed;
    public float angle;
    public float glidingDirection = 0;
    public float lastGlidingDirection;
    public float gravity = .016f;
    public float decrease = 1f;

    public bool canMove = true;
    public bool spinWithPlanet = false;
    public bool nextPlanet = false;

    public Animator myAnim;
    public Transform mainCam;
    public randomEventManager randomEventManager;
    public Vector2 centre;
    
    private Vector3 planet = new Vector3(0, 0, 0);

    private void Start()
    {
        centre = planet;
        myAnim = GetComponent<Animator>();
        randomEventManager = FindObjectOfType<randomEventManager>();
    }

    private void Update()
    {
        //get user input

        //if user input is the left arrow key
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//decrement radius by gravity
			if (canMove == true)
            {
                //increment radius by gravity
                radius -= gravity;

                rotateSpeed = 0.7f;
                glidingDirection = -2f;

                //increment the angle by (-rotateSpeed * deltaTime)
                angle += -rotateSpeed * Time.deltaTime;

				lastGlidingDirection = glidingDirection;
                
			}

			//check if up arrow is pressed while moving
			if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f) {
				//increment radius by gravity
				radius += 3f * Time.deltaTime;
                rotateSpeed = 0.7f;
                glidingDirection = 0f;
            }
        }

        //else if user input is the right arrow key
        else if (Input.GetKey (KeyCode.RightArrow)) {
			//decrement radius by gravity
			if (canMove == true) {
                //increment radius by gravity
                radius -= gravity;

                rotateSpeed = 0.7f;
                glidingDirection = 2f;

                //increment angle by (rotateSpeed * deltaTime)
                angle += rotateSpeed * Time.deltaTime;

                lastGlidingDirection = glidingDirection;

            }

            //check if up arrow is pressed while moving
			if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f) {
				//increment radius by gravity
				radius += 3f * Time.deltaTime;
			}
		}

        //else if user input is the up arrow key
		else if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f) {
			//increment radius by gravity
			radius += 3f * Time.deltaTime;
        }


        //makes the lander fall
        radius -= gravity;

        //makes the lander move with the planet
        if (spinWithPlanet == true)
        {
            angle += -randomEventManager.rotationSpeed / 57.51f * Time.deltaTime;
        }

        //move the lander around the planet
        
		Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

        //set the position transformation equal to center + offset
        transform.position = centre + offset;

        Vector2 diff = planet - transform.position;
        
        diff.Normalize();

        //makes the landership look at the planet
        transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 270);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            nextPlanet = true;
            glidingDirection = 0f;
            spinWithPlanet = true;
            canMove = false;
            gravity = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            nextPlanet = true;
            canMove = true;
            gravity = 0.016f;
            spinWithPlanet = false;
        }
    }
}