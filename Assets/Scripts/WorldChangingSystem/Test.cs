using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.R))
		{
			if (WorldManager.Instance.GetCurrentWorld() == WorldType.Test1)
			{
				WorldManager.Instance.ChangeWorld(WorldType.Test2);
			}
			else
			{
				WorldManager.Instance.ChangeWorld(WorldType.Test1);
			}

		}
	
	}
}
