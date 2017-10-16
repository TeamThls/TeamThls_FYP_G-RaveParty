using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStationTutorial : MonoBehaviour {

	Tutorial tutorial_Script;
	// Use this for initialization
	void Start () 
	{
		if(tutorial_Script == null)
		{
			tutorial_Script = GameObject.Find("Tutorial").GetComponent<Tutorial>();
		}
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.layer == 10 && tutorial_Script.healthStand_StartCounting == false)
		{
			tutorial_Script.healthStand_StartCounting = true;
		}
	}
}
