using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

	public float abilityExtendedDuration;

	public float abilityDuration;

	public int FireRange;

	//reset values
	public float resetplayer_Health;
	public float resetplayer_MaxHealth;

	public float resetplayer_Mana;
	public float resetplayer_MaxMana;

	public int resetplayer_Gold = 0;
	public int resetplayer_Score = 0;

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


	public int RandomNum;

	public bool levelPassed;
	public float endDuration;

	// Use this for initialization
	void Awake() {
		resetplayer_Health = GlobalControl.Instance.p_Health ;
		resetplayer_MaxHealth = GlobalControl.Instance.p_MaxHealth;

		resetplayer_Mana = GlobalControl.Instance.p_Mana;
		resetplayer_MaxMana = GlobalControl.Instance.p_MaxMana;
		resetManaReg = GlobalControl.Instance.Mana_Reg;

		resetplayer_Gold = GlobalControl.Instance.p_Gold;
		resetplayer_Score = GlobalControl.Instance.p_Score;

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

		//Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		setTime += Time.deltaTime;
		SaveStats ();

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

		if (levelPassed == true) {
			endDuration += Time.deltaTime;
			if (endDuration >= 15.0f) {
				SceneManager.LoadScene (7);
				levelPassed = false;
				endDuration = 0.0f;
			}
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

	public void Reset()
	{
		GlobalControl.Instance.p_Health = resetplayer_Health;
		GlobalControl.Instance.p_MaxHealth = resetplayer_MaxHealth;

		GlobalControl.Instance.p_Mana = resetplayer_Mana;
		GlobalControl.Instance.p_MaxMana = resetplayer_MaxMana;
		GlobalControl.Instance.Mana_Reg = resetManaReg;

		GlobalControl.Instance.p_Gold = resetplayer_Gold;
		GlobalControl.Instance.p_Score = resetplayer_Score;

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
	}
}
