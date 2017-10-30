using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrades : MonoBehaviour {

	PlayerCombat playerCom;
	public enum IceLevel
	{
		Zero, First, Second, Final	
	};
	public enum FireLevel
	{
		Zero, First, Second, Final	
	};
	public enum LaserLevel
	{
		Zero, First, Second, Final	
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

	Fire fire_Script;
	public FireLevel fire_CurrentLevel;

	[SerializeField] ParticleSystem fire_FirstObj;
	[SerializeField] ParticleSystem fire_SecondObj;
	[SerializeField] ParticleSystem fire_FinalObj;

	public ParticleSystem fire_CurrentObj;

	LaserBeam laser_Script;
	public LaserLevel laser_CurrentLevel;

	[SerializeField] ParticleSystem laser_FirstObj;
	[SerializeField] ParticleSystem laser_SecondObj;
	[SerializeField] ParticleSystem laser_FinalObj;

	public ParticleSystem laser_CurrentObj;

	// Use this for initialization
	void Start () 
	{
		playerCom = this.gameObject.GetComponent<PlayerCombat>();
		ice_CurrentCastingParticles = ice_FirstCastingParticles;
		ice_CurrentObj = iceBullet_FirstObj;
		//ice_CurrentLevel = IceLevel.First;
		//fire_CurrentLevel = FireLevel.First;
		//laser_CurrentLevel = LaserLevel.First;
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
	}

	void CheckUpgrades()
	{
		switch(ice_CurrentLevel)
		{	
			case IceLevel.Zero:
				ice_CurrentCastingParticles = ice_FirstCastingParticles;
				ice_CurrentObj = iceBullet_FirstObj;
				iceBullet.currentLevel = 0;
				stats_Script.IceDuration = 10;
				break;

			case IceLevel.First:
				ice_CurrentCastingParticles = ice_FirstCastingParticles;
				ice_CurrentObj = iceBullet_FirstObj;
				iceBullet.currentLevel = 1;
				playerCom.IceMana = 10;
				stats_Script.IceDuration = 15;
				break;

			case IceLevel.Second:
				ice_CurrentCastingParticles = ice_SecondCastingParticles;
				ice_CurrentObj = iceBullet_SecondObj;
				playerCom.IceMana = 5;
				iceBullet.currentLevel = 2;
				break;

			case IceLevel.Final:
				ice_CurrentCastingParticles = ice_FinalCastingParticles;
				ice_CurrentObj = iceBullet_FinalObj;
				iceBullet.currentLevel = 3;
				break;

		}
		switch(fire_CurrentLevel)
		{
			case FireLevel.Zero:
				fire_CurrentObj = fire_FirstObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				stats_Script.FireDuration = 10;
				break;
				
			case FireLevel.First:
				fire_CurrentObj = fire_FirstObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				fire_Script.fire_Damage = 0.1f;
				stats_Script.FireDuration = 15;
				break;

			case FireLevel.Second:
				fire_CurrentObj = fire_SecondObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				fire_Script.fire_Damage = 0.15f;
				break;

			case FireLevel.Final:
				fire_CurrentObj = fire_FinalObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				fire_Script.fire_Damage = 0.15f;
				break;
		}
		switch(laser_CurrentLevel)
		{
			case LaserLevel.Zero:
				laser_CurrentObj = laser_FirstObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				laser_Script.laser_Level = 0;
				stats_Script.LaserDuration = 10;
				break;
				
			case LaserLevel.First:
				laser_CurrentObj = laser_FirstObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				laser_Script.laser_Level = 1;
				stats_Script.LaserDuration = 15;
				break;

			case LaserLevel.Second:
				laser_CurrentObj = laser_SecondObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				playerCom.LaserMana = 10;
				laser_Script.laser_Level = 2;
				break;

			case LaserLevel.Final:
				laser_CurrentObj = laser_FinalObj;
				laser_Script = laser_CurrentObj.GetComponent<LaserBeam>();
				playerCom.LaserMana = 10;
				laser_Script.laser_Level = 3;
				break;
		}
	}
}
