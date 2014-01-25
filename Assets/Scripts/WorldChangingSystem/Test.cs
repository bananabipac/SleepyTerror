using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	private bool pressed = false;

	// Use this for initialization
	void Start () {

	
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Fire1") == 0)
		{
			pressed = false;
		}

		if (Input.GetAxis("Fire1") == 1 && !pressed)
		{
			pressed = true;
			if (WorldManager.Instance.GetCurrentWorld() == WorldType.Cute)
			{

				WorldManager.Instance.ChangeWorld(WorldType.Time);
			}
			else if (WorldManager.Instance.GetCurrentWorld() == WorldType.Time)
			{
				WorldManager.Instance.ChangeWorld(WorldType.Terror);
			}
			else if (WorldManager.Instance.GetCurrentWorld() == WorldType.Terror)
			{
				WorldManager.Instance.ChangeWorld(WorldType.Cute);
			}

		}
	
	}
}
