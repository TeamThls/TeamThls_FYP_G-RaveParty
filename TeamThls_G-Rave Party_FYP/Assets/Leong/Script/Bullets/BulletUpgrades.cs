using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrades : MonoBehaviour {

	PlayerCombat playerCom;
	public enum IceLevel
	{
		First, Second, Final	
	};
	public enum FireLevel
	{
		First, Second, Final	
	};
	public enum LaserLevel
	{
		First, Second, Final	
	};
	[SerializeField] IceLevel ice_CurrentLevel;

	public ParticleSystem ice_CurrentCastingParticles;
	public GameObject ice_CurrentObj;
	public ParticleSystem fire_CurrentObj;

	[SerializeField] ParticleSystem ice_FirstCastingParticles;
	[SerializeField] ParticleSystem ice_SecondCastingParticles;
	[SerializeField] ParticleSystem ice_FinalCastingParticles;

	public ParticleSystem fire_FirstObj;
	public ParticleSystem fire_SecondObj;
	public ParticleSystem fire_FinalObj;

	[SerializeField] GameObject iceBullet_FirstObj;
	[SerializeField] GameObject iceBullet_SecondObj;
	[SerializeField] GameObject iceBullet_FinalObj;

	Fire fire_Script;

	[SerializeField] FireLevel fire_CurrentLevel;
	[SerializeField] LaserLevel laser_CurrentLevel;



	// Use this for initialization
	void Start () 
	{
		playerCom = this.gameObject.GetComponent<PlayerCombat>();
		ice_CurrentCastingParticles = ice_FirstCastingParticles;
		ice_CurrentObj = iceBullet_FirstObj;
		ice_CurrentLevel = IceLevel.First;
		fire_CurrentLevel = FireLevel.First;
		laser_CurrentLevel = LaserLevel.First;
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
			case IceLevel.First:
				ice_CurrentCastingParticles = ice_FirstCastingParticles;
				ice_CurrentObj = iceBullet_FirstObj;
				playerCom.IceMana = 10;
				break;

			case IceLevel.Second:
				ice_CurrentCastingParticles = ice_SecondCastingParticles;
				ice_CurrentObj = iceBullet_SecondObj;
				playerCom.IceMana = 5;
				break;

			case IceLevel.Final:
				ice_CurrentCastingParticles = ice_FinalCastingParticles;
				ice_CurrentObj = iceBullet_FinalObj;
				break;

		}
		switch(fire_CurrentLevel)
		{
			case FireLevel.First:
				fire_CurrentObj = fire_FirstObj;
				fire_Script = fire_CurrentObj.GetComponent<Fire>();
				fire_Script.fire_Damage = 0.1f;
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
			case LaserLevel.First:
				
				break;
			case LaserLevel.Second:
				
				break;
			case LaserLevel.Final:

				break;
		}
	}
}
