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
		targetDetection ();
		step = speed * Time.deltaTime;
		setTime += Time.deltaTime;
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

	void flyingMode()
	{
		dist = Vector3.Distance (this.transform.position, Target.transform.position);
		if (this.transform.position.x >= Target.transform.position.x) {
			float posX;
			if (this.transform.position.x + targetX >= maxX) {
				posX = maxX;
			} 
			else {
				posX = this.transform.position.x + targetX;
			}
			newPos = new Vector3 (posX, Target.transform.position.y + 2, this.transform.position.z);
		}
		else if (this.transform.position.x < Target.transform.position.x)
		{
			float posX;
			if (Target.transform.position.x - targetX < minX) {
				posX = minX;
			} 
			else {
				posX = Target.transform.position.x - targetX;
			}
			newPos = new Vector3 (posX, Target.transform.position.y + 2, this.transform.position.z);
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
