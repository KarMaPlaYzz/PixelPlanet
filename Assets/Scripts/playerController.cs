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

    public bool slideLeft = false;

    public float current;
    public float currentVelocity;
    public float smoothTime;
    public float maxSpeed;

    public randomEventManager randomEventManager;
    private float gravity = .01f;
    private Vector3 planet = new Vector3(0, 0, 0);
    private Vector2 centre;
    private float angle;

    private void Start()
    {
        centre = planet;
    }

    private void Update()
    {
        //get user input

        //if user input is the left arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //decrement radius by gravity
            if (canMove == true)
            {
                //increment radius by gravity
                radius -= gravity;
                
                //increment the angle by (-rotateSpeed * deltaTime)
                angle += Mathf.SmoothDamp(current , -rotateSpeed, ref currentVelocity, smoothTime, maxSpeed);

                if (slideLeft == true)
                {
                    StartCoroutine(glideLeft());
                }
            }

            //check if up arrow is pressed while moving
            if (Input.GetKey(KeyCode.UpArrow) && radius <= 9f && landed == true)
            {
                //increment radius by gravity
                radius += 3f * Time.deltaTime;
            }
        }
        //else if user input is the right arrow key
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //decrement radius by gravity
            if (canMove == true)
            {
                radius -= gravity;
                //increment angle by (rotateSpeed * deltaTime)
                angle += Mathf.SmoothDamp(current, rotateSpeed, ref currentVelocity, smoothTime, maxSpeed);
            }

            //check if up arrow is pressed while moving
            if (Input.GetKey(KeyCode.UpArrow) && radius <= 9f && landed == true)
            {
                //increment radius by gravity
                radius += 3f * Time.deltaTime;
            }
        }
        //else if user input is the up arrow key
        else if (Input.GetKey(KeyCode.UpArrow) && radius <= 9f && landed == true)
        {
            //increment radius by gravity
            radius += 3f * Time.deltaTime;

            if (landed == false)
            {
                canMove = true;
            }
        }
        
        //makes the lander fall
        radius -= gravity;

        //makes the lander move with the planet
        if (spinWithPlanet == true)
        {
            angle += -randomEventManager.rotationSpeed / 57.51f * Time.deltaTime;
        } else if (spinWithPlanet == false)
        {

        }

        //move the lander around the planet

        //create a new Vector2 object and set it's data members as sin(angle) and (cos(angle * radius)) respectively
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

        //set the position transformation equal to center + offset
        transform.position = centre + offset;

        //create a vector2 object from the difference of planet - position transformation
        Vector2 diff = planet - transform.position;

        //normalize diff
        diff.Normalize();

        //makes the landership look at the planet
        transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 270);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            landed = true;
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

    IEnumerator glideLeft()
    {
        yield return new WaitForSeconds(0);
        angle += Mathf.SmoothDamp(current, -rotateSpeed, ref currentVelocity, smoothTime, maxSpeed) / 2 * Time.deltaTime;
    }
}