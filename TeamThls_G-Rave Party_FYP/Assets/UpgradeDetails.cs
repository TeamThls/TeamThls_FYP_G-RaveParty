using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDetails : MonoBehaviour {

	SharedStats shrd;
	GameObject GameManager;

	public int stage;

	public int num;
	public int num2;
	public int num3;

	public bool selected;

	public int upgradeHealth;
	public int upgradeMana;
	public int upgradeManaRegen;

	public Transform magicBook;
	public Transform magicSkill;
	public Transform character;

	public Transform detail01;
	public Transform detail02;
	public Transform detail03;

	public Text message1;
	public Text message2;
	public Text message3;

	public Transform timeRemain;
	public Text timeMessage;

	public bool open;

	float time;

	BulletUpgrades player1_Upgrade, player2_Upgrade;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		shrd = GameManager.GetComponent<SharedStats> ();

		stage = shrd.wave_count;

		magicBook = this.transform.GetChild (1);
		magicSkill = this.transform.GetChild (3);
		character = this.transform.GetChild (2);
		detail01 = this.transform.GetChild (4);
		detail02 = this.transform.GetChild (5);
		detail03 = this.transform.GetChild (6);

		timeRemain = this.transform.GetChild (7);

		player1_Upgrade = GameObject.Find("Player").GetComponent<BulletUpgrades>();
		player2_Upgrade = GameObject.Find("Player2").GetComponent<BulletUpgrades>();
		selected = false;
		open = false;
	}

	// Update is called once per frame
	void Update () {

		if (open == false) {
			stage = shrd.wave_count;
			if (stage == 1) {
				//num = Random.Range (1, 3);
				//num2 = Random.Range (1, 3);
				//num3 = Random.Range (1, 4);
				num = 1;
				num2 = 1;
				num3 = 1;
				open = true;
			}

			if (stage == 2) {
				//num = 1;
				//num2 = 1;
				//num3 = Random.Range (1, 4);
				num = 1;
				num2 = 1;
				num3 = 1;
				open = true;
			}
		}

		if (selected == true) {
			shrd.endDuration += 15.0f;
		}

		time = 15.0f - shrd.endDuration;

		timeMessage.text = "Next Level : " + time.ToString();
	}

	public void upgrade01(){	
		if (selected == false) {
			if (stage == 1) {
				if (num == 1) {
					player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
					player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
					player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
					player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
					player1_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.First;
					player2_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.First;
					selected = true;
					shrd.switchScene = true;
				}
			}
			if (stage == 2) {
				player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
				player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
				player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
				player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
				player1_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.Second;
				player2_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.Second;
				selected = true;
				shrd.switchScene = true;
			}
		}

	}

	public void upgrade02(){
		if (selected == false) {
			if (stage == 1) {
				if (num2 == 1) {
					shrd.player_Health += upgradeHealth;
					shrd.player_MaxHealth += upgradeHealth;
					selected = true;
					shrd.switchScene = true;
				} 
			}
			if (stage == 2) {
				shrd.player_Mana += upgradeMana;
				shrd.player_MaxMana += upgradeMana;
				selected = true;
				shrd.switchScene = true;
			}
		}
	}

	public void upgrade03(){
		if (selected == false) {
			if (stage == 1) {
				if (num3 == 1) {
					shrd.abilityDuration += 15;
					selected = true;
					shrd.switchScene = true;
				} 
			}
			if (stage == 2) {
				if (num3 == 1) {
					// no yet
					selected = true;
					shrd.switchScene = true;
				} 
			}
		}
	}

	public void onClickButton1(){
		if (selected == false) {
			detail01.gameObject.SetActive (true);
			detail02.gameObject.SetActive (false);
			detail03.gameObject.SetActive (false);

			if (stage == 1) {
				// selection upgrade 1
				if (num == 1) {
					message1.text = "All ability mana cost reduce by 30%";
				} 
			}
			if (stage == 2) {
				message1.text = "Ice get 2 sec stun. \nLaser shoot 3 direction. \nFire longer range.";
			}
		}
	}

	public void onClickButton2(){
		if (selected == false) {
			detail01.gameObject.SetActive (false);
			detail02.gameObject.SetActive (true);
			detail03.gameObject.SetActive (false);

			if (stage == 1) {
				// selection upgrade 2
				if (num2 == 1) {
					message2.text = "Player health increase 40";
				} 
			}
			if (stage == 2) {
				message2.text = "Player mana increase 150";
			}
		}
	}

	public void onClickButton3(){
		if (selected == false) {
			detail01.gameObject.SetActive (false);
			detail02.gameObject.SetActive (false);
			detail03.gameObject.SetActive (true);

			if (stage == 1) {
				// selection upgrade 3
				if (num3 == 1) {
					message3.text = "Ability duration increase 15 second";
				}
			}

			if (stage == 2) {
				if (num3 == 1) {
					message3.text = "No yet";
				}
			}
		}
	}
}
