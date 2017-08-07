using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulAbsorb : MonoBehaviour {

	[SerializeField] GameObject player;
	Vector2 player_Position;
	ParticleSystem p_Soul;
	// Use this for initialization
	void Start () 
	{
		if(player == null)
		{
			player = GameObject.Find("Player");
		}
		if(p_Soul == null)
		{
			p_Soul = GetComponent<ParticleSystem>();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		player_Position = new Vector2(player.transform.position.x, player.transform.position.y);
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(player_Position.x, player_Position.y + 0.2f), Mathf.Lerp(0.01f, 1.0f, 0.1f));
	}

	void OnParticleCollision(GameObject obj)
	{
		Destroy(this.gameObject);
	}

	void Vanish()
	{
		
	}
}

