using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrEnemyMovement : MonoBehaviour {

	public float maxDuration;
	public float setTime;
	public bool detection = false;
	public bool inCd = false;
	public GameObject player;
	public GameObject player1;
	public GameObject player2;
	public GameObject GameManager;
	SpriteRenderer sprite;
	SharedStats stts;
	CameraShake cam_Shake;

	public bool multiplayer = true;

	Vector3 newPos = new Vector3();
	Vector3 newPos2 = new Vector3();
	Vector3 newPos3 = new Vector3();

	public bool isAttack = false;

	public bool isDamage = false;

	public int damage;

	public float step;
	public float maxSpeed;
	public float speed;
	public float Booststep;
	public float dist;

	public float totalDist;
	public int counter;
	public int xPos;
	public int yPos;

	public float a;
	public float b;
	public bool canRotate;

	[SerializeField] ParticleSystem playerDamaged_Particles;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		stts = GameManager.GetComponent<SharedStats> ();
		sprite = this.GetComponent<SpriteRenderer> ();
		cam_Shake = Camera.main.GetComponent<CameraShake>();
		speed = maxSpeed;

		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");
		if (player2 == null) {
			player2 = player1;
		}

		targetDetection ();
	}

	// Update is called once per frame
	void Update () {
		damage = stts.enemy_Damage;

		targetDetection ();
		if (player.transform.position.x > this.transform.position.x) {
			sprite.flipX = false;
		} 
		else {
			sprite.flipX = true;
		}

		dist = Vector3.Distance (this.gameObject.transform.position, player.transform.position);
		step = speed * Time.deltaTime;
		Booststep = speed * 2 * Time.deltaTime;

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
			isDamage = true;
			if (this.transform.position == newPos && isDamage == true) {
				counter = 1;
				GameManager.GetComponent<SharedStats> ().player_Health -= damage;

				if(player != null)
				{
					player.transform.GetChild(1).GetComponent<Animator>().Play("PlayerDamaged");
					Instantiate(playerDamaged_Particles, player.transform.position, Quaternion.identity);
					cam_Shake.Shake(0.4f, 0.2f);
				}

				isDamage = false;
			}
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
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, Booststep);
			if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
				this.transform.rotation = Quaternion.Euler (0, 0, 45);
			}
			else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
				this.transform.rotation = Quaternion.Euler (0, 0, 315);
			}
			isDamage = true;
			if (this.transform.position == newPos && isDamage == true) {
				counter = 1;
				GameManager.GetComponent<SharedStats> ().player_Health -= damage;
				if(player != null)
				{
					player.transform.GetChild(1).GetComponent<Animator>().Play("PlayerDamaged");
					Instantiate(playerDamaged_Particles, player.transform.position, Quaternion.identity);
					cam_Shake.Shake(0.4f, 0.2f);
				}
				isDamage = false;
			}
		}
		if (isAttack == true && inCd == false && counter == 1) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos2, Booststep);
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
			if (this.transform.position == newPos2) {
				GetComponentInChildren<SpriteRenderer> ().flipX = true;
				inCd = true;
				counter = 3;
			}
		}
		if (isAttack == true && inCd == false && counter == 3) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos, Booststep);
			if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
				this.transform.rotation = Quaternion.Euler (0, 0, 45);
			}
			else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
				this.transform.rotation = Quaternion.Euler (0, 0, 315);
			}
			isDamage = true;
			if (this.transform.position == newPos && isDamage == true) {
				counter = 4;
				GameManager.GetComponent<SharedStats> ().player_Health -= damage;

				if(player != null)
				{
					player.transform.GetChild(1).GetComponent<Animator>().Play("PlayerDamaged");
					Instantiate(playerDamaged_Particles, player.transform.position, Quaternion.identity);
					cam_Shake.Shake(0.4f, 0.2f);
				}

				isDamage = false;
			}
		}
		if (isAttack == true && inCd == false && counter == 4) {
			transform.position = Vector3.MoveTowards (this.transform.position, newPos3, Booststep);
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
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
