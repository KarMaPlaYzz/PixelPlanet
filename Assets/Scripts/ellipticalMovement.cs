using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ellipticalMovement : MonoBehaviour {

	public float centreX;
	public float centreY;
	public float alpha;
	public float horizontalRadius;
	public float verticalRadius;
	public float speed;

    public GameObject landerShip;
    private mainMenu _mainMenu;

    private SpriteRenderer satellite;

	void Start()
	{
        satellite = GetComponent<SpriteRenderer>();
		centreX = this.transform.parent.transform.position.x;
		centreY = this.transform.parent.transform.position.y;
	}
	void Update()
	{
        if (!pauseMenu.GameIsPaused)
        {
            if (satellite.transform.position.y > 0.3f)
            {
                satellite.sortingOrder = 1;
            }

            if (satellite.transform.position.y < 0.3f)
            {
                satellite.sortingOrder = -1;
            }

            this.transform.position = new Vector2(centreX + (horizontalRadius * Mathf.Cos(alpha * 0.005f)), centreY + (verticalRadius * Mathf.Sin(alpha * 0.005f)));
            alpha += speed;
        }
	}
}
