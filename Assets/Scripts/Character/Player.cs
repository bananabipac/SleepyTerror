using UnityEngine;
using System.Collections;

public class Player : Character {
	public float pv;
	public float bumpForceWhenHit=25; 
	// Update is called once per frame
	public void Update () {
		Move(Input.GetAxis("Horizontal"));
		Jump(Input.GetButtonDown("Jump"));

		base.Update();
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
