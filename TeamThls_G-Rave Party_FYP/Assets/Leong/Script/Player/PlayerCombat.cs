using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour {

	public GameObject bullet_Obj;
	public GameObject laserBeam_Obj;
	public ParticleSystem flame_Particles;
	public ParticleSystem iceCasting_Particles;
	public Transform gun;
	public Transform gunCenter;
	SharedStats shareStat;

	public float fireRate = 0.25f;
	public float nextFire = 0.0f;
	public float fireDuration = 0.0f;

	public bool isSlowMo = false;

	//float updateTime = 1.0f;

	Vector3 offset;
	Vector3 objPos;
	Vector3 pos;

	float angle;

	private IEnumerator coroutine;
	Bullet bullet;
	LaserBeam laserBeam;

	Movement movementScript;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(Shoot());
		bullet = bullet_Obj.GetComponent<Bullet>();
		laserBeam = laserBeam_Obj.GetComponent<LaserBeam>();
		movementScript = GetComponent<Movement>();
		shareStat = GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.K) && Time.time > nextFire && shareStat.player_Mana >= 2)
		{
			nextFire = Time.time + fireRate;
			Shoot();
			shareStat.player_Mana -= 2;
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SlowMo();
		}
		if(Input.GetKey(KeyCode.L) && Time.time > nextFire && shareStat.player_Mana >= 20)
		{
			nextFire = Time.time + fireRate;
			ShootLaser();
			shareStat.player_Mana -= 20;
		}

		ShootFlame();

	}

	void Shoot ()
	{	
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Right;
			Instantiate(bullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x + 1.0f, gun.position.y, gun.position.z - 0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Left;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 3.0f, gun.position.y, -0.1f), Quaternion.identity);
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 3.0f, gun.position.y, gun.position.z - 0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Up;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, -0.1f), Quaternion.identity);
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, gun.position.z - 0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isDown == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Down;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, -0.1f), Quaternion.identity);
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, gun.position.z - 0.1f), Quaternion.identity);
		}

	}


	void ShootLaser()
	{
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Right;
			Instantiate(laserBeam_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Left;
			Instantiate(laserBeam_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Up;
			Instantiate(laserBeam_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isDown == true)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Down;
			Instantiate(laserBeam_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
	}

	void ShootFlame()
	{
		if(shareStat.player_Mana >= 5 && Input.GetKey(KeyCode.J))
		{
			fireDuration += Time.deltaTime;
			flame_Particles.Play();
			if (fireDuration >= 0.5f) {
				shareStat.player_Mana -= 5;
				fireDuration = 0;
			}
			if (shareStat.player_Mana < 5) {
				flame_Particles.Stop ();
			}
		}
		else if(Input.GetKeyUp(KeyCode.J))
		{
			flame_Particles.Stop();
		}
	}

	void SlowMo()
	{
		if(isSlowMo == false)
		{
			isSlowMo = true;
			Time.timeScale = 0.5f;
		}
		else
		{
			isSlowMo = false;
			Time.timeScale = 1.0f;
		}

	}

}
