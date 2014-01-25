using UnityEngine;
using System.Collections;

public class TriggerSendMessage : MonoBehaviour {
	LayerMask layermask;
	void OnTriggerEnter2D(Collider2D other){

		Debug.Log(other);
	}
}
