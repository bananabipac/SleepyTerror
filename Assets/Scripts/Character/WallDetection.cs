using UnityEngine;
using System.Collections;

public class WallDetection : MonoBehaviour {

//	public float radius=0.2f;
		public float width=0.3f, height=0.1f;
	
	public LayerMask layerMask;
	public bool grounded;
	public bool IsGrouded(){
//		grounded = Physics2D.OverlapCircle(transform.position, radius, layerMask);
		grounded = Physics2D.OverlapArea(new Vector2(transform.position.x-width,transform.position.y+height ),
		                                 new Vector2(transform.position.x+width,transform.position.y-height ), layerMask	);
		return grounded;
	}
	
	public void OnDrawGizmosSelected  () {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, new Vector3(width*2, height*2, 0.1f));
//		Gizmos.DrawSphere(new Vector2(transform.position.x-width,transform.position.y+height ), 0.1f);
//		Gizmos.DrawSphere(new Vector2(transform.position.x+width,transform.position.y-height ), 0.1f);
		
//		Gizmos.DrawSphere(transform.position, radius);
		
		
	}
}
