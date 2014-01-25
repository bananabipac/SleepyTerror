using UnityEngine;
using System.Collections;

public class ColliderSendMessage : MonoBehaviour {

	public string message;


	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log(coll.gameObject);
		coll.gameObject.SendMessage(message, gameObject,SendMessageOptions.DontRequireReceiver);
	}
}
