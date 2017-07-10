using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float maxDuration;
	public float setTime;
	public bool detection = false;
	public bool inCd = false;
	public GameObject player;

	Vector3 newPos = new Vector3();
	Vector3 newPos2 = new Vector3();
	Vector3 newPos3 = new Vector3();

	public bool isAttack = false;

	public float step;
	public float speed;
	public float dist;

	public float totalDist;
	public int counter;
	public int xPos;
	public int yPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (this.gameObject.transform.position, player.transform.position);
		step = speed * Time.deltaTime;

		newPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
		newPos2 = new Vector3(player.transform.position.x + xPos, player.transform.position.y + yPos, player.transform.position.z);
		newPos3 = new Vector3(player.transform.position.x - xPos, player.transform.position.y + yPos, player.transform.position.z);


		if (dist > totalDist) {
			isAttack = false;
		} 
		else if (dist < totalDist) {
			isAttack = true;
		}
		
		if(isAttack == false){
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
			/*
			// detect the player position and store it to a temp;
			if(detection == false){
				newPos = player.transform.position;
				detection = true;
			}

			// move enemy to the temp position
			if (detection == true) {
				transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
			}

			if (this.transform.position == player.transform.position) {
				detection = false;
			}
			*/
		}
		if (isAttack == true && inCd == false && counter == 0) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
			if (this.transform.position == newPos) {
				counter = 1;
			}
		}
		if (isAttack == true && inCd == false && counter == 1) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos2, step);
			if (this.transform.position == newPos2) {
				GetComponentInChildren<SpriteRenderer> ().flipX = true;
				inCd = true;
				counter = 3;
			}
		}
		if (isAttack == true && inCd == false && counter == 3) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
			if (this.transform.position == newPos) {
				counter = 4;
			}
		}
		if (isAttack == true && inCd == false && counter == 4) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos3, step);
			if (this.transform.position == newPos3) {
				GetComponentInChildren<SpriteRenderer> ().flipX = false;
				inCd = true;
				counter = 0;
			}
		}

		if (inCd == true) {
			setTime += Time.deltaTime;
			if (setTime >= maxDuration) {
				setTime = 0.0f;
				inCd = false;
			}
		}
	}
}
