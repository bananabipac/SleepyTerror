using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 10;
	//	public float fallSpeedMin=-10;
	public float fallSpeedMax = -10;
	public float fallAcceleration = 2;
	public Vector2 bumpForce;
	public bool isInCollider;
	public GameObject child;
	public float pv = 1;
	public float bumpForceWhenHit = 25; float yVelocity;

}
