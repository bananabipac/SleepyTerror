using UnityEngine;
using System.Collections;

public class Player : Character {
	public float pv=1;
	public float bumpForceWhenHit=25; 
	// Update is called once per frame
	public void FixedUpdate () {
		Move(Input.GetAxis("Horizontal"));
		Jump(Input.GetButton("Jump"));

		base.FixedUpdate();
	}

	public void TakeDamage(GameObject hitter=null){
		pv--;
		if(pv<=0){
			Application.LoadLevel(Application.loadedLevel);
		}else{
			if(hitter)
				bumpForce=(transform.position-hitter.transform.position).normalized*bumpForceWhenHit;
		}
	}
}
