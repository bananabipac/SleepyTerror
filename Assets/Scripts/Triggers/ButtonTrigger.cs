using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public string message;
	public GameObject target;
	public string soundEnter="triggerEnter";
	public string soundExit="triggerExit";
	bool isIn;

	void OnTriggerEnter2D(Collider2D other){
		if(!isIn && other.gameObject.GetComponent<Player>()==true){
			if(target==null)
				target=gameObject;
//			target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			target.SendMessage(message, other.gameObject, SendMessageOptions.DontRequireReceiver);
			SoundManager.instance.PlaySound(soundEnter);

			isIn=true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.GetComponent<Player>()==true){
			SoundManager.instance.PlaySound(soundExit);

			isIn=false;
		}
	}
}
