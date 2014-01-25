using UnityEngine;
using System.Collections;

public class DecorsComportement : MonoBehaviour {

	public float rotation;
	public Transform[] targetsMoveTo;
	public float timeTarget;
	public iTween.EaseType easeType = iTween.EaseType.linear;

	public bool playTweenAtStart=true;

	bool isPlayingTween;

	// Use this for initialization
	void Start () {
		if(targetsMoveTo.Length>0){
			iTween.MoveTo(gameObject, iTween.Hash("path", targetsMoveTo, "time", timeTarget, 
			                          "looptype", iTween.LoopType.pingPong, "easetype", easeType));
			if(!playTweenAtStart){
				iTween.Pause(gameObject);
				isPlayingTween=true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
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
