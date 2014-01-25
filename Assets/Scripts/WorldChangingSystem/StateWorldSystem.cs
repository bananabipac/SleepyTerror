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

		foreach (KeyValuePair<WorldType, GameObject> value in ListStates)
		{
			if (value.Key == currentWorld)
			{
				ActivateWorld(currentWorld);
			}
			else
			{
				DesactivateWorld(value.Key);
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

	public void ActivateWorld(WorldType world)
	{
		if (ListStates.ContainsKey(world))
		{
			GameObject go = ListStates[world];
			GameObject goOld = ListStates[currentWorld];
			switch (Type)
			{
				case ObjectType.Enemy :

					MonsterBase mbNew = go.GetComponent<MonsterBase>();
					MonsterBase mb = this.GetComponent<MonsterBase>();
					mb.PositionStart = this.transform.position;
					mb.patrolBorderLeft = mbNew.patrolBorderLeft;
					mb.patrolBorderRight = mbNew.patrolBorderRight;
					mb.IA = mbNew.IA;

					BoxCollider2D bc = this.GetComponent<BoxCollider2D>();
					BoxCollider2D bcNew = this.GetComponent<BoxCollider2D>();
					bc.center = bc.center;
					bc.size = bcNew.size;

					Rigidbody2D rb = rigidbody2D;
					Rigidbody2D rbNew = this.GetComponent<Rigidbody2D>();
					rb.mass = rbNew.mass;
					rb.drag = rbNew.drag;
					rb.angularDrag = rbNew.angularDrag;
					rb.angularVelocity = rbNew.angularVelocity;
					rb.gravityScale = rbNew.gravityScale;
					rb.isKinematic = rbNew.isKinematic;
					rb.interpolation = rbNew.interpolation;
					rb.sleepMode = rbNew.sleepMode;
					rb.collisionDetectionMode = rbNew.collisionDetectionMode;

					go.SetActive(true);

				break;
				case ObjectType.Player :
					go.SetActive(true);
					this.GetComponent<Character>().animator = go.GetComponent<Animator>();
				break;
			}
		}
	}

	public void DesactivateWorld(WorldType world)
	{
		if (ListStates.ContainsKey(world))
		{
			GameObject go = ListStates[world];
			switch (Type)
			{
				case ObjectType.Enemy:
					go.SetActive(false);
				break;
				case ObjectType.Player:
				go.SetActive(false);
				break;
			}
		}
	}


	public void ChangeState(WorldType worldType)
	{
		WorldType old = currentWorld;

		
		currentWorld = worldType;

		if (ListStates.ContainsKey(old))
		{
			ActivateWorld(worldType);
		}

		DesactivateWorld(worldType);

		/*if (ListStates.ContainsKey(worldType))
		{
			GameObject obj = ListStates[worldType];

			obj.SetActive(true);

			switch (Type)
			{
				case ObjectType.Player :
					this.GetComponent<Character>().animator = obj.GetComponent<Animator>();
				break;
			}

			
		
		}*/
		

	}
}
