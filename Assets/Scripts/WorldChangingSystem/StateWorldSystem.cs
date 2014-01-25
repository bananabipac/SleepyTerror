using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateWorldSystem : MonoBehaviour {

	private WorldType currentWorld;
	public WorldType[] States;
	public GameObject[] Objects;
	public ObjectType Type;

	private Dictionary<WorldType, GameObject> ListStates;

	// Use this for initialization
	void Start () {

		ListStates = new Dictionary<WorldType, GameObject>();

		for(int i = 0 ; i<States.Length; i++)
		{
			ListStates.Add(States[i], Objects[i]);
		}

		currentWorld = WorldManager.Instance.GetCurrentWorld();

		if (ListStates.ContainsKey(currentWorld))
		{
			if (Type == ObjectType.Player)
			{			
				this.GetComponent<Character>().animator = ListStates[currentWorld].GetComponent<Animator>();
			}	
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWorld != WorldManager.Instance.GetCurrentWorld())
		{
			ChangeState( WorldManager.Instance.GetCurrentWorld());
		}

	}


	public void ChangeState(WorldType worldType)
	{
		WorldType old = currentWorld;
		Debug.Log(old);
		currentWorld = worldType;
		GameObject objOld = ListStates[old];

		if (ListStates.ContainsKey(worldType))
		{
			GameObject obj = ListStates[worldType];

			obj.SetActive(true);

			switch (Type)
			{
				case ObjectType.Player :
					this.GetComponent<Character>().animator = obj.GetComponent<Animator>();
				break;
			}

			
		
		}
		objOld.SetActive(false);

	}
}
