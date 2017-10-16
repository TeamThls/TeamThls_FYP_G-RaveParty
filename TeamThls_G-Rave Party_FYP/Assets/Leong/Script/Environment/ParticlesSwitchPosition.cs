using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSwitchPosition : MonoBehaviour {

	SpriteRenderer player_Spr;
	// Use this for initialization
	void Start () {
		player_Spr = transform.parent.GetChild (1).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player_Spr.flipX == true)
		{
			transform.localPosition = new Vector2(-0.5f, transform.localPosition.y);
		}
		else
		{
			transform.localPosition = new Vector2(0.5f, transform.localPosition.y);
		}
	}
}
