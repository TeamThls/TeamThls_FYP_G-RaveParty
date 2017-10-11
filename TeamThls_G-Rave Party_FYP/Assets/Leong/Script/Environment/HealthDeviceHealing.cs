using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDeviceHealing : MonoBehaviour {

	public GameObject healthDevice;
	ParticleSystem healthDevice_Particles;
	[SerializeField] ParticleSystem healParticles;
	public int availableHealth;
	SpriteRenderer healthDevice_Spr;
	SharedStats allPlayer_SharedStats;
	[SerializeField] Tutorial tutorial_Object;
	// Use this for initialization
	void Start () {
		healthDevice = GameObject.Find("P_HealDevice");
		healthDevice_Particles = healthDevice.transform.GetComponentInChildren<ParticleSystem>();
		availableHealth = 5;
		healthDevice_Spr = healthDevice.GetComponent<SpriteRenderer>();
		allPlayer_SharedStats = GameObject.Find("GameManager").GetComponent<SharedStats>();
		if(tutorial_Object == null)
		{
			tutorial_Object = GameObject.Find("Tutorial").GetComponent<Tutorial>();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(healthDevice_Spr.color == Color.black && availableHealth == 5)
		{
			healthDevice_Spr.color = Color.white;
			healthDevice_Particles.Play();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Player" || col.gameObject.name == "Player2") 
		{
			if(availableHealth == 5)
			{
				if(allPlayer_SharedStats.player_Health < allPlayer_SharedStats.player_MaxHealth)
				{
					tutorial_Object.healthStand_StartCounting = true;
					healthDevice_Spr.color = Color.black;
					allPlayer_SharedStats.player_Health = allPlayer_SharedStats.player_MaxHealth;
					Debug.Log("Heal");
					availableHealth = 0;
					healthDevice_Particles.Stop();
					Instantiate(healParticles, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
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

