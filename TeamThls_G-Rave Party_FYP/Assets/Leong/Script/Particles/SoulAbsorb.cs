using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulAbsorb : MonoBehaviour {

	[SerializeField] GameObject player;
	Vector2 player_Position;
	ParticleSystem p_Soul;
	SharedStats sharedStats;
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
		if(sharedStats == null)
		{
			sharedStats = GameObject.Find("GameManager").GetComponent<SharedStats>();
		}
		ScoreStreakEffect();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		player_Position = new Vector2(player.transform.position.x, player.transform.position.y);
		transform.position = Vector2.MoveTowards(transform.position, new Vector3(player_Position.x, player_Position.y + 0.2f, player_Position.x - 0.1f), Mathf.Lerp(0.01f, 1.0f, 0.1f));

	}

	void OnParticleCollision(GameObject obj)
	{
		p_Soul.Stop();
		StartCoroutine(Vanish(1.0f));
	}

	void ScoreStreakEffect()
	{
		var main = p_Soul.main;

		main.startSize = (0.15f + (sharedStats.ScoreMultiplier * 0.15f));
	}

	IEnumerator Vanish(float duration)
	{
		yield return new WaitForSeconds(duration);
		sharedStats.player_Score += (100 * sharedStats.ScoreMultiplier);
		sharedStats.ScoreMultiplier++;
		Destroy(this.gameObject);
	}
}

