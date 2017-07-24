﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health = 100.0f;
	public SharedStats sharedstats;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	[SerializeField] ParticleSystem p_BloodOnDeath;
	[SerializeField] ParticleSystem p_DustOnDeath;
	[SerializeField] ParticleSystem p_BurnedOnDeath;
	Rigidbody2D rgBody;
	float death_PauseTimer = 0.0f;
	public enum enemy_DeathState
	{
		Normal, Ice, Fire, Laser
	}
	public enemy_DeathState enemy_CurrentState;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();
		sharedstats = GameObject.Find ("GameManager").GetComponent<SharedStats> ();
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0.0f)
		{
			// WIP, a tiny pause when killed an enemy 
			death_PauseTimer += Time.deltaTime;
			if(death_PauseTimer < 0.017f)
			{
				Time.timeScale = 0.01f;
			}
			else
			{
				Time.timeScale = 1.0f;
				DeathFunction();
				if(transform.parent != null)
				{
					Destroy(transform.parent.gameObject);
				}
				else
				{
					Destroy(this.gameObject);
				}
				sharedstats.player_Gold += 100;
				sharedstats.player_Score += 100;

			}
		}
	}

	void DeathFunction()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Kill);

		var main = p_BloodOnDeath.main;
		if(enemy_CurrentState == enemy_DeathState.Normal)
		{
			main.startColor = Color.yellow;
			Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Ice)
		{
			main.startColor = Color.cyan;
			Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Laser)
		{
			Instantiate(p_DustOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Fire)
		{
			Instantiate(p_BurnedOnDeath, transform.position, Quaternion.identity);
		}

	}

	public void NormalBulletReaction()
	{
		anim.Play("EnemyHitted");
		enemy_CurrentState = enemy_DeathState.Normal;
	}

	public void IceBulletReaction()
	{
		anim.Play("EnemyHittedByIce");
		enemy_CurrentState = enemy_DeathState.Ice;
	}

	public void LaserBulletReaction()
	{
		enemy_CurrentState = enemy_DeathState.Laser;
	}

	public void BurnedReaction()
	{
		anim.Play("EnemyHittedByFire");
		enemy_CurrentState = enemy_DeathState.Fire;
	}
}

