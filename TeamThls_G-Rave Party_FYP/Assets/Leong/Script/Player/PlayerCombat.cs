using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour {

	public GameObject bullet_Obj;
	public GameObject laserBeam_Obj;
	public GameObject iceBullet_Obj;
	public ParticleSystem flame_Particles;
	public ParticleSystem iceCasting_Particles;
	public Transform gun;
	public Transform gunCenter;

	[SerializeField] float normalBullet_FireRate = 0.1f;
	[SerializeField] float laserBullet_FireRate = 1.0f;
	[SerializeField] float iceBullet_FireRate = 2.0f;

	[SerializeField] float normalBullet_NextFire = 0.0f;
	[SerializeField] float laserBullet_NextFire = 0.0f;
	[SerializeField] float iceBullet_NextFire = 0.0f;

	public bool isSlowMo = false;

	//float updateTime = 1.0f;

	Vector3 offset;
	Vector3 objPos;
	Vector3 pos;

	float angle;

	private IEnumerator coroutine;
	Bullet bullet;
	IceBullet iceBullet;
	LaserBeam laserBeam;

	ParticleSystem tempPar;

	Movement movementScript;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(Shoot());
		bullet = bullet_Obj.GetComponent<Bullet>();
		iceBullet = iceBullet_Obj.GetComponent<IceBullet>();
		laserBeam = laserBeam_Obj.GetComponent<LaserBeam>();
		movementScript = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.J) && Time.time > normalBullet_NextFire)
		{
			normalBullet_NextFire = Time.time + normalBullet_FireRate;
			ShootBullet();
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SlowMo();
		}
		if(Input.GetKey(KeyCode.L) && Time.time > laserBullet_NextFire)
		{
			laserBullet_NextFire = Time.time + laserBullet_FireRate;
			ShootLaser();
		}
		if(Input.GetKey(KeyCode.I) && Time.time > iceBullet_NextFire)
		{
			iceBullet_NextFire = Time.time + iceBullet_FireRate;
			ShootIceBullet();
		}

		ShootFlame();

	}

	void ShootBullet()
	{	
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Right;
			Instantiate(bullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Left;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 3.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Up;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isDown == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Down;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, -0.1f), Quaternion.identity);
		}

	}

	void ShootIceBullet()
	{
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Right;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x + 1.0f, gun.position.y, gun.position.z - 0.1f), Quaternion.identity);
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
			
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Left;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 3.0f, gun.position.y, gun.position.z - 0.1f), Quaternion.identity);
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x - 3.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Up;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, gun.position.z - 0.1f), Quaternion.identity);
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, -0.1f), Quaternion.identity);

		}
		else if(movementScript.player_isDown == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Down;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, gun.position.z - 0.1f), Quaternion.identity);
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, -0.1f), Quaternion.identity);
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
		if(Input.GetKey(KeyCode.K))
		{
			flame_Particles.Play();
		}
		else if(Input.GetKeyUp(KeyCode.K))
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
