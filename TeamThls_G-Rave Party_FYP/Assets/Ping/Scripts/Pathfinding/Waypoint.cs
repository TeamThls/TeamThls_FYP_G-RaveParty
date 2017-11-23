using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Waypoint : MonoBehaviour {

	public GameObject Player;
	public GameObject Player2;

	public List<GameObject> NodeList;
	public GameObject target;
	public float totalDist = 0.0f;			// total distance from enemy -> this waypoint -> player
	public float P_Dist = 0.0f;				// distance from this waypoint to player
	public float P2_Dist;
	public float W_Dist = 0.0f;				// distance from enemy to this waypoint
	public float S_Dist = 0.0f;				// distance from the Spawner
	public float temp = 0.0f;
	public float multi = 1.0f;
	public float tempDist_1;
	public float tempDist_2;
	public float tempDist_3;
	//public float f_cost = 0.0f;				// forget
	//public float h_cost = 0.0f;				// forget

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		Player2 = GameObject.Find ("Player2");
		if (Player2 == null) {
			Player2 = Player;
		}
	}
	
	// Update is called once per frame
	void Update () {
		target = Player;
		if (P_Dist < P2_Dist) {
			target = Player;
			totalDist = W_Dist + P_Dist;
		}
		else{
			target = Player2;
			totalDist = W_Dist + P2_Dist;
		}
		P_Dist = (Vector3.Distance (this.transform.position, Player.transform.position));
		P2_Dist = (Vector3.Distance (this.transform.position, Player2.transform.position));

		//P_Dist = ((Vector3.Distance (this.transform.position, Player.transform.position)) + temp) /  multi;
		//P2_Dist = ((Vector3.Distance (this.transform.position, Player2.transform.position)) + temp) / multi;

		/*(if ((target.transform.position.y - this.transform.position.y >= 5) || (target.transform.position.y - this.transform.position.y <= -5)) {
			temp = tempDist_1;
		}

		if(target.transform.position.y - this.transform.position.y <= 1.0f){
			multi = 2.0f;
		}
		else{
			multi = 1.0f;
		}*/
	}
}
