using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEverything : MonoBehaviour {

	public SharedStats shared;
	public GameObject player1;
	public GameObject player2;
	public List<GameObject> EnemyList;

	// Use this for initialization
	void Start () {
		UpdateReferences();
	}
	
	// Update is called once per frame
	void Update () {
		if (shared.levelPassed == true) {
			Debug.Log ("work");
			UpdateReferences ();
			for (int i = 0; i < EnemyList.Count; i++) {
				EnemyList [i].SetActive (false);
			}
			player1.GetComponent<PlayerMovement> ().enabled = false;
			player2.GetComponent<PlayerMovement> ().enabled = false;
			player1.GetComponent<PlayerCombat> ().enabled = false;
			player2.GetComponent<PlayerCombat> ().enabled = false;
		}

		/*if (shared.levelPassed == false) {
			UpdateReferences ();
			for (int i = 0; i < EnemyList.Count; i++) {
				EnemyList [i].SetActive (true);
			}
			player1.GetComponent<PlayerMovement> ().enabled = true;
			player2.GetComponent<PlayerMovement> ().enabled = true;
			player1.GetComponent<PlayerCombat> ().enabled = true;
			player2.GetComponent<PlayerCombat> ().enabled = true;
		}*/
	}

	void UpdateReferences(){
		shared = this.GetComponent<SharedStats> ();
		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");

		if (player2 == null) {
			player2 = player1;
		}

		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
			EnemyList.Add(enemy);
		}
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("ShootEnemy")){
			EnemyList.Add(enemy);
		}
	}
}
