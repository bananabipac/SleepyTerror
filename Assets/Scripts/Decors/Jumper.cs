using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	public Vector2 bump;
	public string sound = "MmeChamallow";
	IEnumerator OnTriggerEnter2D(Collider2D other){
		SoundManager.instance.PlaySound(sound);
		other.SendMessage("Bump", bump, SendMessageOptions.DontRequireReceiver);

		if (GetComponent<Animator>() != null)
		{
			GetComponent<Animator>().SetBool("jumped", true);
			yield return new WaitForEndOfFrame();
			GetComponent<Animator>().SetBool("jumped", false);
		}
	}
}
