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

	void Start()
	{
		centreX = this.transform.parent.transform.position.x;
		centreY=this.transform.parent.transform.position.y;
	}
	void Update()
	{
		this.transform.position=new Vector2(centreX+(horizontalRadius*Mathf.Cos(alpha*0.005f)),centreY+(verticalRadius*Mathf.Sin(alpha*0.005f)));
		alpha += speed;
	}
}
