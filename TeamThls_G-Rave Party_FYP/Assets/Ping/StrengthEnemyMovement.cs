using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthEnemyMovement : MonoBehaviour {

	public GameObject target;
	public GameObject player1;
	public GameObject player2;

	SharedStats shrds;
	GameObject manager;
	SpriteRenderer sprite;
	CameraShake cam_Shake;

	public bool detect;

	public float targetDist;
	float dist;

	public float speed;
	float step;
	public float maxSpeed;
	public float boostspeed;

	Vector3 newPos;
	Vector3 newPos1;
	Vector3 newPos2;

	public int xPos;
	public int yPos;

	public bool attack;
	public int counter;
	public int targetNum;

	float a;
	float b;

	public bool damaging;
	public int damage;

	public float health;
	bool getHealth;

	public float DoubleAttackDist;

	[SerializeField] ParticleSystem playerDamaged_Particles;


	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
		shrds = manager.GetComponent<SharedStats> ();
		cam_Shake = Camera.main.GetComponent<CameraShake>();
		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");
		sprite = this.GetComponent<SpriteRenderer> ();
		if (player2 == null) {
			player2 = player1;
		}
		targetDetection ();
	}
	
	// Update is called once per frame
	void Update () {
		damage = shrds.str_Damage;
		speed = shrds.str_Speed;
		if (getHealth == false) {
			health = shrds.str_Health;
			this.GetComponent<EnemyCollider> ().enemy_Health = health;
			getHealth = true;
		}

		a = Vector3.Distance (this.transform.position, player1.transform.position);
		b = Vector3.Distance (this.transform.position, player2.transform.position);

		step = speed * Time.deltaTime;

		if (damaging == true) {
			shrds.player_Health -= damage;
			//target.transform.GetChild(1).GetComponent<Animator>().Play("PlayerDamaged");
			//Instantiate(playerDamaged_Particles, target.transform.position, Quaternion.identity);
			cam_Shake.Shake(0.4f, 0.2f);
			damaging = false;
		}

		if (target.transform.position.x > this.transform.position.x) {
			sprite.flipX = false;
		} 
		else {
			sprite.flipX = true;
		}

		newPos = new Vector3 (target.transform.position.x + xPos, target.transform.position.y + yPos, target.transform.position.z);
		newPos1 = new Vector3 (target.transform.position.x, target.transform.position.y + 2.0f, target.transform.position.z);
		newPos2 = new Vector3 (target.transform.position.x - xPos, target.transform.position.y + yPos, target.transform.position.z);

		if (detect == false) {
			targetDetection ();
		}

		dist = Vector3.Distance (this.transform.position, target.transform.position);

		if (dist < targetDist) {
			detect = true;
		}
		else {
			detect = false;
		}


		if (attack == false) {
			movement();
			if (this.transform.position == newPos) {
				attack = true;
			}
		}

		if (attack == true && counter == 0) {
			this.transform.position = Vector3.MoveTowards(this.transform.position ,newPos1, step);
			if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
				this.transform.rotation = Quaternion.Euler (0, 0, 45);
			}
			else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
				this.transform.rotation = Quaternion.Euler (0, 0, 315);
			}
			if (targetNum == 1) {
				if (b <= DoubleAttackDist) {
					if (player2.transform.position.y - target.transform.position.y <= 1.5f || player2.transform.position.y - target.transform.position.y >= -1.5f) {
						target = player2;
						if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
							this.transform.rotation = Quaternion.Euler (0, 0, 45);
						}
						else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
							this.transform.rotation = Quaternion.Euler (0, 0, 315);
						}
						if (this.transform.position == newPos1) {
							counter = 1;
						}
					} 
					else {
						counter = 1;
					}
				} 
				else {
					if (this.transform.position == newPos1) {
						counter = 1;
					}
				}
			} 
			else if (targetNum == 2) {
				if (a <= DoubleAttackDist) {
					if (player1.transform.position.y - target.transform.position.y <= 1.5f || player1.transform.position.y - target.transform.position.y >= -1.5f) {
						target = player1;
						if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
							this.transform.rotation = Quaternion.Euler (0, 0, 45);
						}
						else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
							this.transform.rotation = Quaternion.Euler (0, 0, 315);
						}
						if (this.transform.position == newPos1) {
							counter = 1;
						}
					} 
					else {
						counter = 1;
					}
				}
				else {
					if (this.transform.position == newPos1) {
						counter = 1;
					}
				}
			}
		}

		if (attack == true && counter == 1) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, newPos2, step);
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
			if (this.transform.position == newPos2) {
				counter = 2;
				if (target == player1) {
					targetNum = 1;
				}
				if (target == player2) {
					targetNum = 2;
				}
			}
		}

		if (attack == true && counter == 2) {
			this.transform.position = Vector3.MoveTowards(this.transform.position ,newPos1, step);
			if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
				this.transform.rotation = Quaternion.Euler (0, 0, 45);
			}
			else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
				this.transform.rotation = Quaternion.Euler (0, 0, 315);
			}
			if (targetNum == 1) {
				if (b <= DoubleAttackDist) {
					if (player2.transform.position.y - target.transform.position.y <= 1.5f || player2.transform.position.y - target.transform.position.y >= -1.5f) {
						target = player2;
						if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
							this.transform.rotation = Quaternion.Euler (0, 0, 45);
						}
						else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
							this.transform.rotation = Quaternion.Euler (0, 0, 315);
						}
						if (this.transform.position == newPos1) {
							counter = 4;
						}
					} 
					else {
						counter = 4;
					}
				} 
				else {
					if (this.transform.position == newPos1) {
						counter = 4;
					}
				}
			} 
			else if (targetNum == 2) {
				if (a <= DoubleAttackDist) {
					if (player1.transform.position.y - target.transform.position.y <= 1.5f || player1.transform.position.y - target.transform.position.y >= -1.5f) {
						target = player1;
						if (GetComponentInChildren<SpriteRenderer> ().flipX == true) {
							this.transform.rotation = Quaternion.Euler (0, 0, 45);
						}
						else if (GetComponentInChildren<SpriteRenderer> ().flipX == false) {
							this.transform.rotation = Quaternion.Euler (0, 0, 315);
						}
						if (this.transform.position == newPos1) {
							counter = 4;
						}
					} 
					else {
						counter = 4;
					}
				}
				else {
					if (this.transform.position == newPos1) {
						counter = 4;
					}
				}
			}
		}

		if (attack == true && counter == 4) {
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
			if (target == player1) {
				targetNum = 1;
			}
			if (target == player2) {
				targetNum = 2;
			}
			movement ();

			if (this.transform.position == newPos) {
				counter = 0;
			}
		}

	}

	void movement(){
		transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
	}

	void targetDetection(){
		if (a < b) {
			target = player1;
			targetNum = 1;
		}
		else {
			target = player2;
			targetNum = 2;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			damaging = true;
			other.GetComponent<Animator>().Play("PlayerDamaged");
			Instantiate(playerDamaged_Particles, other.transform.position, Quaternion.identity);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			damaging = false;
		}
	}
}
