using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public GameObject pauseButton;

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

    public GameObject landerShip;

    public Animator myAnim;
    public Transform mainCam;
    public randomEventManager randomEventManager;
    public Vector2 centre;

    public GameObject leftThruster;
    public GameObject rightThruster;
    public GameObject mainThruster;

    private Vector3 planet = new Vector3(0, 0, 0);

    private deathChecker deathChecker;

    public Transform planetDistance;
	public GameObject CoinManager;

    private void Start()
	{CoinManager = GameObject.FindGameObjectWithTag ("Coin");
        leftThruster.SetActive(false);
        rightThruster.SetActive(false);
        mainThruster.SetActive(false);

        leftThruster.transform.parent = landerShip.transform;
        rightThruster.transform.parent = landerShip.transform;
        mainThruster.transform.parent = landerShip.transform;

        deathChecker = FindObjectOfType<deathChecker>();
        pauseButton.SetActive(true);
        centre = planet;
        myAnim = GetComponent<Animator>();
        randomEventManager = FindObjectOfType<randomEventManager>();
    }

    private void Update()
	{CoinManager = GameObject.FindGameObjectWithTag ("Coin");
        if (!deathChecker.dead)
        {
            //get user input
            if (!pauseMenu.GameIsPaused)
            {
                //if user input is the left arrow key
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //decrement radius by gravity
                    if (canMove == true)
                    {
                        rightThruster.SetActive(true);

                        rotateSpeed = 0.5f;
                        glidingDirection = -2f;

                        //increment the angle by (-rotateSpeed * deltaTime)
                        angle += -rotateSpeed * Time.deltaTime;

                        lastGlidingDirection = glidingDirection;

                        if (Input.GetKeyUp(KeyCode.UpArrow))
                        {
                            mainThruster.SetActive(false);
                        }
                    }
                }

                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    rightThruster.SetActive(false);
                }

                //else if user input is the right arrow key
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    //decrement radius by gravity
                    if (canMove == true)
                    {
                        leftThruster.SetActive(true);

                        rotateSpeed = 0.5f;
                        glidingDirection = 2f;

                        //increment angle by (rotateSpeed * deltaTime)
                        angle += rotateSpeed * Time.deltaTime;

                        lastGlidingDirection = glidingDirection;

                        if (Input.GetKeyUp(KeyCode.UpArrow))
                        {
                            mainThruster.SetActive(false);
                        }
                    }
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    mainThruster.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    leftThruster.SetActive(false);
                }

                //else if user input is the up arrow key
                else if (Input.GetKey(KeyCode.UpArrow) && radius <= 17f)
                {
                    //increment radius by gravity
                    radius += 3f * Time.deltaTime;

                    mainThruster.SetActive(true);
                }

                //makes the lander fall
                radius -= gravity;

                //makes the lander move with the planet
                if (spinWithPlanet == true)
                {
                    leftThruster.SetActive(false);
                    rightThruster.SetActive(false);
                    mainThruster.SetActive(false);
                    angle += -randomEventManager.rotationSpeed / 57.51f * Time.deltaTime;
                }

                Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

                transform.position = centre + offset;

                Vector2 diff = planet - transform.position;

                diff.Normalize();

                //makes the landership look at the planet
                transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 270);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
	{
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (other.gameObject.tag == "Planet") {
				nextPlanet = true;
				glidingDirection = 0f;
				spinWithPlanet = true;
				canMove = false;
				gravity = 0f;
			}
		} 
	else if (SceneManager.GetActiveScene ().buildIndex == 2)
		{

			if (other.gameObject.tag == "Planet" && CoinManager.GetComponent<Coin>().coinsStillLeft == false) {
				nextPlanet = true;
				glidingDirection = 0f;
				spinWithPlanet = true;
				canMove = false;
				gravity = 0f;
			} else if (other.gameObject.tag == "Planet" && CoinManager.GetComponent<Coin>().coinsStillLeft == true) {
				nextPlanet = false;
				glidingDirection = 0f;
				spinWithPlanet = true;
				canMove = false;
				gravity = 0f;
			}
		}

    }

    private void OnCollisionExit2D(Collision2D other)
	{
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (other.gameObject.tag == "Planet") {
				nextPlanet = true;
				canMove = true;
				gravity = 0.016f;
				spinWithPlanet = false;
			}
		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (other.gameObject.tag == "Planet" && CoinManager.GetComponent<Coin>().coinsStillLeft == false) {
				nextPlanet = true;
				canMove = true;
				gravity = 0.016f;
				spinWithPlanet = false;	
			} else if (other.gameObject.tag == "Planet" && CoinManager.GetComponent<Coin>().coinsStillLeft == true) {
				nextPlanet = false;
				canMove = true;
				gravity = 0.016f;
				spinWithPlanet = false;	
			}
		}
	}
}