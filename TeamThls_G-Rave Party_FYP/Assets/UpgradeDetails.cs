using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDetails : MonoBehaviour {

	SharedStats shrd;
	GameObject GameManager;

	public int wordSize;

	public int stage;

	public int num;
	public int num2;
	public int num3;

	public bool selected;

	public int laserMana;
	public int fireMana;
	public int iceMana;

	public int laserDamage;
	public int fireDamage;
	public int iceDamage;

	public int laserDuration;
	public int iceDuration;
	public int fireDuration;

	public int fireRange;

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

	public bool open;

	BulletUpgrades player1_Upgrade, player2_Upgrade;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		shrd = GameManager.GetComponent<SharedStats> ();

		stage = shrd.wave_count;

		magicBook = this.transform.GetChild (1);
		magicSkill = this.transform.GetChild (2);
		character = this.transform.GetChild (3);
		detail01 = this.transform.GetChild (4);
		detail02 = this.transform.GetChild (5);
		detail03 = this.transform.GetChild (6);

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
				num = Random.Range (1, 3);
				num2 = Random.Range (1, 3);
				num3 = Random.Range (1, 4);
				open = true;
			}

			if (stage == 2) {
				num = 1;
				num2 = 1;
				num3 = Random.Range (1, 4);
				open = true;
			}
		}

		if (selected == true) {
			shrd.endDuration += 15.0f;
		}
	}

	public void upgrade01(){
		if (selected == false) {
			if (stage == 1) {
				if (num == 1) {
					player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
					player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
					selected = true;
				} else if (num == 2) {
					player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
					player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
					selected = true;
				}
			}
			if (stage == 2) {
				player1_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.Second;
				player2_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.Second;
				selected = true;
			}
		}
	}

	public void upgrade02(){
		if (selected == false) {
			if (stage == 1) {
				if (num2 == 1) {
					player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
					player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
					selected = true;
				} else if (num2 == 2) {
					player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
					player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
					selected = true;
				}
			}
			if (stage == 2) {
				player1_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.First;
				player2_Upgrade.fire_CurrentLevel = BulletUpgrades.FireLevel.First;
				selected = true;
			}
		}
	}

	public void upgrade03(){
		if (selected == false) {
			if (stage == 1) {
				if (num3 == 1) {
					shrd.player_Health += upgradeHealth;
					shrd.player_MaxHealth += upgradeHealth;
					selected = true;
				} 
				else if (num3 == 2) {
					shrd.player_Mana += upgradeMana;
					shrd.player_MaxMana += upgradeMana;
					selected = true;
				} 
				else if (num3 == 3) {
					shrd.ManaReg = upgradeManaRegen;
					selected = true;
				}
			}
			if (stage == 2) {
				if (num3 == 1) {
					shrd.player_Health += upgradeHealth;
					shrd.player_MaxHealth += upgradeHealth;
					selected = true;
				} 
				else if (num3 == 2) {
					shrd.player_Mana += upgradeMana;
					shrd.player_MaxMana += upgradeMana;
					selected = true;
				} 
				else if (num3 == 3) {
					shrd.ManaReg = upgradeManaRegen;
					selected = true;
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
					message1.text = "Reduce Laser Mana Usage from " + shrd.LaserMana + " to " + laserMana;
				} 
				else if (num == 2) {
					message1.text = "Increase Laser Ability Duration from " + shrd.LaserDuration + " to " + laserDuration;
				}
			}
			if (stage == 2) {
				message1.text = "Increase Fire Ability Damage by 50%";
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
					message2.text = "Reduce Ice Mana Usage from " + shrd.IceMana + " to " + iceMana;
				} 
				else if (num2 == 2) {
					message2.text = "Increase Ice Ability Duration from " + shrd.IceDuration + " to " + iceDuration;
				}
			}
			if (stage == 2) {
				message2.text = "Increase Fire Ability Duration from " + shrd.FireDuration + " to " + 15;
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
					float temp = upgradeHealth + shrd.player_MaxHealth;
					message3.text = "Increase Health from " + shrd.player_MaxHealth + " to " + temp;
				} 
				else if (num3 == 2) {
					float temp = upgradeMana + shrd.player_MaxMana;
					message3.text = "Increase Manapoint from " + shrd.player_MaxMana + " to " + temp;
				}
				else if (num3 == 3) {
					float temp = upgradeManaRegen;
					message3.text = "Increase Manapoint Regen Speed from " + shrd.ManaReg + " to " + temp;
				}
			}

			if (stage == 2) {
				if (num3 == 1) {
					float temp = upgradeHealth + shrd.player_MaxHealth;
					message3.text = "Increase Health from " + shrd.player_MaxHealth + " to " + temp;
				} 
				else if (num3 == 2) {
					float temp = upgradeMana + shrd.player_MaxMana;
					message3.text = "Increase Manapoint from " + shrd.player_MaxMana + " to " + temp;
				}
				else if (num3 == 3) {
					float temp = upgradeManaRegen;
					message3.text = "Increase Manapoint Regen Speed from " + shrd.ManaReg + " to " + temp;
				}
			}
		}
	}
}
