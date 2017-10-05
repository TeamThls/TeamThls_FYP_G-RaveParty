﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public float fire_Damage = 0.1f;
	public enum Fire_SpawnDirection
	{
		Up, Down, Left, Right
	}
	public Fire_SpawnDirection fire_Direction;

	//[SerializeField] MeshRenderer mesh_Ren;
	CameraShake cameraShake;
	ParticleSystem fire_ParticleSystem;
	//Transform player_Pos;

	// Use this for initialization
	void Start () 
	{
		cameraShake = Camera.main.GetComponent<CameraShake>();
		fire_ParticleSystem = GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		FireParticlesDirection();
	}


	void FireParticlesDirection()
	{
		ParticleSystem.VelocityOverLifetimeModule fire_Velocity =  fire_ParticleSystem.velocityOverLifetime;
		//var speed = fire_ParticleSystem.main.startSpeed;

		if(fire_Direction == Fire_SpawnDirection.Right)
		{
			transform.localPosition = new Vector2 (0.9f, 0.6f);
			transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
			//speed = 5.0f;
			//fire_Velocity.y = 0.0f;
		}
		else if(fire_Direction == Fire_SpawnDirection.Left)
		{
			transform.localPosition = new Vector2 (-0.9f, 0.6f);
			transform.rotation = Quaternion.Euler(180.0f, 90.0f, 0.0f);

			//speed = -5.0f;
			//fire_Velocity.y = 0.0f;
		}
		else if(fire_Direction == Fire_SpawnDirection.Up)
		{
			transform.localPosition = new Vector2 (0.0f, 1.0f);
			transform.rotation = Quaternion.Euler(270.0f, 90.0f, 0.0f);

			//fire_Velocity.x = 0.0f;
			//fire_Velocity.y = 5.0f;
		}
		else
		{
			transform.localPosition = new Vector2 (0.0f, -1.0f);
			transform.rotation = Quaternion.Euler(90.0f, 90.0f, 0.0f);

			//fire_Velocity.x = 0.0f;
			//fire_Velocity.y = -5.0f;
		}

	}

	void OnParticleCollision(GameObject obj)
	{
		EnemyCollider enemy_Collider = obj.GetComponent<EnemyCollider>();
		cameraShake.Shake(0.3f, 0.1f);
		enemy_Collider.BurnedReaction();
		enemy_Collider.enemy_Health -= fire_Damage;

	}
}
