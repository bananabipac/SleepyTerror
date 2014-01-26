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
	bool wallLeft, wallRight, wallTop, wallTopL, wallTopR;

	public Animator animator;

	GroundDetection groundDetection;

	bool attack;

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
		if(attack)
			return;
		Vector2 move = new Vector3(horizontal,yVelocity);

//		Debug.Log( "wallLeft "+wallLeft+" wallRight "+wallRight+" wallTop "+wallTop+" wallTopL "+wallTopL+" wallTopR "+wallTopR);
		if(wallTop&&wallTopL&&wallTopR){
//			Debug.Log("top");
			animator.SetFloat("Horizontal", horizontal);
			animator.SetFloat("Vertical", 0);
			animator.transform.rotation=Quaternion.Euler(0,0,180);
			animator.transform.localPosition=new Vector3(0,-0.1f,0);

			move = new Vector3(horizontal,yVelocity)/2;
			if(horizontal!=0)
				animator.transform.localScale=new Vector3(-Mathf.Sign(horizontal)* Mathf.Abs(animator.transform.localScale.x),
				                                          animator.transform.localScale.y,animator.transform.localScale.z);
		}else if(wallLeft&&wallTopL){
//			Debug.Log("Left");
			animator.SetFloat("Horizontal", -yVelocity);
			animator.SetFloat("Vertical", 0);
			animator.transform.rotation=Quaternion.Euler(0,0,270);
			animator.transform.localPosition=new Vector3(0.05f,0,0);

			move = new Vector3(horizontal,yVelocity)/2;
			if(yVelocity!=0)
				animator.transform.localScale=new Vector3(-Mathf.Sign(yVelocity)* Mathf.Abs(animator.transform.localScale.x),
			                                          animator.transform.localScale.y,animator.transform.localScale.z);
		}else if(wallRight&&wallTopR){
//			Debug.Log("right");
			animator.SetFloat("Horizontal", yVelocity);
			animator.SetFloat("Vertical", 0);
			animator.transform.rotation=Quaternion.Euler(0,0,90);
			animator.transform.localPosition=new Vector3(-0.05f,0,0);

			move = new Vector3(horizontal,yVelocity)/2;
			if(yVelocity!=0)
				animator.transform.localScale=new Vector3(Mathf.Sign(yVelocity)* Mathf.Abs(animator.transform.localScale.x),
				                                          animator.transform.localScale.y,animator.transform.localScale.z);
		}else {
//			Debug.Log("bot");
			animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
			animator.SetFloat("Vertical", yVelocity);
			animator.transform.rotation=Quaternion.Euler(0,0,0);
			if(WorldType.Cute==WorldManager.Instance.GetCurrentWorld())
				animator.transform.localPosition=new Vector3(0,0,0);

			if(horizontal!=0)
				animator.transform.localScale=new Vector3(Mathf.Sign(horizontal)* Mathf.Abs(animator.transform.localScale.x),
				                                          animator.transform.localScale.y,animator.transform.localScale.z);
		}

		rigidbody2D.velocity=move+bumpForce;

		wallLeft=false;
		wallRight=false;
		wallTop=false;
		wallTopR=false;
		wallTopL=false;
		//		Debug.Log(horizontal+" "+yVelocity);
		//		Debug.Log(rigidbody2D.velocity);
		
		yVelocity=Mathf.Clamp(yVelocity-fallAcceleration*Time.deltaTime, groundDetection.IsGrouded()?0:fallSpeedMax, jumpSpeed);
		bumpForce-=bumpForce*0.1f;
	}


	public void Move(float direction){
		horizontal=direction*moveSpeed;
	}

	public void MoveOnWall(float direction, bool wallLeft, bool wallRight, bool wallTop, bool wallTopL, bool wallTopR){
		yVelocity=direction*moveSpeed;
		this.wallLeft=wallLeft;
		this.wallRight=wallRight;
		this.wallTop =wallTop;
		this.wallTopL=wallTopL;
		this.wallTopR=wallTopR;

	}

	public void Jump(bool jump){
		if(jump&&groundDetection.IsGrouded()&&!groundDetection.IsNope()){
			yVelocity=jumpSpeed;
			SoundManager.instance.PlaySound("Jump");
		}
	}

	public void Bump(Vector2 jump){
		bumpForce+=jump;
	}

	public void TakeDamage(GameObject hitter=null){
		if(pv<=0)
			return;
		if(hitter.layer==gameObject.layer)
			return;
		SoundManager.instance.PlaySound("Damage");
		pv--;
		if(hitter)
			bumpForce=(transform.position-hitter.transform.position).normalized*bumpForceWhenHit;
		if(pv<=0){
			if(this is Player)
				(this as Player).Die();
			else
				Die();

		}
	}

	public void Die(){
		Destroy(gameObject);
	}

	public void Attack(GameObject go){
		animator.SetBool("Attack", true);
		StartCoroutine(Attacked());
		attack=true;
		animator.transform.localScale=new Vector3(Mathf.Sign(go.transform.position.x-transform.position.x)* Mathf.Abs(animator.transform.localScale.x),
		                                          animator.transform.localScale.y,animator.transform.localScale.z);

	}

	IEnumerator Attacked(){
		yield return new WaitForEndOfFrame();
		animator.SetBool("Attack", false);
	}
}

