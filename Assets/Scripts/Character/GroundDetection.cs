using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GroundDetection : MonoBehaviour {

		public float radius=0.2f;
//	public float width=0.3f, height=0.1f;

	public LayerMask layerMask, layerMaskNope;
	public bool grounded, nope;

	public bool IsGrouded(){
		transform.parent.parent=null;
		grounded = Physics2D.OverlapCircle(transform.position, radius, layerMask);
//		grounded = Physics2D.OverlapArea(new Vector2(transform.position.x-width,transform.position.y+height ),
//		                                 new Vector2(transform.position.x+width,transform.position.y-height ), layerMask	);
		return grounded;
	}

	public bool IsNope(){
		transform.parent.parent=null;
		nope = Physics2D.OverlapCircle(transform.position, radius, layerMaskNope);
		//		grounded = Physics2D.OverlapArea(new Vector2(transform.position.x-width,transform.position.y+height ),
		//		                                 new Vector2(transform.position.x+width,transform.position.y-height ), layerMask	);
		return nope;
	}

	public void OnDrawGizmosSelected  () {
		Gizmos.color = Color.green;
//		Gizmos.DrawWireCube(transform.position, new Vector3(width*2, height*2, 0.1f));
//		Gizmos.DrawSphere(new Vector2(transform.position.x-width,transform.position.y+height ), 0.1f);
//		Gizmos.DrawSphere(new Vector2(transform.position.x+width,transform.position.y-height ), 0.1f);

		Gizmos.DrawSphere(transform.position, radius);


	}

	void OnTriggerEnter2D(Collider2D other){
//		FixCrade(other.GetComponent<MovingDecor>());
		MovingDecor movingDecor=other.GetComponent<MovingDecor>();
		if(movingDecor)
			transform.parent.parent=other.transform;
	}
//	void OnTriggerStay2D(Collider2D other){
//		FixCrade(other.GetComponent<MovingDecor>());
//	}
	void OnTriggerExit2D(Collider2D other){
//		FixCrade(other.GetComponent<MovingDecor>());
		MovingDecor movingDecor=other.GetComponent<MovingDecor>();
		if(movingDecor)
			transform.parent.parent=null;
	}
//
//	void FixCrade(MovingDecor movingDecor){
//		if(movingDecor){
////			transform.parent.Translate(movingDecor.delta);
//			transform.parent.Translate(movingDecor.transform.position-movingDecor.lastPosition);
//		}
//	}


	/*

	public List<Collider2D> collidedThings=new List<Collider2D>();
	
//	public bool isGrouded=false;
	public bool IsGrouded(){
		List<Collider2D> collidersToRemove=new List<Collider2D>();
		foreach(Collider2D c in collidedThings){
			if(c==null || !c.gameObject.activeSelf)
				collidersToRemove.Add(c);
				
		}
		foreach(Collider2D c in collidersToRemove){
			collidedThings.Remove(c);
		}
		if(collidedThings.Count>0){
			return true;
		}
		return false;
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log("!!!");
		if(other.tag!="Trigger"){
			if(!collidedThings.Contains(other)){
				collidedThings.Add(other);
				Debug.Log("OnTriggerEnter2D "+other.gameObject.name+" "+Time.time);
			}
		}
	}
	

	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag!="Trigger"){
			Debug.Log("OnTriggerExit2D "+other.gameObject.name+" "+Time.time);
			while(collidedThings.Remove(other));			
		}
	}
	*/
//	public int nbColision=0;
//	
//	public bool IsGrouded(){
//		if(nbColision>0)
//			return true;
//		return false;
//	}
//	void OnTriggerEnter(Collider other){
//		if(!other.isTrigger){
//			
//			nbColision++;
//			Debug.Log("enter "+other.name+" "+nbColision);
//		}
//	}
//	
//	void OnTriggerExit(Collider other){
//		if(!other.isTrigger){
//			nbColision--;
//			Debug.Log("exit "+other.name+" "+nbColision);
//		}
//	}
}
