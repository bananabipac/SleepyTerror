using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MonsterBase : Character {

	Vector3 posStart;
	public Vector3 patrolBorderLeft, patrolBorderRight;

	public bool patrolRight=true;

	public System.Action IA;

	public void Start(){
		base.Start();
		posStart=transform.position;
		Debug.Log("!!!!!!!");
		IA=Patrol;
	}

	void Update(){
		IA();
		UpdateMove();
	}

	void Patrol(){
		if(patrolRight){
			Move(1);
			if(transform.position.x>posStart.x+patrolBorderRight.x){
				patrolRight=false;
			}
		}else{
			Move(-1);
			if(transform.position.x<posStart.x+patrolBorderLeft.x){
				patrolRight=true;
			}
		}
	}


	#if UNITY_EDITOR


	 void OnDrawGizmosSelected  () {
		Gizmos.color = Color.green;
		if(EditorApplication.isPlaying){
			Gizmos.DrawWireCube(posStart+patrolBorderLeft, new Vector3(0.05f,100,0));
			Gizmos.DrawWireCube(posStart+patrolBorderRight, new Vector3(0.05f,100,0));
		}else{
			Gizmos.DrawWireCube(transform.position+patrolBorderLeft, new Vector3(0.05f,100,0));
			Gizmos.DrawWireCube(transform.position+patrolBorderRight, new Vector3(0.05f,100,0));
		}

	}
	#endif
}
