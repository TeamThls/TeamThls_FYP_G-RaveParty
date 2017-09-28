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

	[SerializeField] ParticleSystem ice_FirstCastingParticles;
	[SerializeField] ParticleSystem ice_SecondCastingParticles;
	[SerializeField] ParticleSystem ice_FinalCastingParticles;

	[SerializeField] FireLevel fire_CurrentLevel;
	[SerializeField] LaserLevel laser_CurrentLevel;



	// Use this for initialization
	void Start () 
	{
		playerCom = this.gameObject.GetComponent<PlayerCombat>();
		ice_CurrentCastingParticles = ice_FirstCastingParticles;
		ice_CurrentLevel = IceLevel.First;
		fire_CurrentLevel = FireLevel.First;
		laser_CurrentLevel = LaserLevel.First;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void CheckUpgrades()
	{
		// Add New Particles in each levels
		if(ice_CurrentLevel == IceLevel.First)
		{
			ice_CurrentCastingParticles = ice_FirstCastingParticles;
		}
		else if(ice_CurrentLevel == IceLevel.Second)
		{
			ice_CurrentCastingParticles = ice_SecondCastingParticles;
		}
		else if(ice_CurrentLevel == IceLevel.Final)
		{
			ice_CurrentCastingParticles = ice_FinalCastingParticles;
		}
	}
}
