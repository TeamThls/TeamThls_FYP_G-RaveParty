using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

	//public LineRenderer line_Ren;
	//bool line_Ren_Decrease;

	//float laser_Speed = 100.0f;
	//float laser_Time;

	public int laser_Damage = 1;
	public int laser_Level;
	ParticleSystem laser_Particles;

	public float laser_Collider_SizeY;

	public enum Laser_SpawnDirection
	{
		Up, Down, Left, Right, Northeast, Northwest, Southeast, Southwest, Unassigned
	}

	public Laser_SpawnDirection laser_Direction;

	CameraShake cameraShake;
	// Use this for initialization
	void Start () 
	{
		cameraShake = Camera.main.GetComponent<CameraShake>();

		if(laser_Particles == null)
		{
			laser_Particles = GetComponent<ParticleSystem>();
		}
		//laser_Collider_SizeY = laser_Collider.size.y;
		//laser_Collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		LaserDirection();

	}

	// There's a logic issue with the laser for being default to right
	void LaserDirection ()
	{
		switch(laser_Direction)
		{
			case Laser_SpawnDirection.Right:
				transform.Translate(Vector2.right * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Left:
				transform.Translate(Vector2.left * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(180.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Up:
				transform.Translate(Vector2.up * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(270.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Down:
				transform.Translate(Vector2.down * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(90.0f, 90.0f, 0.0f);
				break;

			case Laser_SpawnDirection.Northeast:
				transform.Translate(new Vector2(1, 1) * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(-45.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Northwest:
				transform.Translate(new Vector2(-1, 1) * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(45.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Southeast:
				transform.Translate(new Vector2(1, -1) * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(225.0f, 90.0f, 0.0f);
				break;
			case Laser_SpawnDirection.Southwest:
				transform.Translate(new Vector2(-1, -1) * 100.0f * Time.deltaTime, Space.World);
				transform.rotation = Quaternion.Euler(135.0f, 90.0f, 0.0f);
				break;

		}
	}

	void OnParticleCollision(GameObject obj)
	{
		if(obj.GetComponent<EnemyCollider>() != null)
		{
			EnemyCollider enemy_Collider = obj.GetComponent<EnemyCollider>();
			enemy_Collider.LaserBulletReaction();
			enemy_Collider.enemy_Health -= laser_Damage;
			cameraShake.Shake(1.0f, 0.4f);
		}
		else if(obj.GetComponent<RuneColliderFunction>() != null)
		{
		Debug.Log("RUne");
			RuneColliderFunction rune_Collider = obj.GetComponent<RuneColliderFunction>();
			rune_Collider.RuneDamage();
		}
		
	}
}
