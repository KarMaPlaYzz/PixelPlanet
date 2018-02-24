using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public bool canMove = true;
    public bool landed = false;
    public bool spinWithPlanet = false;

    public float radius = 9f;

    public Animator myAnim;

    public Transform mainCam;

    public float current;
    public float currentVelocity;
    public float smoothTime;
    public float maxSpeed;

    public float decrease = 1f;

    public randomEventManager randomEventManager;
    public float gravity = .5f;
    private Vector3 planet = new Vector3(0, 0, 0);
    public Vector2 centre;
    public float angle;
	public float glidingDirection=0;
	public float lastGlidingDirection;

    private void Start()
    {
        centre = planet;
        myAnim = GetComponent<Animator>();
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
                
				//increment the angle by (-rotateSpeed * deltaTime)
				angle += Mathf.SmoothDamp (current, -rotateSpeed, ref currentVelocity, smoothTime, maxSpeed);

				glidingDirection = -2f;

				lastGlidingDirection = glidingDirection;
				 
			}

			//check if up arrow is pressed while moving
			if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f && landed == true) {
				//increment radius by gravity
				radius += 2f * Time.deltaTime;
			}
		}

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(slideLeft());
        }

        //else if user input is the right arrow key
        else if (Input.GetKey (KeyCode.RightArrow)) {
			//decrement radius by gravity
			if (canMove == true) {
                //increment radius by gravity
                radius -= gravity;
				//increment angle by (rotateSpeed * deltaTime)
				angle += Mathf.SmoothDamp (current, rotateSpeed, ref currentVelocity, smoothTime, maxSpeed);

				glidingDirection = 2f;
				 
				lastGlidingDirection = glidingDirection;
			 
			}

			//check if up arrow is pressed while moving
			if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f && landed == true) {
				//increment radius by gravity
				radius += 2f * Time.deltaTime;
			}
		}

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(slideRight());
        }

        //else if user input is the up arrow key
        else if (Input.GetKey (KeyCode.UpArrow) && radius <= 16f && landed == true) {
			//increment radius by gravity
			radius += 2f * Time.deltaTime;

			if (landed == false) {
				canMove = true;
			}
		} else {
            angle += Mathf.SmoothDamp(current, rotateSpeed * glidingDirection * Time.deltaTime, ref currentVelocity, smoothTime, maxSpeed);
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
            landed = true;
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
			 
            canMove = true;
            gravity = 0.01f;
            spinWithPlanet = false;
        }
    }

    IEnumerator slideLeft()
    {
        yield return new WaitForSeconds(1f);

        if (glidingDirection < 0)
        {
            glidingDirection += decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection < 0)
        {
            glidingDirection += decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection < 0)
        {
            glidingDirection += decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection < 0)
        {
            glidingDirection += decrease;
        }
    }

    IEnumerator slideRight()
    {
        yield return new WaitForSeconds(1f);

        if (glidingDirection > 0)
        {
            glidingDirection -= decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection > 0)
        {
            glidingDirection -= decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection > 0)
        {
            glidingDirection -= decrease;
        }
        yield return new WaitForSeconds(1f);

        if (glidingDirection > 0)
        {
            glidingDirection -= decrease;
        }
    }
}