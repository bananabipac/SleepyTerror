using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {


	public float moveSpeed=10;
	public float jumpSpeed=10;
//	public float fallSpeedMin=-10;
	public float fallSpeedMax=-10;
	public float fallAcceleration=2;
	public Vector2 bumpForce;
	public bool isInCollider;
	public GameObject child;
	public float pv=1;
	public float bumpForceWhenHit=25;	float yVelocity;

	float horizontal, vertical;
	bool wallLeft,  wallRight;

	public Animator animator;

	GroundDetection groundDetection;

	// Use this for initialization
	public void Start () {
		InitBase(); 
	}

	public void InitBase(){
		//animator=GetComponent<Animator>();
		groundDetection=GetComponentInChildren<GroundDetection>();
	}

	public void FixedUpdate(){
		UpdateMove();
	}

	/*public void OnCollisionEnter2D(Collision2D coll) 
	{		
		isInCollider = true;
	}

	public void OnCollisionExit2D(Collision2D coll)
	{
		isInCollider = false;
	}*/
	
	public void UpdateMove () {
		
		Vector2 move = new Vector3(horizontal,yVelocity);
		rigidbody2D.velocity=move+bumpForce;

		if(wallLeft){
			animator.SetFloat("Horizontal", -yVelocity);
			animator.transform.rotation=Quaternion.Euler(0,0,270);
		}else if(wallRight){
			animator.SetFloat("Horizontal", yVelocity);
			animator.transform.rotation=Quaternion.Euler(0,0,90);
		}else{
			animator.SetFloat("Horizontal", horizontal);
			animator.SetFloat("Vertical", yVelocity);
			animator.transform.rotation=Quaternion.Euler(0,0,0);
		}
		wallLeft=false;
		wallRight=false;

		//		Debug.Log(horizontal+" "+yVelocity);
		//		Debug.Log(rigidbody2D.velocity);
		
		yVelocity=Mathf.Clamp(yVelocity-fallAcceleration*Time.deltaTime, groundDetection.IsGrouded()?0:fallSpeedMax, jumpSpeed);
		bumpForce-=bumpForce*0.1f;
	}


	public void Move(float direction){
		horizontal=direction*moveSpeed;
	}

	public void MoveOnWall(float direction, bool wallLeft, bool wallRight){
		yVelocity=direction*moveSpeed;
		this.wallLeft=wallLeft;
		this.wallRight=wallRight;
	}

	public void Jump(bool jump){
		if(jump&&groundDetection.IsGrouded()){
			yVelocity=jumpSpeed;
		}
	}

	public void Bump(Vector2 jump){
		bumpForce+=jump;
	}

	public void TakeDamage(GameObject hitter=null){
		if(hitter.layer==gameObject.layer)
			return;
		pv--;
		if(pv<=0){
			Destroy(gameObject);

		}else{
			if(hitter)
				bumpForce=(transform.position-hitter.transform.position).normalized*bumpForceWhenHit;
		}
	}
}

