using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDeviceHealing : MonoBehaviour {

	public GameObject healthDevice;
	SpriteRenderer healthDevice_Spr;
	// Use this for initialization
	void Start () {
		healthDevice = GameObject.Find("P_HealDevice");
		healthDevice_Spr = healthDevice.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Player")
		{
			if(col.gameObject.GetComponent<SharedStats>().player_Health < 100)
			{
				healthDevice_Spr.color = Color.black;
				col.gameObject.GetComponent<SharedStats>().player_Health = 100;
				Debug.Log("Heal");
			}
			else
			{
				Debug.Log("Already Max Health");
			}
		}
	}


}

