using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public bool move = false;
	public bool back = false;
	float time;
	float time1;
	Vector3 targetPosition ;
	Vector3 targetPosition1 ;
	float smoothTime = 1.0F;
	//private startPosition;
	private Vector3 velocity = Vector3.zero;


	// Use this for initialization
	void Start () 
	{
		/*
		targetPosition = transform.TransformPoint (new Vector3 (10, 0, -20.0F));
		targetPosition1 = transform.TransformPoint (new Vector3 (-10, 0, 20.0F));
		*/
		//startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

	
		if (move) 
		{
			if (time < 30) 
			{
				Vector3 targetPosition = transform.TransformPoint (new Vector3 (0, 0, -22.0F));

				transform.Rotate (new Vector3 (0, 0.6F, 0));

				transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
				time++;
			} else {
				move = false;
				time = 0;
			}

		} 
		else if (back) 
		{
			if (time < 30) 
			{

				transform.Rotate (new Vector3 (0, -0.6F, 0));

				Vector3 targetPosition = transform.TransformPoint (new Vector3 (0, 0, 22.0F));
		
				transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
				time++;

			} else {
				move = false;
				back = false;
				time = 0;
			}

		}


}

	void moveTo()
	{
		move = true;
    }

	void moveBack()
	{
		back = true;
	}


}
