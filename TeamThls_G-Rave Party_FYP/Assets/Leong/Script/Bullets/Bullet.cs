using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] float bullet_Speed = 13.0f;
	[SerializeField] float bullet_Time = 0.0f;
	public GameObject player;
	public Movement movementScript;
	public Transform gun;
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
			transform.Translate(Vector2.right * bullet_Speed * Time.deltaTime, Space.World);
		}
		else if(bullet_Direction == Bullet_SpawnDirection.Left)
		{
			transform.Translate(Vector2.left * bullet_Speed * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);

		}
		else if(bullet_Direction == Bullet_SpawnDirection.Up)
		{
			transform.Translate(Vector2.up * bullet_Speed * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
		}
		else
		{
			transform.Translate(Vector2.down * bullet_Speed * Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			cameraShake.Shake(0.3f, 0.1f);
			col.GetComponent<EnemyCollider>().enemy_Health -= bullet_Damage;
			col.GetComponent<EnemyCollider>().WhitenedWhenHit();
			Destroy(this.gameObject);
		}
	}
}
