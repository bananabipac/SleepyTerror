using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MonsterAggroDistance : MonsterBase {

	Player player;

	public float distanceAggro, distanceLoseAggro;

	public float speedModifIfAggro=1;

	public void Start(){
		base.Start();

		player = GameObject.FindObjectOfType<Player>();
	}

	public void FixedUpdate () {
		if(IA==Patrol)
			Aggro();
		base.FixedUpdate();
	}

	void Aggro(){
		if(Vector3.Distance(player.transform.position, transform.position)<distanceAggro){
			IA=AttackPlayer;
			SoundManager.instance.PlaySound("Aggro");
		}
	}

	void AttackPlayer(){
		if(transform.position.x<player.transform.position.x){
			Move(1*speedModifIfAggro);
		}
		if(transform.position.x>player.transform.position.x){
			Move(-1*speedModifIfAggro);
		}
		if(Vector3.Distance(player.transform.position, transform.position)>distanceLoseAggro){
			IA=Patrol;
		}
	}

	#if UNITY_EDITOR
		
		
	public void OnDrawGizmosSelected  () {
		base.OnDrawGizmosSelected();
		Gizmos.color = new Color(1,0,0,0.25f);

		Gizmos.DrawSphere(transform.position, distanceAggro);

		Gizmos.color = new Color(1,0.5f,0,0.25f);
		Gizmos.DrawSphere(transform.position, distanceLoseAggro);

		
	}
	#endif
}
