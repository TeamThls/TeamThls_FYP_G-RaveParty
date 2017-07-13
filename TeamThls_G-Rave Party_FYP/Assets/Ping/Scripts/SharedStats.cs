using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedStats : MonoBehaviour {

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

	// Use this for initialization
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
