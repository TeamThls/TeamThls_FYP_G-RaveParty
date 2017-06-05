using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	Movement player;
	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<Movement>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player.player_grounded = true;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		player.player_grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.player_grounded = false;
	}
}
