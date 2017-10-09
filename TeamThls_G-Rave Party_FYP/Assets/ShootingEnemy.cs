using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

	public GameObject Manager;
	public GameObject Player;
	public GameObject Player2;
	public GameObject Target;

	public GameObject bullet;

	SharedStats shrd;

	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	public float dist;
	public float targetDist;
	Vector3 newPos;

	public float targetX;

	public float setTime;
	public float targetTime;
	public bool attackMode;

	public float shootDuration;
	public float maxDuration;

	public float speed;
	public float step;

	private float a;
	private float b;

	public bool changePos;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		shrd = Manager.GetComponent<SharedStats> ();
		Target = Player;
		targetDetection ();
	}
	
	// Update is called once per frame
	void Update () {
		step = speed * Time.deltaTime;

		if (changePos == false) {
			targetDetection ();
			setTime += Time.deltaTime;
			float distance = Vector3.Distance (this.transform.position, Target.transform.position);
			if (setTime >= targetTime) {
				if (attackMode == false) {
					attackMode = true;
					setTime = 0.0f;
				}
				else if (attackMode == true) {
					attackMode = false;
					setTime = 0.0f;
				}
			}
			if (attackMode == false) {
				flyingMode ();
			}
			if (attackMode == true) {
				shootDuration += Time.deltaTime;
				if (shootDuration >= maxDuration) {
					Instantiate (bullet, this.transform.position, Quaternion.identity);
					shootDuration = 0.0f;
				}
			}
		}
		else {
			if (this.transform.position.x >= maxX) {
				Vector3 newPos = new Vector3 (maxX, maxY, 0.0f);
				transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
				if (this.transform.position == newPos) {
					Vector3 newPos2 = new Vector3 (minX, maxY, 0.0f);
					transform.position = Vector3.MoveTowards (this.transform.position, newPos2, step);
					if (this.transform.position.x == minX) {
						changePos = false;
					}
				}
			} 
			else if (this.transform.position.x <= minX) {
				Vector3 newPos = new Vector3 (minX, maxY, 0.0f);
				transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
				if (this.transform.position == newPos) {
					Vector3 newPos2 = new Vector3 (maxX, maxY, 0.0f);
					transform.position = Vector3.MoveTowards (this.transform.position, newPos2, step);
					if (this.transform.position.x == maxX) {
						changePos = false;
					}
				}
			} 
			else {
				changePos = false;
			}
		}
	}

	void flyingMode()
	{
		dist = Vector3.Distance (this.transform.position, Target.transform.position);
		if (this.transform.position.x > Target.transform.position.x) {
			float posX;
			if (Target.transform.position.x + targetX > maxX) {
				posX = maxX;
				changePos = true;
			} 
			else {
				posX = Target.transform.position.x + targetX;
			}
			newPos = new Vector3 (posX, Target.transform.position.y + 1, this.transform.position.z);
		}
		else if (this.transform.position.x < Target.transform.position.x)
		{
			float posX;
			if (Target.transform.position.x - targetX < minX) {
				posX = minX;
				changePos = true;
			} 
			else {
				posX = Target.transform.position.x - targetX;
			}
			newPos = new Vector3 (posX, Target.transform.position.y + 1, this.transform.position.z);
		}
		transform.position = Vector3.MoveTowards (this.transform.position, newPos, step); 
	}

	void targetDetection()
	{
		a = Vector3.Distance (this.transform.position, Player.transform.position);
		b = Vector3.Distance (this.transform.position, Player2.transform.position);

		if (a > b) {
			Target = Player2;
		} 
		else if (a < b) {
			Target = Player;
		}
	}

}
