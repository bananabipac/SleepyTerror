using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Transform transformPlayer;
	// Use this for initialization
	void Start () {
		transformPlayer=GameObject.FindObjectOfType<Player>().transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(transformPlayer.position.x, transformPlayer.position.y, transform.position.z);
	}
}
