using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GroundDetection : MonoBehaviour {
	
	public List<Collider> collidedThings=new List<Collider>();
	
//	public bool isGrouded=false;
	public bool IsGrouded(){
		List<Collider> collidersToRemove=new List<Collider>();
		foreach(Collider c in collidedThings){
			if(c==null)
				collidersToRemove.Add (c);
		}
		foreach(Collider c in collidersToRemove){
			collidedThings.Remove(c);
		}
		if(collidedThings.Count>0){
			return true;
		}
		return false;
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag!="Trigger"){
			collidedThings.Add(other);
		}
	}
	

	
	void OnTriggerExit(Collider other){
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
