using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

	public GameObject Target;
	public GameObject Player;
	public GameObject Player2;

	public GameObject Path01;
	public GameObject Path02;

	public GameObject Bullet;

	float a;
	float b;

	float q;
	float w;

	public bool touched;
	public int num;
	public GameObject targetMove;
	public GameObject targetMove2;
	float setTime;
	public bool detect;

	public bool checkPos;

	public float targetX;
	public float targetDist;
	public float DistLimit;

	public float maxSpeed;
	public float speed;
	public float step;

	public float FireTime;
	public float FireDuration;

	public bool RunMode;
	public bool fireMode;

	public Vector3 newPos;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		if (Player2 == null) {
			Player2 = Player;
		}
		speed = maxSpeed;
		Path01 = GameObject.Find ("Path01");
		Path02 = GameObject.Find ("Path02");
	}
	// Update is called once per frame
	void Update () {
		step = speed * Time.deltaTime;
		targetDetection ();

		if (RunMode == true) {
			RunFromPlayer ();
		}
		else if (RunMode == false) {
			FindPlayer ();
		}

		if (touched == true) {
			setTime += Time.deltaTime;
			if (setTime >= 3.0f) {
				touched = false;
				setTime = 0.0f;
			}
		}

		if (targetDist < DistLimit) {
			RunMode = true;
			fireMode = false;
		}

		if (fireMode == true) {
			FireTime += Time.deltaTime;
			if (FireTime >= FireDuration) {
				Instantiate (Bullet, this.transform.position, Quaternion.identity);
				FireTime = 0.0f;
			}
		}

		if (num >= 2) {
			RunMode = false;
			detect = false;
			checkPos = false;
			num = 0;
		}
	}

	void RunFromPlayer(){
		if (detect == false) {
			q = Vector3.Distance (this.transform.position, Path01.transform.position);
			w = Vector3.Distance (this.transform.position, Path02.transform.position);
			if (q > w) {
				targetMove = Path02;
				targetMove2 = Path01;
			}
			else if (w > q) {
				targetMove = Path01;
				targetMove2 = Path02;
			}
			detect = true;
		}
		if (num == 0) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, targetMove.transform.position, step);
		}
		else if (num == 1) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, targetMove2.transform.position, step);
		}
	}

	void FindPlayer(){
		if (checkPos == false) {
			if (this.transform.position.x < Target.transform.position.x) {
				newPos = new Vector3 (Target.transform.position.x - targetX, Target.transform.position.y + 1, Target.transform.position.z);
			}
			if (this.transform.position.x > Target.transform.position.x) {
				newPos = new Vector3 (Target.transform.position.x + targetX, Target.transform.position.y + 1, Target.transform.position.z);
			}
			checkPos = true;
		}
		targetDist = Vector3.Distance (newPos, Target.transform.position);
		this.transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
		fireMode = true;
	}

	void targetDetection()
	{
		a = Vector3.Distance (this.transform.position, Player.transform.position);
		b = Vector3.Distance (this.transform.position, Player2.transform.position);

		if (a > b) {
			Target = Player2;
		} 
		else{
			Target = Player;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Path") {
			if (touched == false) {
				num = num + 1;
				touched = true;
			}
		}
	}

}
