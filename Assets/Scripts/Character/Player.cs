using UnityEngine;
using System.Collections;

public class Player : Character {

	public WallDetection wallDetectLeft, wallDetectRight;
	public WorldType worldType;

	// Update is called once per frame
	public void Update () {
		Move(Input.GetAxis("Horizontal"));

		if(worldType==WorldManager.Instance.GetCurrentWorld() && (wallDetectLeft.IsGrouded()||wallDetectRight.IsGrouded())){
			MoveOnWall(Input.GetAxis("Vertical"),wallDetectLeft.IsGrouded(), wallDetectRight.IsGrouded());
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
