using UnityEngine;
using System.Collections;

public class ColliderSendMessage : MonoBehaviour {

	public string message;


	void OnCollisionEnter2D(Collision2D coll) {
		coll.gameObject.SendMessage(message, gameObject,SendMessageOptions.DontRequireReceiver);
	}
}
