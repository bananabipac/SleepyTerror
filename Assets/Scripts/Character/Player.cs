using UnityEngine;
using System.Collections;

public class Player : Character {

	public WallDetection wallDetectLeft, wallDetectRight, wallDetectTop;
	public WorldType worldType;
	public bool isGrapping;
	// Update is called once per frame
	public void Update () {
		Move(Input.GetAxis("Horizontal"));

		if(worldType==WorldManager.Instance.GetCurrentWorld() && 
		  (wallDetectTop.IsGrouded()|| wallDetectLeft.IsGrouded()||wallDetectRight.IsGrouded())){
			MoveOnWall(Input.GetAxis("Vertical"),wallDetectLeft.IsGrouded(), wallDetectRight.IsGrouded(), wallDetectTop.IsGrouded());
			animator.SetBool("OnWall", true);
		}else{
			animator.SetBool("OnWall", false);
		}

		Jump(Input.GetButtonDown("Jump"));

		//base.FixedUpdate();
	}
	void OnDestroy(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
