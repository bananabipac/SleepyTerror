using UnityEngine;
using System.Collections;

public class TriggerSendMessage : MonoBehaviour {

	public string message;

	void OnTriggerEnter2D(Collider2D other){
		other.SendMessage(message, gameObject, SendMessageOptions.DontRequireReceiver);
	}
}
