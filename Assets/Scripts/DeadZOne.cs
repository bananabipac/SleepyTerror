using UnityEngine;
using System.Collections;

public class DeadZOne : MonoBehaviour {

	public Vector3 SpawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.transform.position = SpawnPoint;
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		//		Gizmos.DrawWireCube(transform.position, new Vector3(width*2, height*2, 0.1f));
		//		Gizmos.DrawSphere(new Vector2(transform.position.x-width,transform.position.y+height ), 0.1f);
		//		Gizmos.DrawSphere(new Vector2(transform.position.x+width,transform.position.y-height ), 0.1f);

		Gizmos.DrawCube(SpawnPoint, new Vector3(1,1,1));


	}
}
