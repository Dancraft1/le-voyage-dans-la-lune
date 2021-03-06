﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour {

	[SerializeField] public AnimationCurve jumpCurve;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isJumping)
		{
			Vector2 newPosition = new Vector2(transform.position.x, jumpCurve.Evaluate(jumpFrame/(jumpTime*60)));
			GetComponent<Rigidbody2D>().MovePosition(newPosition);
			jumpFrame++;
			if(jumpCurve.length < (jumpFrame/(jumpTime*60)))
				isJumping = false;
		}
	}

	void Update()
	{
		if(Input.GetKeyDown("space"))
			startJumping();
	}

	bool isJumping = false;
	int jumpFrame;
	float jumpTime = 1;
	Vector2 initialposition;
	public void startJumping()
	{
		initialposition = transform.position;
		isJumping = true;
		jumpFrame = 0;
	}
}
