﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	
	public float moveSpeed=10;
	public float jumpSpeed=10;
	public float fallSpeedMax=-10;
	public float fallAcceleration=2;
	
	
	float yVelocity;
	float horizontal;
	
	Animator animator;
	GroundDetection groundDetection;
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
		groundDetection=GetComponentInChildren<GroundDetection>();
	}

	public void UpdateMove () {
		
		Vector2 move = new Vector3(horizontal,yVelocity);
		rigidbody2D.velocity=move;
		
		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", yVelocity);
		//		Debug.Log(horizontal+" "+yVelocity);
		//		Debug.Log(rigidbody2D.velocity);
		
		yVelocity=Mathf.Clamp(yVelocity-fallAcceleration*Time.deltaTime, groundDetection.IsGrouded()?0:fallSpeedMax, jumpSpeed);
	}


	public void Move(float direction){
		horizontal=Mathf.Clamp(direction,-1,1)*moveSpeed;
	}

	public void Jump(bool jump){
		if(jump&&groundDetection.IsGrouded()){
			yVelocity=jumpSpeed;
		}
	}
}
