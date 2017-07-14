using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public GameObject gameManager;
	public GameObject shopAgent;
	public GameObject Player;
	public GameObject Player2;
	public Text details;
	SharedStats ShareStat;
	PlayerCombat combat;
	PlayerCombat combat2;

	public int payHealth;
	public int Health;

	public int payMana;
	public int Mana;

	public int paySkill;
	public int ManaB;
	public int ManaF;
	public int ManaI;
	public int ManaL;
	public int DamageB;
	public int DamageF;
	public int DamageI;
	public int DamageL;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		shopAgent = GameObject.Find ("ShopAgent");
		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		ShareStat = gameManager.GetComponent<SharedStats>();
		combat = Player.GetComponent<PlayerCombat> ();
		combat2 = Player2.GetComponent<PlayerCombat> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void upHealth(){
		if (ShareStat.player_Gold >= payHealth) {
			ShareStat.player_Gold -= payHealth;
			ShareStat.player_MaxHealth += Health;
			ShareStat.player_Health += Health;
		}
	}

	public void upManapoint(){
		if (ShareStat.player_Gold >= payMana) {
			ShareStat.player_Gold -= payMana;
			ShareStat.player_MaxMana += Mana;
			ShareStat.player_Mana += Mana;
		}
	}

	public void upSkill(){
		if (ShareStat.player_Gold >= paySkill) {
			ShareStat.player_Gold -= paySkill;
			combat.BulletMana += ManaB;
			combat.IceMana += ManaI;
			combat.FireMana += ManaF;
			combat.LaserMana += ManaL;
			ShareStat.Bullet_Damage += DamageB;
			ShareStat.Ice_Damage += DamageI;
			ShareStat.Fire_Damage += DamageF;
			ShareStat.Laser_Damage += DamageL;
		}
	}

	public void ExitButton(){
		shopAgent.GetComponent<ShopAgent> ().setTime = 500;
	}
}
