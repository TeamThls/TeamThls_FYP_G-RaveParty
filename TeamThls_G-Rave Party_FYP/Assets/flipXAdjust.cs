using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipXAdjust : MonoBehaviour {

	public GameObject player;
	public GameObject player1;
	public GameObject player2;
	public SpriteRenderer sprite;

	float a;
	float b;

	// Use this for initialization
	void Start () {
		sprite = this.GetComponent<SpriteRenderer> ();
		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");
		player = player1;
		if (player2 == null) {
			player2 = player;
		}
		targetDetection ();
	}
	
	// Update is called once per frame
	void Update () {
		targetDetection ();
		if (player.transform.position.x > this.transform.position.x) {
			sprite.flipX = false;
		} 
		else {
			sprite.flipX = true;
		}
	}
	void targetDetection(){
		a = Vector3.Distance (this.transform.position, player1.transform.position);
		b = Vector3.Distance (this.transform.position, player2.transform.position);
		if (a < b) {
			player = player1;
		} 
		else {
			player = player2;
		}
	}
}
