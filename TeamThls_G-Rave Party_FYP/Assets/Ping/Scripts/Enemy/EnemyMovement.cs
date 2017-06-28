using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float setTime = 0.0f;
	public float setTime2 = 0.0f;
	public float maxDuration = 1.0f;
	public bool detection = false;
	public GameObject player;
	Vector3 newPos = new Vector3();

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// detect the player position and store it to a temp;
		if(detection == false){
			newPos = player.transform.position;
			detection = true;
		}

		// move enemy to the temp position
		if (detection == true) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, 0.1f);
		}

		// when enemy reach the temp position, use the timer to reset the bool, bool reseted will redetect the player position
		if (this.transform.position == newPos) {
			// set timer to reset the detection on player
			setTime += Time.deltaTime;
			setTime2 += Time.deltaTime;
			int Rand = 0;
			if (setTime2 >= 0.5f && detection == true) {
				Rand = Random.Range (1,4);
			}

			if (Rand == 1) {
				this.transform.Translate (Vector3.left * 3.0f * Time.deltaTime);
				//setTime2 = 0.0f;
			}
			else if (Rand == 2) {
				this.transform.Translate (Vector3.right * 3.0f * Time.deltaTime);
				//setTime2 = 0.0f;
			}
			else if (Rand == 3) {
				this.transform.Translate (Vector3.up * 3.0f * Time.deltaTime);
				//setTime2 = 0.0f;
			}
			else if (Rand == 4) {
				this.transform.Translate (Vector3.down * 3.0f * Time.deltaTime);
				//setTime2 = 0.0f;
			}

			if (setTime >= maxDuration) {
				detection = false;
				setTime = 0.0f;
			}
		}
	}
}
