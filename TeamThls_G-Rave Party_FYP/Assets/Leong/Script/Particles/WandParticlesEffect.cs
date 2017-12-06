using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandParticlesEffect : MonoBehaviour {

	ParticleSystem normal_Ps, fire_Ps, ice_Ps, laser_Ps;
	[SerializeField] ParticleSystem current_Ps;
	[SerializeField] Light particles_Light;
	SharedStats sharedStats_Script;
	// Use this for initialization
	void Start () 
	{
		normal_Ps = transform.GetChild(0).GetComponent<ParticleSystem>();
		fire_Ps = transform.GetChild(1).GetComponent<ParticleSystem>();
		ice_Ps = transform.GetChild(2).GetComponent<ParticleSystem>();
		laser_Ps = transform.GetChild(3).GetComponent<ParticleSystem>();
		particles_Light = transform.GetChild(4).GetComponent<Light>();

		current_Ps = normal_Ps;
		sharedStats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeWandType();
	}

	void ChangeWandType()
	{
		if(sharedStats_Script.OnFire == true)
		{
			normal_Ps.Stop();
			ice_Ps.Stop();
			laser_Ps.Stop();
			current_Ps = fire_Ps;
			particles_Light.color = Color.yellow;
		}
		else if(sharedStats_Script.OnIce == true)
		{
			normal_Ps.Stop();
			fire_Ps.Stop();
			laser_Ps.Stop();
			current_Ps = ice_Ps;
			particles_Light.color = new Color32(238, 130, 238, 255);
		}
		else if(sharedStats_Script.OnLaser == true)
		{
			normal_Ps.Stop();
			ice_Ps.Stop();
			fire_Ps.Stop();
			current_Ps = laser_Ps;
			particles_Light.color = Color.green;

		}
		else
		{
			fire_Ps.Stop();
			ice_Ps.Stop();
			laser_Ps.Stop();
			current_Ps = normal_Ps;
			particles_Light.color = Color.white;
		}
		if(current_Ps.isPlaying == false)
		{
			current_Ps.Play();
		}
		
	}

	/*void ChangeWandColor()
	{
		var wandPs_Main = wand_Ps.main;
		if(sharedStats_Script.OnFire == true)
		{
			wandPs_Main.startColor = Color.yellow;
		}
		else if(sharedStats_Script.OnIce == true)
		{
			wandPs_Main.startColor = Color.cyan;
		}
		else if(sharedStats_Script.OnLaser == true)
		{
			wandPs_Main.startColor = Color.green;
		}
		else
		{
			wandPs_Main.startColor = Color.white;
		}
	}*/
}
