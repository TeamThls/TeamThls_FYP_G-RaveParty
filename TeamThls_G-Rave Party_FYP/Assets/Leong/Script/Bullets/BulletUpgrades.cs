using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrades : MonoBehaviour {

	PlayerCombat playerCom;
	public enum IceLevel
	{
		Zero, First, Second	
	};
	public enum FireLevel
	{
		Zero, First, Second	
	};
	public enum LaserLevel
	{
		Zero, First, Second
	};
	public IceLevel ice_CurrentLevel;
	public IceBullet iceBullet;

	public ParticleSystem ice_CurrentCastingParticles;
	public GameObject ice_CurrentObj;
	SharedStats stats_Script;

	[SerializeField] ParticleSystem ice_FirstCastingParticles;
	[SerializeField] ParticleSystem ice_SecondCastingParticles;
	[SerializeField] ParticleSystem ice_FinalCastingParticles;

	[SerializeField] GameObject iceBullet_FirstObj;
	[SerializeField] GameObject iceBullet_SecondObj;
	[SerializeField] GameObject iceBullet_FinalObj;

	[SerializeField] float iceDuration_LevelZero, iceDuration_LevelOne, iceDuration_LevelFinal;

	Fire fire_Script;
	public FireLevel fire_CurrentLevel;

	[SerializeField] ParticleSystem fire_FirstObj;
	[SerializeField] ParticleSystem fire_SecondObj;
	[SerializeField] ParticleSystem fire_FinalObj;

	public ParticleSystem fire_CurrentObj;

	[SerializeField] float fireDuration_LevelZero, fireDuration_LevelOne, fireDuration_LevelFinal;

	LaserBeam laser_Script;
	public LaserLevel laser_CurrentLevel;

	[SerializeField] ParticleSystem laser_FirstObj;
	[SerializeField] ParticleSystem laser_SecondObj;
	[SerializeField] ParticleSystem laser_FinalObj;

	[SerializeField] float laserDuration_LevelZero, laserDuration_LevelOne, laserDuration_LevelFinal;

	public ParticleSystem laser_CurrentObj;

	// Use this for initialization
	void Start () 
	{
		playerCom = this.gameObject.GetComponent<PlayerCombat>();
		ice_CurrentCastingParticles = ice_FirstCastingParticles;
		ice_CurrentObj = iceBullet_FirstObj;

		if(iceBullet == null)
		{
			iceBullet = ice_CurrentObj.GetComponent<IceBullet>();
		}
		stats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckUpgrades();
		if (stats_Script.abilitiesLevel == 1) {
			ice_CurrentLevel = IceLevel.Zero;
			fire_CurrentLevel = FireLevel.Zero;
			laser_CurrentLevel = LaserLevel.Zero;
		}
		else if (stats_Script.abilitiesLevel == 2) {
			ice_CurrentLevel = IceLevel.First;
			fire_CurrentLevel = FireLevel.First;
			laser_CurrentLevel = LaserLevel.First;
		}
		else if (stats_Script.abilitiesLevel == 3) {
			ice_CurrentLevel = IceLevel.Second;
			fire_CurrentLevel = FireLevel.Second;
			laser_CurrentLevel = LaserLevel.Second;
		}
	}

	void CheckUpgrades()
	{
		switch(ice_CurrentLevel)
		{	
			case IceLevel.Zero:
				ice_CurrentCastingParticles = ice_FirstCastingParticles;
				ice_CurrentObj = iceBullet_FirstObj;
				iceBullet.currentLevel = 0;
				playerCom.IceMana = 10;

				stats_Script.IceMana = 10;
				stats_Script.IceDuration = iceDuration_LevelZero;
				break;

			case IceLevel.First:
				ice_CurrentCastingParticles = ice_FirstCastingParticles;
				ice_CurrentObj = iceBullet_FirstObj;
				iceBullet.currentLevel = 1;
				playerCom.IceMana = 7;

				stats_Script.IceMana = 7;
				stats_Script.IceDuration = iceDuration_LevelOne;
				break;

			case IceLevel.Second:
				ice_CurrentCastingParticles = ice_SecondCastingParticles;
				ice_CurrentObj = iceBullet_SecondObj;
				playerCom.IceMana = 7;

				stats_Script.IceMana = 7;
				stats_Script.IceDuration = iceDuration_LevelFinal;
				iceBullet.currentLevel = 2;
				break;

		}
		switch(fire_CurrentLevel)
		{
			case FireLevel.Zero:
				fire_CurrentObj = fire_FirstObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				playerCom.FireMana = 5;

				stats_Script.FireMana = 5;
				stats_Script.FireDuration = fireDuration_LevelZero;
				break;
				
			case FireLevel.First:
				fire_CurrentObj = fire_FirstObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				fire_Script.fire_Damage = 0.1f;
				playerCom.FireMana = 3.5f;

				stats_Script.FireMana = 3;
				stats_Script.FireDuration = fireDuration_LevelOne;
				break;

			case FireLevel.Second:
				fire_CurrentObj = fire_SecondObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				playerCom.FireMana = 3.5f;
				fire_Script.fire_Damage = 0.15f;

				stats_Script.FireMana = 3;
				stats_Script.FireDuration = fireDuration_LevelFinal;
				break;

		}
		switch(laser_CurrentLevel)
		{
			case LaserLevel.Zero:
				laser_CurrentObj = laser_FirstObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				laser_Script.laser_Level = 0;
				playerCom.LaserMana = 20;

				stats_Script.LaserMana = 20;
				stats_Script.LaserDuration = laserDuration_LevelZero;
				break;
				
			case LaserLevel.First:
				laser_CurrentObj = laser_FirstObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				laser_Script.laser_Level = 1;
				playerCom.LaserMana = 14;

				stats_Script.LaserMana = 14;
				stats_Script.LaserDuration = laserDuration_LevelOne;
				break;

			case LaserLevel.Second:
				laser_CurrentObj = laser_SecondObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				playerCom.LaserMana = 14;

				stats_Script.LaserMana = 14;
				stats_Script.LaserDuration = laserDuration_LevelFinal;
				laser_Script.laser_Level = 2;
				break;

		}
	}
}
