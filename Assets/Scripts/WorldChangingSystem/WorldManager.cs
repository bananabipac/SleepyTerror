using UnityEngine;
using System.Collections;

public enum WorldType { Cute, Time, Terror, Nope };
public enum ObjectType { Player, Enemy, Platform, Background, MovingPlatform, StopingPlatform, BackgroundSound};
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
//		WorldSelected = WorldType.Cute;
		WorldSelected = WorldType.Terror;
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
