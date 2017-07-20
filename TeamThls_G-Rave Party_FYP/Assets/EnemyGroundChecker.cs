using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundChecker : MonoBehaviour {

	WaypointPathfinding enemyMove;

	// Use this for initialization
	void Start () 
	{
		enemyMove = GetComponentInParent<WaypointPathfinding>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Ground")
		{
			enemyMove.enemy_groundCheck = true;
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Ground")
		{
			enemyMove.enemy_groundCheck = true;
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Ground")
		{
			enemyMove.enemy_groundCheck = false;
		}
	}
}
