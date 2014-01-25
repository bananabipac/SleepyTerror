using UnityEngine;
using System.Collections;

public class CameraChangeWorld : MonoBehaviour {

	private WorldType currentWorld;
	public Texture Flash;
	bool flash = false;
	bool invert = false;
	float tmp = 5000;

	// Use this for initialization
	void Start () {
		currentWorld = WorldManager.Instance.GetCurrentWorld();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentWorld != WorldManager.Instance.GetCurrentWorld())
		{
			flash = true;
			currentWorld = WorldManager.Instance.GetCurrentWorld();
		}

		

	}

	void OnGUI()
	{
		if (flash)
		{
			if (!invert)
			{
				tmp -= 10000 * Time.deltaTime;
				GUI.DrawTexture(new Rect(Screen.width / 2 - (tmp / 2), Screen.height / 2 - (tmp / 2), tmp, tmp), Flash);

				if (tmp <= 100)
				{
					flash = false;
					tmp = 5000;
				}
			}

		}
		
	}


}
