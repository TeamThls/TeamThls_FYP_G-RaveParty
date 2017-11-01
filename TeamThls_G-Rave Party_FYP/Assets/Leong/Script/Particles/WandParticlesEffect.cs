using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandParticlesEffect : MonoBehaviour {

	ParticleSystem wand_Ps;
	SharedStats sharedStats_Script;
	// Use this for initialization
	void Start () 
	{
		wand_Ps = GetComponent<ParticleSystem>();
		sharedStats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeWandColor();
	}

	void ChangeWandColor()
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
	}
}
