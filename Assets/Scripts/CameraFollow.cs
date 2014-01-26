using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float range;
	public float minHeight;
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

		Vector3 vec = this.transform.position;
		if (this.transform.position.y > transformPlayer.position.y - range && this.transform.position.y < transformPlayer.position.y + range)
		{
			if (this.transform.position.y <= minHeight)
			{
				vec.y = minHeight;
			}
			else
			{
				vec.y -= 20 * Time.deltaTime;
			}

		}
		else if(this.transform.position.y < transformPlayer.position.y + range)
		{
			vec.y += 20 * Time.deltaTime;		
		}

		vec.x = transformPlayer.position.x;
		this.transform.position = vec;
	}
}
