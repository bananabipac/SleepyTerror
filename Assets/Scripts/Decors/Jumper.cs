using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	public Vector2 bump;
	void OnTriggerEnter2D(Collider2D other){
		other.SendMessage("Bump", bump, SendMessageOptions.DontRequireReceiver);
	}
}
