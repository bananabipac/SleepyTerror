using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public string message;
	public GameObject target;

	bool isIn;

	void OnTriggerEnter2D(Collider2D other){
		if(!isIn && other.gameObject.GetComponent<Player>()==true){
			if(target==null)
				target=gameObject;
			target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			Debug.Log("!!!");
			isIn=true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.GetComponent<Player>()==true){
			Debug.Log("!!!?");
			isIn=false;
		}
	}
}
