using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

	public LineRenderer line_Ren;
	bool line_Ren_Decrease;

	float laser_Speed = 100.0f;
	float laser_Time;

	public int laser_Damage = 1;
	BoxCollider2D laser_Collider;

	public float laser_Collider_SizeY;

	public enum Laser_SpawnDirection
	{
		Up, Down, Left, Right, Unassigned
	}

	public Laser_SpawnDirection laser_Direction;

	CameraShake cameraShake;
	// Use this for initialization
	void Start () 
	{
		cameraShake = Camera.main.GetComponent<CameraShake>();
		laser_Collider = GetComponent<BoxCollider2D>();
		laser_Collider_SizeY = laser_Collider.size.y;
		laser_Collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		LaserDirection();
		laser_Collider.enabled = true;

		line_Ren.SetPosition(0, new Vector3(1, 0, 0));
		line_Ren.SetPosition(1, new Vector3(30, 0, 0));
		laser_Time += Time.deltaTime;


		if(line_Ren_Decrease == false)
		{
			line_Ren.widthMultiplier += 50.0f;
			if(line_Ren.widthMultiplier >= 50.0)
			{
				line_Ren_Decrease = true;
			}
		}
		else
		{
			line_Ren.widthMultiplier -= laser_Speed * Time.deltaTime;
			laser_Collider_SizeY -= 5 * Time.deltaTime;
			laser_Collider.size = new Vector2(laser_Collider.size.x, laser_Collider_SizeY);
			if(line_Ren.widthMultiplier < 0.0)
			{
				Destroy(this.gameObject);
			}
		}

		if(laser_Time > 1.2f)
		{
			Destroy(this.gameObject);
		}

	}

	// There's a logic issue with the laser for being default to right
	void LaserDirection ()
	{
		if(laser_Direction == Laser_SpawnDirection.Right)
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		}
		else if(laser_Direction == Laser_SpawnDirection.Left)
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
		}
		else if(laser_Direction == Laser_SpawnDirection.Up)
		{			
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
		}
		else if(laser_Direction == Laser_SpawnDirection.Down)
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			EnemyCollider enemy_Collider = col.GetComponent<EnemyCollider>();
			enemy_Collider.LaserBulletReaction();
			enemy_Collider.enemy_Health -= laser_Damage;
			cameraShake.Shake(1.0f, 0.4f);
		}

	}
}
