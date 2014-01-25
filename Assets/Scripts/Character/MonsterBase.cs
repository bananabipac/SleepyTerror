using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MonsterBase : Character {

	Vector3 posStart;
	public Vector3 patrolBorderLeft, patrolBorderRight;

	public bool patrolRight=true;
	public bool patrolLeft=true;
	public System.Action IA;

	public void Start(){
		base.Start();
		posStart=transform.position;
		IA=Patrol;
	}

	public void FixedUpdate () {
		IA();
		base.FixedUpdate();
	}

	public void Patrol(){
		Move(0);
		if(patrolRight){
			Move(1);
			if(transform.position.x>posStart.x+patrolBorderRight.x){
				patrolRight=false;
				patrolLeft=true;
			}
		}
		if(patrolLeft){
			Move(-1);
			if(transform.position.x<posStart.x+patrolBorderLeft.x){
				patrolRight=true;
				patrolLeft=false;
			}
		}
	}

	#if UNITY_EDITOR


	public void OnDrawGizmosSelected  () {
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
