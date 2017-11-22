using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour {

	PlayerMovement player;
	[SerializeField] ParticleSystem ground_Particles;

	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<PlayerMovement>();
		ground_Particles = transform.parent.GetChild(9).GetComponent<ParticleSystem>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			player.player_grounded = true;
			ground_Particles.Emit(10);
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			player.player_grounded = true;
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			player.player_grounded = false;
		}
	}
}
