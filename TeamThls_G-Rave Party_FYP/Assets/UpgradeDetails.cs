using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDetails : MonoBehaviour {

	public Text playerInfo;
	public Text upgradeInfo01;
	public Text upgradeInfo02;
	public Text upgradeInfo03;

	SharedStats shrd;
	GameObject GameManager;

	public int wordSize;

	public int stageNum;
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

	BulletUpgrades player1_Upgrade, player2_Upgrade;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		shrd = GameManager.GetComponent<SharedStats> ();
		player1_Upgrade = GameObject.Find("Player").GetComponent<BulletUpgrades>();
		player2_Upgrade = GameObject.Find("Player2").GetComponent<BulletUpgrades>();
		selected = false;
		stage = stageNum;
		shrd.wave_count = stage;

		if (stage == 1) {
			num = Random.Range (1, 3);
			num2 = Random.Range (1, 3);
			num3 = Random.Range (1, 4);
		}

	}
	
	// Update is called once per frame
	void Update () {
		playerInfo.fontSize = wordSize;
		playerInfo.text = "Player Info" + 
			"\nPlayer Health : " + shrd.player_Health + "/" + shrd.player_MaxHealth +
			"\nPlayer MP : " + shrd.player_Mana + "/" + shrd.player_MaxMana +
			"\n\nAbility detail" +
			"\nFire Damage : " + shrd.Fire_Damage +
			"\nFire Mana : " + shrd.FireMana +
			"\nIce Damage : " + shrd.Ice_Damage +
			"\nIce Mana : " + shrd.IceMana +
			"\nLaser Damage : " + shrd.Laser_Damage +
			"\nLaser Mana : " + shrd.LaserMana;

		if (selected == true) {
			shrd.endDuration += 15.0f;
		}

		if (stage == 1) {
			// selection upgrade 1
			if (num == 1) {
				upgradeInfo01.text = "Reduce Laser Mana Usage from " + shrd.LaserMana + " to " + laserMana;
				player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
				player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.Second;
			} 
			else if (num == 2) {
				upgradeInfo01.text = "Increase Laser Ability Duration from " + shrd.LaserDuration + " to " + laserDuration;
				player1_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
				player2_Upgrade.laser_CurrentLevel = BulletUpgrades.LaserLevel.First;
			}

			// selection upgrade 2
			if (num2 == 1) {
				upgradeInfo02.text = "Reduce Ice Mana Usage from " + shrd.IceMana + " to " + iceMana;
				player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
				player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.Second;
			} 
			else if (num2 == 2) {
				upgradeInfo02.text = "Increase Ice Ability Duration from " + shrd.IceDuration + " to " + iceDuration;
				player1_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
				player2_Upgrade.ice_CurrentLevel = BulletUpgrades.IceLevel.First;
			}

			// selection upgrade 3
			if (num3 == 1) {
				float temp = shrd.player_MaxHealth + upgradeHealth;
				upgradeInfo03.text = "Increase Health from " + shrd.player_MaxHealth + " to " + temp;
			} 
			else if (num3 == 2) {
				float temp = shrd.player_MaxMana + upgradeMana;
				upgradeInfo03.text = "Increase Manapoint from " + shrd.player_MaxMana + " to " + temp;
			}
			else if (num3 == 3) {
				float temp = shrd.ManaReg + upgradeManaRegen;
				upgradeInfo03.text = "Increase Manapoint Regen Speed from " + shrd.ManaReg + " to " + temp;
			}
		}
	}

	public void upgrade01(){
		if (selected == false) {
			if (stage == 1) {
				if (num == 1) {
					shrd.LaserMana = laserMana;
					selected = true;
				} else if (num == 2) {
					shrd.LaserDuration = laserDuration;
					selected = true;
				}
			}
		}
	}

	public void upgrade02(){
		if (selected == false) {
			if (stage == 1) {
				if (num2 == 1) {
					shrd.IceMana = iceMana;
					selected = true;
				} else if (num2 == 2) {
					shrd.IceDuration = iceDuration;
					selected = true;
				}
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
				} else if (num3 == 2) {
					shrd.player_Mana += upgradeMana;
					shrd.player_MaxMana += upgradeMana;
					selected = true;
				} else if (num3 == 3) {
					shrd.ManaReg = upgradeManaRegen;
					selected = true;
				}
			}
		}
	}
}
