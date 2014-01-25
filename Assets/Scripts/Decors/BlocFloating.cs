using UnityEngine;
using System.Collections;

public class BlocFloating : MonoBehaviour {
	public WorldType worldType;

	public float fallSpeed=-20f, upSpeed=20f;

	
	// Update is called once per frame
	void Update () {
		if(WorldManager.Instance.GetCurrentWorld()==worldType){
			rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, upSpeed);
		}else{
			rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, fallSpeed);
		}
	}
}
