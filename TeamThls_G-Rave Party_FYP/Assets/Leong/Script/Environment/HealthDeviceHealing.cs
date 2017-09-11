using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDeviceHealing : MonoBehaviour {

	public GameObject healthDevice;
	public int availableHealth;
	SpriteRenderer healthDevice_Spr;
	SharedStats allPlayer_SharedStats;
	// Use this for initialization
	void Start () {
		healthDevice = GameObject.Find("P_HealDevice");
		healthDevice_Spr = healthDevice.GetComponent<SpriteRenderer>();
		allPlayer_SharedStats = GameObject.Find("GameManager").GetComponent<SharedStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Player" || col.gameObject.name == "Player2") 
		{
			if(availableHealth == 5)
			{
				if(allPlayer_SharedStats.player_Health < allPlayer_SharedStats.player_MaxHealth)
				{
					healthDevice_Spr.color = Color.black;
					allPlayer_SharedStats.player_Health = allPlayer_SharedStats.player_MaxHealth;
					Debug.Log("Heal");
					availableHealth = 0;
				}
				else
				{
					Debug.Log("Already Max Health");
				}
			}
			else
			{
				Debug.Log(5 - availableHealth + " " + "Left, Kill More Enemies");
			}

		}
	}


}

