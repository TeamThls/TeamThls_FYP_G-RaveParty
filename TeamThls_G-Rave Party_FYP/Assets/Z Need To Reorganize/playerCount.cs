using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCount : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject gameManager;
	SharedStats shrd;

	public int playerNum;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		shrd = gameManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");
		if (player2 == null) {
			player2 = player1;
		}

		if (player2 == player1) {
			shrd.player_Number = 1;
		} 
		else {
			shrd.player_Number = 2;
		}
	}
}
