using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float range;

	Transform transformPlayer;
	// Use this for initialization
	void Start () {
		transformPlayer=GameObject.FindObjectOfType<Player>().transform;
		Vector3 vec =  transformPlayer.position;
		vec.z = transform.position.z;
		transform.position = vec;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 vec = transformPlayer.position;
		//Debug.Log(transformPlayer.position.y - transform.position.y);
		if (transformPlayer.position.y - transform.position.y > range)
		{
			Debug.Log("move up");
			vec.y = transform.position.y + 5 * Time.deltaTime;
		}
		else if (transformPlayer.position.y - transform.position.y < -1 * range)
		{
			Debug.Log("move down");
			vec.y = transform.position.y - 5 * Time.deltaTime;
		}
		else
		{
			Debug.Log("Don't move");
			vec.y = transform.position.y;
		}
		vec.z = transform.position.z;

		transform.position = vec;
	}
}
