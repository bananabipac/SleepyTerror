﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MaxSpeed = 10f;
	bool facingRight = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float Move = Input.GetAxis("Horizontal");

		rigidbody2D.velocity = new Vector2(Move * MaxSpeed, rigidbody2D.velocity.y);
	
	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
