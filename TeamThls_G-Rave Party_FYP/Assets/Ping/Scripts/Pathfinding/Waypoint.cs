using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Waypoint : MonoBehaviour {

	public GameObject Player;

	public List<GameObject> NodeList;

	public float totalDist = 0.0f;			// total distance from enemy -> this waypoint -> player
	public float P_Dist = 0.0f;				// distance from this waypoint to player
	public float W_Dist = 0.0f;				// distance from enemy to this waypoint
	//public float f_cost = 0.0f;				// forget
	//public float h_cost = 0.0f;				// forget

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		P_Dist = Vector3.Distance (this.transform.position, Player.transform.position);
		totalDist = W_Dist + P_Dist;
	}
}
