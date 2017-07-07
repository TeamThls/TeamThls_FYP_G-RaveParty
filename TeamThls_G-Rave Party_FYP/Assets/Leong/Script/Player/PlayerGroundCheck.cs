using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour {

	PlayerMovement player;

	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<PlayerMovement>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Ground")
		{
			player.player_grounded = true;
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Ground")
		{
			player.player_grounded = true;
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Ground")
		{
			player.player_grounded = false;
		}
	}
}
