using UnityEngine;
using System.Collections;

public class Player : Character {
	

	// Update is called once per frame
	void Update () {
		Move(Input.GetAxis("Horizontal"));
		Jump(Input.GetButtonDown("Jump"));

		UpdateMove();
	}
}
