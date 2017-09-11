using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedStats : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public float player_Health;
	public float player_MaxHealth;

	public float player_Mana;
	public float player_MaxMana;

	public int player_Gold = 0;
	public int player_Score = 0;

	public int Bullet_Damage;
	public int Fire_Damage;
	public int Ice_Damage;
	public int Laser_Damage;

	public float setTime;
	public float maxDuration;
	public int ManaReg;

	public bool OnFire;
	public bool OnIce;
	public bool OnLaser;

	public int BulletMana;
	public int FireMana;
	public int BaseFireMana;
	public int LaserMana;
	public int IceMana;

	public float FireDuration;
	public float LaserDuration;
	public float IceDuration;

	public float abilityDuration;

	public int FireRange;

	public int RandomNum;

	// Use this for initialization
	void Awake() {
		player1 = GameObject.Find ("Player");
		player2 = GameObject.Find ("Player2");

		if (player2 == null) {
			player2 = GameObject.Find ("Player");
		}
	}

	void Start () {
		player_Health = player_MaxHealth;
		player_Mana = player_MaxMana;
	}
	
	// Update is called once per frame
	void Update () {
		setTime += Time.deltaTime;

		if (OnFire == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= FireDuration) {
				Debug.Log ("work");
				OnFire = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
			}
		}

		if (OnIce == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= IceDuration) {
				OnIce = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
			}
		}

		if (OnLaser == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= LaserDuration) {
				OnLaser = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
			}
		}

		if (player_Health > player_MaxHealth) {
			//player_Health = player_MaxHealth;
		}

		if (player_Mana > player_MaxMana) {
			player_Mana = player_MaxMana;
		}

		if (setTime >= maxDuration) {
			player_Mana += ManaReg;
			setTime = maxDuration - 0.5f;
		}
	}
}
