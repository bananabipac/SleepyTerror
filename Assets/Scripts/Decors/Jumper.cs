using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	public Vector2 bump;
	IEnumerator OnTriggerEnter2D(Collider2D other){
		other.SendMessage("Bump", bump, SendMessageOptions.DontRequireReceiver);

		if (GetComponent<Animator>() != null)
		{
			GetComponent<Animator>().SetBool("jumped", true);
			yield return new WaitForEndOfFrame();
			GetComponent<Animator>().SetBool("jumped", false);
		}
	}
}
