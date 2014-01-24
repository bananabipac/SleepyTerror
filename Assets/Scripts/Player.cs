using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public float moveSpeed=10;
	public float jumpSpeed=10;
	public float fallSpeedMax=-10;
	public float fallAcceleration=2;

	
	float yVelocity;


	Animator animator;

	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");

		if(Input.GetButtonDown("Jump")){
			yVelocity=jumpSpeed;
			Debug.Log("Jump");
		}
		
		Vector2 move = new Vector3(horizontal*moveSpeed,yVelocity);
		rigidbody2D.velocity=move;

		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", yVelocity);
//		Debug.Log(horizontal+" "+yVelocity);
		Debug.Log(rigidbody2D.velocity);

		yVelocity=Mathf.Clamp(yVelocity-fallAcceleration*Time.deltaTime, fallSpeedMax, jumpSpeed);
	}
}
