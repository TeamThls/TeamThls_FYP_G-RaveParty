using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public Text Golden;
	public Text playerHealth;
	public Text playerDamage;
	public Text playerSkill01;
	public Text playerSkill02;
	public Text playerSkill03;
	public Text Details;

	public int gold = 1000;
	public int health = 100;
	public int damage = 5;
	public int ability01 = 10;
	public int ability02 = 15;
	public int ability03 = 25;

	// Use this for initialization
	void Start () {
		Details.color = Color.green;
		Details.text = "Welcome!";
	}
	
	// Update is called once per frame
	void Update () {
		Golden.color = Color.yellow;
		Golden.text = "Gold : " + gold;

		playerHealth.color = Color.white;
		playerHealth.text = "Player Health : " + health;

		playerDamage.color = Color.white;
		playerDamage.text = "Player Damage : " + damage;

		playerSkill01.color = Color.white;
		playerSkill01.text = "Ability one : " + ability01;

		playerSkill02.color = Color.white;
		playerSkill02.text = "Abiltiy two : " + ability02;

		playerSkill03.color = Color.white;
		playerSkill03.text = "Abiltiy three : " + ability03;
	}

	public void UpgradeHealth(){
		if (gold >= 100) {
			gold -= 100;
			health = health + 10;
			Details.text = "Upgraded";
		} 
		else if (gold < 100) {
			Details.text = "You have no enough gold";
		}
	}

	public void UpgradeDamage(){
		if (gold >= 100) {
			gold -= 100;
			damage = damage + 5;
			Details.text = "Upgraded";
		} 
		else if (gold < 100) {
			Details.text = "You have no enough gold";
		}
	}

	public void UpgradeAbility01(){
		if (gold >= 100) {
			gold -= 100;
			ability01 = ability01 + 5;
			Details.text = "Upgraded";
		} 
		else if (gold < 100) {
			Details.text = "You have no enough gold";
		}
	}

	public void UpgradeAbility02(){
		if (gold >= 100) {
			gold -= 100;
			ability02 = ability02 + 5;
			Details.text = "Upgraded";
		} 
		else if (gold < 100) {
			Details.text = "You have no enough gold";
		}
	}

	public void UpgradeAbility03(){
		if (gold >= 100) {
			gold -= 100;
			ability03 = ability03 + 5;
			Details.text = "Upgraded";
		} 
		else if (gold < 100) {
			Details.text = "You have no enough gold";
		}
	}
}
