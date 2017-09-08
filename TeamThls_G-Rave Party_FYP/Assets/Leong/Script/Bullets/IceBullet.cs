using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour {

	[SerializeField] float iceBullet_Speed = 13.0f;
	[SerializeField] float iceBullet_Time = 0.0f;
	public float iceBullet_TimeFactor = 1.0f;
	public int iceBullet_Damage = 30;
	//public GameObject player;
	public Movement movementScript;
	public Transform gun;
	public enum Bullet_SpawnDirection
	{
		Up, Down, Left, Right
	}
	public Bullet_SpawnDirection bullet_Direction;

	//[SerializeField] MeshRenderer mesh_Ren;
	[SerializeField] LineRenderer line_Ren;
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
		line_Ren.widthMultiplier = Mathf.Clamp(iceBullet_Time * 10, 1, 15);

		iceBullet_Time += Time.deltaTime;
		if(iceBullet_Time > 5.0f)
			Destroy(this.gameObject);

	}

	// 4-Way Shooting, transform.Translate is only temporary, will change to RigidBody2D soon
	void BulletDirection()
	{
		if(bullet_Direction == Bullet_SpawnDirection.Right)
		{
			transform.Translate(Vector2.right * iceBullet_Speed * iceBullet_TimeFactor * Time.deltaTime, Space.World);
		}
		else if(bullet_Direction == Bullet_SpawnDirection.Left)
		{
			transform.Translate(Vector2.left * iceBullet_Speed * iceBullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);

		}
		else if(bullet_Direction == Bullet_SpawnDirection.Up)
		{
			transform.Translate(Vector2.up * iceBullet_Speed * iceBullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
		}
		else
		{
			transform.Translate(Vector2.down * iceBullet_Speed * iceBullet_TimeFactor * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			EnemyCollider enemy_Collider = col.GetComponent<EnemyCollider>();
			cameraShake.Shake(0.5f, 0.1f);
			enemy_Collider.IceBulletReaction();
			enemy_Collider.enemy_Health -= iceBullet_Damage;
		}
	}
}
