using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDeviceHealing : MonoBehaviour {

	public GameObject healthDevice;
	ParticleSystem healthDevice_Particles;
	[SerializeField] ParticleSystem healParticles;
	[SerializeField] ParticleSystem healUIParticles;
	[SerializeField] float health_Requirement;
	public int availableHealth;
	SpriteRenderer healthDevice_Spr;
	SharedStats allPlayer_SharedStats;
	// Use this for initialization
	void Start () 
	{
		healthDevice = GameObject.Find("P_HealDevice");
		healthDevice_Particles = healthDevice.transform.GetComponentInChildren<ParticleSystem>();
		availableHealth = 0;
		healthDevice_Spr = healthDevice.GetComponent<SpriteRenderer>();
		allPlayer_SharedStats = GameObject.Find("GameManager").GetComponent<SharedStats>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(healthDevice_Spr.color == Color.black && availableHealth == 5)
		{
			healthDevice_Spr.color = Color.white;
			healthDevice_Particles.Play();
		}
		else if(availableHealth < health_Requirement)
		{
			healthDevice_Spr.color = Color.black;
			healthDevice_Particles.Stop();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 10) 
		{
			if(availableHealth == health_Requirement)
			{
				if(allPlayer_SharedStats.player_Health < allPlayer_SharedStats.player_MaxHealth)
				{
					healthDevice_Spr.color = Color.black;
					allPlayer_SharedStats.player_Health = allPlayer_SharedStats.player_MaxHealth;
					Debug.Log("Heal");
					availableHealth = 0;
					healthDevice_Particles.Stop();
					Instantiate(healParticles, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
					Instantiate(healUIParticles, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
				}
				else
				{
					Debug.Log("Already Max Health");
				}
			}
			else
			{
				Debug.Log(health_Requirement - availableHealth + " " + "Left, Kill More Enemies");
			}

		}
	}


}

