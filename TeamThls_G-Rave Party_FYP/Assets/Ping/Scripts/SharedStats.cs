using System.Collections;
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

	public float enemy_Speed;
	public float str_Speed;
	public float path_Speed;
	public float shoot_Speed;

	public float enemy_Health;
	public float str_Health;
	public float path_Health;
	public float shoot_Health;

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

		OnIce = false;
		OnFire = false;
		OnLaser = false;

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
		//abilityDuration = GlobalControl.Instance.ablty_Duration;

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
		//GlobalControl.Instance.ablty_Duration = abilityDuration;
		GlobalControl.Instance.healRequire = healRequire;

		GlobalControl.Instance.abilityLevel = abilitiesLevel;
		GlobalControl.Instance.extendDuration = abilityExtendedDuration;

		OnIce = false;
		OnFire = false;
		OnLaser = false;
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

		OnIce = false;
		OnFire = false;
		OnLaser = false;

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
