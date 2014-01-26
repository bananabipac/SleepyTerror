using UnityEngine;
using System.Collections;

public class Grap : MonoBehaviour {

	bool canGrap, grapping;
	Player player;

	public float camSizeModif=2;
	SpringJoint2D joint;
	void Start(){
		joint=GetComponent<SpringJoint2D>();
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.GetComponent<Player>()){
			player=other.GetComponent<Player>();
			canGrap=true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.GetComponent<Player>()){
			canGrap=false;
		}
	}

	void Update(){
		if(!grapping){
			if(canGrap && !player.isGrapping &&  Input.GetButtonDown("Fire2")){
				grapping=true;
				player.enabled=false;
				player.rigidbody2D.gravityScale=10;
				joint.connectedBody = player.rigidbody2D;
//				Destroy(GetComponent<CircleCollider2D>());
				player.isGrapping=true;
				Camera cam=player.GetComponentInChildren<Camera>();
				cam.transform.parent=transform;
				cam.transform.position=new Vector3(transform.position.x,transform.position.y,cam.transform.position.z);
				cam.orthographicSize=cam.orthographicSize*camSizeModif;
				player.GetComponentInChildren<FouetParticule>().StartGrap(transform);
			}
		}else{
			Debug.DrawLine(player.transform.position, transform.position);
//			Debug.Log(player.rigidbody2D.velocity);
			if(Input.GetButtonDown("Jump"))
				Drop();

		}
	}

	void Desactivation(){

		Debug.Log("!!");
		Drop();
		grapping=false;
	}
	 
	void Drop(){
		Debug.Log("drop");
		if(grapping){
			canGrap=false;
			//				grapping=false;
			player.rigidbody2D.gravityScale=0;
			joint.connectedBody = null;
			
			player.isGrapping=false;
			player.bumpForce=Vector2.zero;
			player.Bump(player.rigidbody2D.velocity.normalized*player.jumpSpeed*10);
			player.enabled=true;
			Camera cam=GetComponentInChildren<Camera>();
			cam.transform.parent=player.transform;
			cam.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,cam.transform.position.z);
			cam.orthographicSize=cam.orthographicSize/camSizeModif;
			//				Destroy(gameObject);
			StartCoroutine(ResetGrapping());
			player.GetComponentInChildren<FouetParticule>().StopGrab();
		}
	}

	IEnumerator ResetGrapping(){
		yield return new WaitForSeconds(0.5f);
		grapping=false;
	}
}
