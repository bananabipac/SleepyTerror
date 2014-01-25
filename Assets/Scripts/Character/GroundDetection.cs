using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GroundDetection : MonoBehaviour {
	
	public List<Collider2D> collidedThings=new List<Collider2D>();
	
//	public bool isGrouded=false;
	public bool IsGrouded(){
		List<Collider2D> collidersToRemove=new List<Collider2D>();
		foreach(Collider2D c in collidedThings){
			if(c==null || !c.gameObject.activeSelf)
				collidersToRemove.Add (c);
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
			collidedThings.Add(other);
		}
	}
	

	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag!="Trigger"){
			collidedThings.Remove(other);			
		}
	}
	
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
