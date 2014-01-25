using UnityEngine;
using System.Collections;

public class DecorsComportement : MonoBehaviour {

	public float rotation;
	public Transform[] targetsMoveTo;
	public float timeTarget;
	public iTween.EaseType easeType = iTween.EaseType.linear;
	public iTween.LoopType loopType = iTween.LoopType.pingPong;
	WorldType currentWorld;
	public WorldType world = WorldType.Time;
	
	public bool playTweenAtStart=true;

	bool isPlayingTween;

	// Use this for initialization
	void Start () {
		currentWorld = WorldManager.Instance.GetCurrentWorld();
		if(targetsMoveTo.Length>0){
			iTween.MoveTo(gameObject, iTween.Hash("path", targetsMoveTo, "time", timeTarget, 
			                                      "looptype",loopType , "easetype", easeType));
			if(!playTweenAtStart || (playTweenAtStart && currentWorld != world)){
				iTween.Pause(gameObject);
				isPlayingTween=true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(currentWorld != WorldManager.Instance.GetCurrentWorld())
		{
			if(WorldManager.Instance.GetCurrentWorld() != world)
			{
				iTween.Pause(gameObject);
				isPlayingTween=true;
			}
			else
			{
				iTween.Resume(gameObject);
				isPlayingTween=false;
			}
			currentWorld = WorldManager.Instance.GetCurrentWorld();
		}
		transform.Rotate(0,0,rotation*Time.deltaTime);

	}

	void PlayPauseTween(){

//		if(targetsMoveTo.Length<=0)
//			return;

		if(isPlayingTween){
			iTween.Resume(gameObject);
		}else{
			iTween.Pause(gameObject);
		}
		isPlayingTween=!isPlayingTween;
	}

}
