using UnityEngine;
using System.Collections;

public class Player : Character {
	public float pv;

	// Update is called once per frame
	void Update () {
		Move(Input.GetAxis("Horizontal"));
		Jump(Input.GetButtonDown("Jump"));

		UpdateMove();
	}
}
