﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedStats : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public int player_Health;
	public int player_MaxHealth;

	public int player_Mana;
	public int player_MaxMana;

	public int player_Gold = 0;
	public int player_Score = 0;

	public int Bullet_Damage;
	public int Fire_Damage;
	public int Ice_Damage;
	public int Laser_Damage;

	public float setTime;
	public float maxDuration;
	public int ManaReg;

	public bool OnFire = false;
	public bool OnIce = false;
	public bool OnLaser = false;

	public int BulletMana;
	public int FireMana;
	public int BaseFireMana;
	public int LaserMana;
	public int IceMana;

	public float FireDuration;
	public float LaserDuration;
	public float IceDuration;

	public int FireRange;

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
