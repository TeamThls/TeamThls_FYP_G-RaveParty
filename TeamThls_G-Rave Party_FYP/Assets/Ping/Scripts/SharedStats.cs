﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SharedStats : MonoBehaviour {

	public string player_name;
	public int player_Number;

	public float player_Health;
	public float player_MaxHealth;

	public float player_Mana;
	public float player_MaxMana;

	public int player_Gold = 0;
	public int player_Score = 0;

	public int wave_count;

	public int Bullet_Damage;
	public int Fire_Damage;
	public int Ice_Damage;
	public int Laser_Damage;

	public float setTime;
	public float setTimeScore;
	public float maxScoreTime;
	public float maxDuration;
	public int ManaReg;

	public bool OnFire;
	public bool OnIce;
	public bool OnLaser;

	public int enemy_Damage;
	public int str_Damage;
	public int path_Damage;

	// single
	public int Wave1_EnemyDamage;
	public int Wave2_EnemyDamage;
	public int Wave3_EnemyDamage;

	public int Wave1_StrDamage;
	public int Wave2_StrDamage;
	public int Wave3_StrDamage;

	public int Wave1_PathDamage;
	public int Wave2_PathDamage;
	public int Wave3_PathDamage;

	//multi
	public int mWave1_EnemyDamage;
	public int mWave2_EnemyDamage;
	public int mWave3_EnemyDamage;

	public int mWave1_StrDamage;
	public int mWave2_StrDamage;
	public int mWave3_StrDamage;

	public int mWave1_PathDamage;
	public int mWave2_PathDamage;
	public int mWave3_PathDamage;

	public int enemy_Speed;
	public int str_Speed;
	public int path_Speed;
	public int shoot_Speed;

	//single
	public int Wave1_EnemySpeed;
	public int Wave2_EnemySpeed;
	public int Wave3_EnemySpeed;

	public int Wave1_StrSpeed;
	public int Wave2_StrSpeed;
	public int Wave3_StrSpeed;

	public int Wave1_PathSpeed;
	public int Wave2_PathSpeed;
	public int Wave3_PathSpeed;

	public int Wave1_ShootSpeed;
	public int Wave2_ShootSpeed;
	public int Wave3_ShootSpeed;

	// multi
	public int mWave1_EnemySpeed;
	public int mWave2_EnemySpeed;
	public int mWave3_EnemySpeed;

	public int mWave1_StrSpeed;
	public int mWave2_StrSpeed;
	public int mWave3_StrSpeed;

	public int mWave1_PathSpeed;
	public int mWave2_PathSpeed;
	public int mWave3_PathSpeed;

	public int mWave1_ShootSpeed;
	public int mWave2_ShootSpeed;
	public int mWave3_ShootSpeed;

	public int enemy_Health;
	public int str_Health;
	public int path_Health;
	public int shoot_Health;

	//single
	public int Wave1_EnemyHealth;
	public int Wave2_EnemyHealth;
	public int Wave3_EnemyHealth;

	public int Wave1_StrHealth;
	public int Wave2_StrHealth;
	public int Wave3_StrHealth;

	public int Wave1_PathHealth;
	public int Wave2_PathHealth;
	public int Wave3_PathHealth;

	public int Wave1_ShootHealth;
	public int Wave2_ShootHealth;
	public int Wave3_ShootHealth;

	// multi
	public int mWave1_EnemyHealth;
	public int mWave2_EnemyHealth;
	public int mWave3_EnemyHealth;

	public int mWave1_StrHealth;
	public int mWave2_StrHealth;
	public int mWave3_StrHealth;

	public int mWave1_PathHealth;
	public int mWave2_PathHealth;
	public int mWave3_PathHealth;

	public int mWave1_ShootHealth;
	public int mWave2_ShootHealth;
	public int mWave3_ShootHealth;

	public int BulletMana;
	public int FireMana;
	public int BaseFireMana;
	public int LaserMana;
	public int IceMana;

	public float FireDuration;
	public float LaserDuration;
	public float IceDuration;

	public float abilityExtendedDuration;

	public float abilityDuration;

	public int FireRange;

	public int ScoreMultiplier;

	public int healRequire;

	//reset values
	public int resetPlayer_Num;
	public float resetplayer_Health;
	public float resetplayer_MaxHealth;

	public float resetplayer_Mana;
	public float resetplayer_MaxMana;

	public int resetplayer_Gold = 0;
	public int resetplayer_Score = 0;

	public int reset_Wave_Count = 0;

	public int resetBullet_Damage;
	public int resetFire_Damage;
	public int resetIce_Damage;
	public int resetLaser_Damage;

	public float resetsetTime;
	public float resetmaxDuration;
	public int resetManaReg;

	public bool resetOnFire;
	public bool resetOnIce;
	public bool resetOnLaser;

	public int resetBulletMana;
	public int resetFireMana;
	public int resetBaseFireMana;
	public int resetLaserMana;
	public int resetIceMana;

	public float resetFireDuration;
	public float resetLaserDuration;
	public float resetIceDuration;

	public float resetabilityDuration;

	public int resetFireRange;

	public int resetHealRequire;

	public int RandomNum;

	public bool levelPassed;
	public bool switchScene;
	public float endDuration;

	public int resetScoreMultiplier;

	[SerializeField] BulletUpgrades p1_Upgrade, p2_Upgrade;
	SceneManagement sceneManagement;

	public int abilitiesLevel;
	public int resetAbilitiesLevel;

	public string newpath;
	public float resetExtendDuration;

	// Use this for initialization
	void Awake() {
		sceneManagement = Camera.main.GetComponentInParent<SceneManagement>();
		p1_Upgrade = GameObject.Find("Player").GetComponent<BulletUpgrades>();
		if(sceneManagement.isSinglePlayer != true)
		{
			p2_Upgrade = GameObject.Find("Player2").GetComponent<BulletUpgrades>();
		}
		else
		{
			p2_Upgrade = null;
		}

		resetPlayer_Num = GlobalControl.Instance.player_Num;
		resetplayer_Health = GlobalControl.Instance.p_MaxHealth;
		resetplayer_MaxHealth = GlobalControl.Instance.p_MaxHealth;

		resetplayer_Mana = GlobalControl.Instance.p_Mana;
		resetplayer_MaxMana = GlobalControl.Instance.p_MaxMana;
		resetManaReg = GlobalControl.Instance.Mana_Reg;

		resetplayer_Gold = GlobalControl.Instance.p_Gold;
		resetplayer_Score = GlobalControl.Instance.p_Score;

		reset_Wave_Count = GlobalControl.Instance.wave_count;

		resetBullet_Damage = GlobalControl.Instance.B_Damage;
		resetFire_Damage = GlobalControl.Instance.F_Damage;
		resetIce_Damage = GlobalControl.Instance.I_Damage;
		resetLaser_Damage = GlobalControl.Instance.L_Damage;

		resetBulletMana = GlobalControl.Instance.B_Mana;
		resetFireMana = GlobalControl.Instance.F_Mana;
		resetBaseFireMana = GlobalControl.Instance.Base_Mana;
		resetLaserMana = GlobalControl.Instance.L_Mana;
		resetIceMana = GlobalControl.Instance.I_Mana;

		resetFireDuration = GlobalControl.Instance.F_Duration;
		resetLaserDuration = GlobalControl.Instance.L_Duration;
		resetIceDuration = GlobalControl.Instance.I_Duration;
		resetabilityDuration = GlobalControl.Instance.ablty_Duration;

		resetScoreMultiplier = GlobalControl.Instance.Score_Multiplier;

		resetHealRequire = GlobalControl.Instance.healRequire;

		resetAbilitiesLevel = GlobalControl.Instance.abilityLevel;
		resetExtendDuration = GlobalControl.Instance.extendDuration;
	}

	//void Start () {

	void OnEnable()
	{
			SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnDisable()
	{
			SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene Scene,LoadSceneMode mode)
	{
		player_Number = GlobalControl.Instance.player_Num;
		player_Health = GlobalControl.Instance.p_MaxHealth ;
		player_MaxHealth = GlobalControl.Instance.p_MaxHealth;

		player_Mana = GlobalControl.Instance.p_Mana;
		player_MaxMana = GlobalControl.Instance.p_MaxMana;
		ManaReg = GlobalControl.Instance.Mana_Reg;

		player_Gold = GlobalControl.Instance.p_Gold;
		player_Score = GlobalControl.Instance.p_Score;

		wave_count = GlobalControl.Instance.wave_count;

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

		ScoreMultiplier = GlobalControl.Instance.Score_Multiplier;

		healRequire = GlobalControl.Instance.healRequire;

		abilitiesLevel = GlobalControl.Instance.abilityLevel;
		abilityExtendedDuration = GlobalControl.Instance.extendDuration;
		//Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		setTime += Time.deltaTime;
		setTimeScore += Time.deltaTime;
		SaveStats ();

		// ability duration
		if (OnFire == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= FireDuration + abilityExtendedDuration) {
				OnFire = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
				abilityExtendedDuration = 0.0f;
			}
		}

		if (OnIce == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= IceDuration + abilityExtendedDuration) {
				OnIce = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
				abilityExtendedDuration = 0.0f;
				}
		}

		if (OnLaser == true) {
			abilityDuration += Time.deltaTime;
			if (abilityDuration >= LaserDuration + abilityExtendedDuration) {
				OnLaser = false;
				RandomNum = 0;
				abilityDuration = 0.0f;
				abilityExtendedDuration = 0.0f;
			}
		}

		if (ScoreMultiplier < 1) 
		{
			ScoreMultiplier = 1;
		}

		if (setTimeScore >= maxScoreTime) 
		{
			ScoreMultiplier--;
			setTimeScore = 0;
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

		if (player_Number == 1) {
			if (wave_count == 1) {
				enemy_Damage = Wave1_EnemyDamage;
				str_Damage = Wave1_StrDamage;
				path_Damage = Wave1_PathDamage;

				enemy_Speed = Wave1_EnemySpeed;
				str_Speed = Wave1_StrSpeed;
				path_Speed = Wave1_PathSpeed;
				shoot_Speed = Wave1_ShootSpeed;

				enemy_Health = Wave1_EnemyHealth;
				str_Health = Wave1_StrHealth;
				path_Speed = Wave1_PathHealth;
				shoot_Speed = Wave1_ShootHealth;
			} 
			else if (wave_count == 2) {
				enemy_Damage = Wave2_EnemyDamage;
				str_Damage = Wave2_StrDamage;
				path_Damage = Wave2_PathDamage;

				enemy_Speed = Wave2_EnemySpeed;
				str_Speed = Wave2_StrSpeed;
				path_Speed = Wave2_PathSpeed;
				shoot_Speed = Wave2_ShootSpeed;

				enemy_Health = Wave2_EnemyHealth;
				str_Health = Wave2_StrHealth;
				path_Speed = Wave2_PathHealth;
				shoot_Speed = Wave2_ShootHealth;
			} 
			else if (wave_count == 3) {
				enemy_Damage = Wave3_EnemyDamage;
				str_Damage = Wave3_StrDamage;
				path_Damage = Wave3_PathDamage;

				enemy_Speed = Wave3_EnemySpeed;
				str_Speed = Wave3_StrSpeed;
				path_Speed = Wave3_PathSpeed;
				shoot_Speed = Wave3_ShootSpeed;

				enemy_Health = Wave3_EnemyHealth;
				str_Health = Wave3_StrHealth;
				path_Speed = Wave3_PathHealth;
				shoot_Speed = Wave3_ShootHealth;
			}
		}
		else if (player_Number == 2) {
			if (wave_count == 1) {
				enemy_Damage = mWave1_EnemyDamage;
				str_Damage = mWave1_StrDamage;
				path_Damage = mWave1_PathDamage;

				enemy_Speed = mWave1_EnemySpeed;
				str_Speed = mWave1_StrSpeed;
				path_Speed = mWave1_PathSpeed;
				shoot_Speed = mWave1_ShootSpeed;

				enemy_Health = mWave1_EnemyHealth;
				str_Health = mWave1_StrHealth;
				path_Speed = mWave1_PathHealth;
				shoot_Speed = mWave1_ShootHealth;
			} 
			else if (wave_count == 2) {
				enemy_Damage = mWave2_EnemyDamage;
				str_Damage = mWave2_StrDamage;
				path_Damage = mWave2_PathDamage;

				enemy_Speed = mWave2_EnemySpeed;
				str_Speed = mWave2_StrSpeed;
				path_Speed = mWave2_PathSpeed;
				shoot_Speed = mWave2_ShootSpeed;

				enemy_Health = mWave2_EnemyHealth;
				str_Health = mWave2_StrHealth;
				path_Speed = mWave2_PathHealth;
				shoot_Speed = mWave2_ShootHealth;
			} 
			else if (wave_count == 3) {
				enemy_Damage = mWave3_EnemyDamage;
				str_Damage = mWave3_StrDamage;
				path_Damage = mWave3_PathDamage;

				enemy_Speed = mWave3_EnemySpeed;
				str_Speed = mWave3_StrSpeed;
				path_Speed = mWave3_PathSpeed;
				shoot_Speed = mWave3_ShootSpeed;

				enemy_Health = mWave3_EnemyHealth;
				str_Health = mWave3_StrHealth;
				path_Speed = mWave3_PathHealth;
				shoot_Speed = mWave3_ShootHealth;
			}
		}


		// checking winning or losing and switch scene
		if (levelPassed == true) {
			endDuration += Time.deltaTime;
			if (endDuration >= 15.0f) {
				switchScene = true;
			}
			if (player_Number == 1) {
				if (switchScene == true) {
					if (wave_count == 1) {
						GlobalControl.Instance.wave_count += 1;
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene ("Single-Player Level 2");
					}
					else if (wave_count == 2) {
						GlobalControl.Instance.wave_count += 1;
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene ("Single-Player Level 3");
					}
					else {
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene("Game Over");
					}
				}
			} 
			else if (player_Number == 2) {
				if (switchScene == true) {
					if (wave_count == 1) {
						GlobalControl.Instance.wave_count += 1;
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene ("MultiPlayer Level 2");
					}
					else if (wave_count == 2) {
						GlobalControl.Instance.wave_count += 1;
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene ("MultiPlayer Level 3");
					}
					else {
						levelPassed = false;
						switchScene = false;
						endDuration = 0.0f;
						SceneManager.LoadScene("Game Over");
					}
				}
			}
		}
	}

	public void SaveStats(){
		GlobalControl.Instance.player_Num = player_Number;
		GlobalControl.Instance.p_Health = player_Health;
		GlobalControl.Instance.p_MaxHealth = player_MaxHealth;

		GlobalControl.Instance.p_Mana = player_Mana;
		GlobalControl.Instance.p_MaxMana = player_MaxMana;
		GlobalControl.Instance.Mana_Reg = ManaReg;

		GlobalControl.Instance.p_Gold = player_Gold;
		GlobalControl.Instance.p_Score = player_Score;

		GlobalControl.Instance.wave_count = wave_count;

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
		GlobalControl.Instance.healRequire = healRequire;

		GlobalControl.Instance.abilityLevel = abilitiesLevel;
		GlobalControl.Instance.extendDuration = abilityExtendedDuration;
	}

	public void Reset()
	{
		//Debug.Log ("work");
		GlobalControl.Instance.player_Num = resetPlayer_Num;
		GlobalControl.Instance.p_Health = resetplayer_Health;
		GlobalControl.Instance.p_MaxHealth = resetplayer_MaxHealth;

		GlobalControl.Instance.p_Mana = resetplayer_Mana;
		GlobalControl.Instance.p_MaxMana = resetplayer_MaxMana;
		GlobalControl.Instance.Mana_Reg = resetManaReg;

		GlobalControl.Instance.p_Gold = resetplayer_Gold;
		GlobalControl.Instance.p_Score = resetplayer_Score;

		GlobalControl.Instance.wave_count = reset_Wave_Count;

		GlobalControl.Instance.B_Damage = resetBullet_Damage;
		GlobalControl.Instance.F_Damage = resetFire_Damage;
		GlobalControl.Instance.I_Damage = resetIce_Damage;
		GlobalControl.Instance.L_Damage = resetLaser_Damage;

		GlobalControl.Instance.B_Mana = resetBulletMana;
		GlobalControl.Instance.F_Mana = resetFireMana;
		GlobalControl.Instance.Base_Mana = resetBaseFireMana;
		GlobalControl.Instance.L_Mana = resetLaserMana;
		GlobalControl.Instance.I_Mana = resetIceMana;

		GlobalControl.Instance.F_Duration = resetFireDuration;
		GlobalControl.Instance.L_Duration = resetLaserDuration;
		GlobalControl.Instance.I_Duration = resetIceDuration;
		GlobalControl.Instance.ablty_Duration = resetabilityDuration;

		GlobalControl.Instance.healRequire = resetHealRequire;

		GlobalControl.Instance.abilityLevel = resetAbilitiesLevel;

		GlobalControl.Instance.extendDuration = resetExtendDuration;

		player_Number = GlobalControl.Instance.player_Num;
		player_Health = GlobalControl.Instance.p_MaxHealth ;
		player_MaxHealth = GlobalControl.Instance.p_MaxHealth;

		player_Mana = GlobalControl.Instance.p_Mana;
		player_MaxMana = GlobalControl.Instance.p_MaxMana;
		ManaReg = GlobalControl.Instance.Mana_Reg;

		player_Gold = GlobalControl.Instance.p_Gold;
		player_Score = GlobalControl.Instance.p_Score;

		wave_count = GlobalControl.Instance.wave_count;

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

		ScoreMultiplier = GlobalControl.Instance.Score_Multiplier;

		healRequire = GlobalControl.Instance.healRequire;

		abilitiesLevel = GlobalControl.Instance.abilityLevel;

		abilityExtendedDuration = GlobalControl.Instance.extendDuration;
	}
}
