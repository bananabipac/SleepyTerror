using UnityEngine;
using System.Collections;

public class FouetParticule : MonoBehaviour {
	public Player player;

	Transform target;
	bool play;

	void Update(){
		if(!play)
			return;
		transform.position=(player.transform.position+target.transform.position)/2;
		transform.LookAt(target.transform.position);
//		transform.Rotate(0,0,90);
		transform.localScale=new Vector3 (0.25f,0.25f,Vector3.Distance(player.transform.position,target.transform.position)/2);
	}

	public void StartGrap(Transform newTarget){
		target=newTarget;
		particleSystem.Play();
		play=true;
	}

	public void StopGrab(){
		particleSystem.Stop();
		play=false;
	}
	
}
