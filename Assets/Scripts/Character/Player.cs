using UnityEngine;
using System.Collections;

public class Player : Character {

	public WallDetection wallDetectLeft, wallDetectRight, wallDetectTop, wallDetectTopL, wallDetectTopR;
	public WorldType worldType;
	public bool isGrapping;

	public GameObject[] toDisableOnDeath;
	// Update is called once per frame
	public void Update () {
		if(pv<=0)
			return;
		Move(Input.GetAxis("Horizontal"));
//		Debug.Log(worldType==WorldManager.Instance.GetCurrentWorld());
		if(worldType==WorldManager.Instance.GetCurrentWorld() && 
		 (wallDetectTop.IsGrouded()|| wallDetectLeft.IsGrouded()
		 ||wallDetectRight.IsGrouded()||wallDetectTopR.IsGrouded()||wallDetectTopL.IsGrouded())){
			MoveOnWall(Input.GetAxis("Vertical"),wallDetectLeft.IsGrouded(), wallDetectRight.IsGrouded(), 
			           wallDetectTop.IsGrouded(), wallDetectTopL.IsGrouded(),wallDetectTopR.IsGrouded());
//			animator.SetBool("OnWall", true);
		}else{
//			animator.SetBool("OnWall", false);
		}

		Jump(Input.GetButtonDown("Jump"));

		//base.FixedUpdate();
	}

	public void FixedUpdate(){
		if(pv<=0){
			rigidbody2D.velocity = Vector2.up * Mathf.Clamp(rigidbody2D.velocity.y-fallAcceleration*Time.deltaTime, fallSpeedMax, jumpSpeed*2);
			return;
		}
		base.FixedUpdate();
	}

	public void Die(){
		animator.SetBool("Die", true);
		collider2D.enabled=false;
		foreach(GameObject go in toDisableOnDeath){
			go.SetActive(false);
		}

		rigidbody2D.velocity=Vector3.up*jumpSpeed*2;
		Destroy(gameObject, 1);

	}

	void OnDestroy(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
