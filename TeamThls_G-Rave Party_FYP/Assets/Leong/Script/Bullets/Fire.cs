using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public float fire_Damage = 0.2f;
	//public GameObject player;
	public Movement movementScript;
	public Transform gun;
	public enum Fire_SpawnDirection
	{
		Up, Down, Left, Right
	}
	public Fire_SpawnDirection fire_Direction;

	//[SerializeField] MeshRenderer mesh_Ren;
	CameraShake cameraShake;
	ParticleSystem fire_ParticleSystem;

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

	// 4-Way Shooting, transform.Translate is only temporary, will change to RigidBody2D soon
	void FireParticlesDirection()
	{
		ParticleSystem.VelocityOverLifetimeModule fire_Velocity =  fire_ParticleSystem.velocityOverLifetime;
		if(fire_Direction == Fire_SpawnDirection.Right)
		{
			transform.localPosition = new Vector2 (0.9f, 0.6f);
			fire_Velocity.x = 5.0f;
			fire_Velocity.y = 0.0f;
		}
		else if(fire_Direction == Fire_SpawnDirection.Left)
		{
			transform.localPosition = new Vector2 (-0.9f, 0.6f);
			fire_Velocity.x = -5.0f;
			fire_Velocity.y = 0.0f;
		}
		else if(fire_Direction == Fire_SpawnDirection.Up)
		{
			transform.localPosition = new Vector2 (0.0f, 1.0f);
			fire_Velocity.x = 0.0f;
			fire_Velocity.y = 5.0f;
		}
		else
		{
			transform.localPosition = new Vector2 (0.0f, -1.0f);
			fire_Velocity.x = 0.0f;
			fire_Velocity.y = -5.0f;

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
