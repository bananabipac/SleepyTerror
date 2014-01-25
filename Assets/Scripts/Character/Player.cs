using UnityEngine;
using System.Collections;

public class Player : Character {

	 
	// Update is called once per frame
	public void FixedUpdate () {
		Move(Input.GetAxis("Horizontal"));
		Jump(Input.GetButtonDown("Jump"));

		base.FixedUpdate();
	}
	void OnDestroy(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
