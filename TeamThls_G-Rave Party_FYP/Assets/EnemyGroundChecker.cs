using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundChecker : MonoBehaviour {

	public pathfinding enemyMove;

	// Use this for initialization
	void Start () 
	{
		enemyMove = GetComponentInParent<pathfinding>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			enemyMove.enemy_groundCheck = true;
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			enemyMove.enemy_groundCheck = true;
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Ground"))
		{
			enemyMove.enemy_groundCheck = false;
		}
	}
}
