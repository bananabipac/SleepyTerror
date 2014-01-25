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

			switch (Type)
			{
				case ObjectType.Enemy :

					MonsterBase mbNew = go.GetComponent<MonsterBase>();
					MonsterBase mb = this.GetComponent<MonsterBase>();

					go.SetActive(true);
					mb.animator = go.GetComponent<Animator>();

					if (mbNew != null)
					{
						mb.patrolBorderLeft = mbNew.patrolBorderLeft;
						mb.patrolBorderRight = mbNew.patrolBorderRight;
					}

					BoxCollider2D bc = this.GetComponent<BoxCollider2D>();
					BoxCollider2D bcNew = this.GetComponent<BoxCollider2D>();
					bc.center = bc.center;
					bc.size = bcNew.size;

					/*Rigidbody2D rb = rigidbody2D;
					Rigidbody2D rbNew = this.GetComponent<Rigidbody2D>();
					rb.mass = rbNew.mass;
					rb.drag = rbNew.drag;
					rb.angularDrag = rbNew.angularDrag;
					rb.angularVelocity = rbNew.angularVelocity;
					rb.gravityScale = rbNew.gravityScale;
					rb.isKinematic = rbNew.isKinematic;
					rb.interpolation = rbNew.interpolation;
					rb.sleepMode = rbNew.sleepMode;
					rb.collisionDetectionMode = rbNew.collisionDetectionMode;*/

					mb.child = go;

					go.SetActive(true);

				break;
				case ObjectType.Player :
					go.SetActive(true);
					this.GetComponent<Player>().animator = go.GetComponent<Animator>();


					Player pNew = go.GetComponent<Player>();
					Player p = this.GetComponent<Player>();

					if (pNew != null)
					{
						p.moveSpeed = pNew.moveSpeed;
						p.jumpSpeed = pNew.jumpSpeed;
						p.fallSpeedMax = pNew.fallSpeedMax;
						p.fallAcceleration = pNew.fallAcceleration;
						p.bumpForce = pNew.bumpForce;
						p.bumpForceWhenHit = pNew.bumpForceWhenHit;
					}

				break;
				case ObjectType.Platform :
					go.GetComponent<SpriteRenderer>().enabled = true;
					//go.GetComponent<BoxCollider2D>().tag = "BackGround";
					go.GetComponent<BoxCollider2D>().enabled = true;
					
				break;
				case ObjectType.Background :
					go.SetActive(true);
				break;
				case ObjectType.MovingPlatform:
					go.SetActive(true);
				Debug.Log(currentWorld);
					if(ListStates.ContainsKey(currentWorld))
					{

						foreach (Transform child in ListStates[currentWorld].transform)
						{

							child.parent = null;					
						}
					}					
					
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
				case ObjectType.Platform:
					go.GetComponent<SpriteRenderer>().enabled = false;
					//go.GetComponent<BoxCollider2D>().SpriteRenderer = "Water";
					go.GetComponent<BoxCollider2D>().enabled = false;
					
				break;
				case ObjectType.Background:
					go.SetActive(false);
				break;
				case ObjectType.MovingPlatform:
					go.SetActive(false);
				break;
			}
		}
	}


	public void ChangeState(WorldType worldType)
	{
		WorldType old = currentWorld;

	
		if (ListStates.ContainsKey(worldType))
		{
			ActivateWorld(worldType);
		}

		DesactivateWorld(old);

		currentWorld = worldType;
	

	}
}
