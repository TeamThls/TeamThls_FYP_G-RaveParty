using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] float bullet_Speed = 13.0f;

	float bullet_Time = 0.0f;
	public float bullet_TimeFactor = 1.0f;
	public GameObject player;
	public Movement movementScript;
	public Transform gun;
	[SerializeField] ParticleSystem spark_Particle;
	public int bullet_Damage = 10;

	public enum Bullet_SpawnDirection
	{
		Up, Down, Left, Right
	}
	public Bullet_SpawnDirection bullet_Direction;

	//[SerializeField] MeshRenderer mesh_Ren;
	//[SerializeField] LineRenderer line_Ren;
	CameraShake cameraShake;

	// Use this for initialization
	void Start () 
	{
		cameraShake = Camera.main.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		BulletDirection();

		bullet_Time += Time.deltaTime;
		if(bullet_Time > 5.0f)
			Destroy(this.gameObject);

	}

	// 4-Way Shooting, transform.Translate is only temporary, will change to RigidBody2D soon
	void BulletDirection()
	{
		if(bullet_Direction == Bullet_SpawnDirection.Right)
		{
			transform.Translate(Vector2.right * bullet_Speed * bullet_TimeFactor * Time.deltaTime, Space.World);
		}
		else if(bullet_Direction == Bullet_SpawnDirection.Left)
		{
			transform.Translate(Vector2.left * bullet_Speed * bullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);

		}
		else if(bullet_Direction == Bullet_SpawnDirection.Up)
		{
			transform.Translate(Vector2.up * bullet_Speed * bullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
		}
		else
		{
			transform.Translate(Vector2.down * bullet_Speed * bullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
		}
	}

	void BulletSparkEffect(GameObject collider)
	{
		ParticleSystem.VelocityOverLifetimeModule spark_Velocity = spark_Particle.velocityOverLifetime;
		var main = spark_Particle.main;
		if(bullet_Direction == Bullet_SpawnDirection.Right)
		{
			spark_Velocity.x = -5.0f;
			spark_Velocity.y = 0.0f;
			main.startRotation = 0;
			Instantiate(spark_Particle, new Vector3(collider.transform.position.x - 1.5f, collider.transform.position.y, -0.5f), Quaternion.identity);
		}
		else if(bullet_Direction == Bullet_SpawnDirection.Left)
		{
			spark_Velocity.x = 5.0f;
			spark_Velocity.y = 0.0f;
			main.startRotation = 0;
			Instantiate(spark_Particle, new Vector3(collider.transform.position.x + 1.5f, collider.transform.position.y, -0.5f), Quaternion.identity);

		}
		else if(bullet_Direction == Bullet_SpawnDirection.Up) 
		{
			spark_Velocity.x = 0.0f;
			spark_Velocity.y = -7.5f;
			main.startRotation = 90.0f * Mathf.Deg2Rad;
			Instantiate(spark_Particle, new Vector3(collider.transform.position.x, collider.transform.position.y - 0.5f, -0.5f), Quaternion.identity);
		}
		else if(bullet_Direction == Bullet_SpawnDirection.Down) 
		{
			spark_Velocity.x = 0.0f;
			spark_Velocity.y = 7.5f;
			main.startRotation = 90.0f * Mathf.Deg2Rad;
			Instantiate(spark_Particle, new Vector3(collider.transform.position.x, collider.transform.position.y + 0.5f, -0.5f), Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			EnemyCollider enemy_Collider = col.GetComponent<EnemyCollider>();
			cameraShake.Shake(0.3f, 0.1f);
			enemy_Collider.NormalBulletReaction();
			enemy_Collider.enemy_Health -= bullet_Damage;
			BulletSparkEffect(col.gameObject);
			Destroy(this.gameObject);
		}
		if(col.CompareTag("ShootEnemy"))
		{
			EnemyCollider enemy_Collider = col.GetComponent<EnemyCollider>();
			cameraShake.Shake(0.3f, 0.1f);
			enemy_Collider.NormalBulletReaction();
			enemy_Collider.enemy_Health -= bullet_Damage;
			BulletSparkEffect(col.gameObject);
			Destroy(this.gameObject);
		}
	}
}
