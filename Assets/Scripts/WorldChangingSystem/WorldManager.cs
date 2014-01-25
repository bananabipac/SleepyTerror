using UnityEngine;
using System.Collections;

public enum WorldType { Test1, Test2, Test3 };
public enum ObjectType { Player, Enemy};

public class WorldManager : MonoBehaviour {

	private WorldType WorldSelected;
	public static WorldManager Instance { get; private set; }


	void Awake()
	{
		// Save a reference to the AudioHandler component as our singleton instance
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		WorldSelected = WorldType.Test1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ChangeWorld(WorldType world)
	{
		WorldSelected = world;
	}

	public WorldType GetCurrentWorld()
	{
		return WorldSelected;
	}
}
