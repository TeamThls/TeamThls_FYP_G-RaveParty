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
		player_Health = GlobalControl.Instance.p_Health ;
		player_MaxHealth = GlobalControl.Instance.p_MaxHealth;

		player_Mana = GlobalControl.Instance.p_Mana;
		player_MaxMana = GlobalControl.Instance.p_MaxMana;
		ManaReg = GlobalControl.Instance.Mana_Reg;

		player_Gold = GlobalControl.Instance.p_Gold;
		player_Score = GlobalControl.Instance.p_Score;

		Bullet_Damage = GlobalControl.Instance.B_Damage;
		Fire_Damage = GlobalControl.Instance.F_Damage;
		Ice_Damage = GlobalControl.Instance.I_Damage;
		Laser_Damage = GlobalControl.Instance.L_Damage;

		BulletMana = GlobalControl.Instance.B_Mana;
		FireMana = GlobalControl.Instance.F_Mana;
		BaseFireMana = GlobalControl.Instance.Base_Mana;
		LaserMana = GlobalControl.Instance.L_Mana;
		IceMana = GlobalControl.Instance.I_Mana;

		FireDuration = GlobalControl.Instance.F_Duration;
		LaserDuration = GlobalControl.Instance.L_Duration;
		IceDuration = GlobalControl.Instance.I_Duration;
		abilityDuration = GlobalControl.Instance.ablty_Duration;
	}
	
	// Update is called once per frame
	void Update () {
		setTime += Time.deltaTime;
		SaveStats ();

		if (OnFire == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= FireDuration) {
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

	public void SaveStats(){
		GlobalControl.Instance.p_Health = player_Health;
		GlobalControl.Instance.p_MaxHealth = player_MaxHealth;

		GlobalControl.Instance.p_Mana = player_Mana;
		GlobalControl.Instance.p_MaxMana = player_MaxMana;
		GlobalControl.Instance.Mana_Reg = ManaReg;

		GlobalControl.Instance.p_Gold = player_Gold;
		GlobalControl.Instance.p_Score = player_Score;

		GlobalControl.Instance.B_Damage = Bullet_Damage;
		GlobalControl.Instance.F_Damage = Fire_Damage;
		GlobalControl.Instance.I_Damage = Ice_Damage;
		GlobalControl.Instance.L_Damage = Laser_Damage;

		GlobalControl.Instance.B_Mana = BulletMana;
		GlobalControl.Instance.F_Mana = FireMana;
		GlobalControl.Instance.Base_Mana = BaseFireMana;
		GlobalControl.Instance.L_Mana = LaserMana;
		GlobalControl.Instance.I_Mana = IceMana;

		GlobalControl.Instance.F_Duration = FireDuration;
		GlobalControl.Instance.L_Duration = LaserDuration;
		GlobalControl.Instance.I_Duration = IceDuration;
		GlobalControl.Instance.ablty_Duration = abilityDuration;
	}
}
