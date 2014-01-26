using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public string levelToLoad;
	void Plop(){
//		LoadTheFuckinScene();
		Debug.Log(levelToLoad);
	}
	public void LoadTheFuckinScene(){
		Debug.Log(levelToLoad);
//		Debug.Log(Application.loadedLevelName);
		Application.LoadLevel(levelToLoad);
	}
}
