using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour {

	public enum Player_Controller
	{
		Keyboard_1, 
		Keyboard_2,
		Controller_1,
		Controller_2
	}

	public GameObject bullet_Obj;
	public GameObject laserBeam_Obj;
	public GameObject iceBullet_Obj;
	public ParticleSystem flame_Particles;
	public ParticleSystem iceCasting_Particles;
	public Transform gun;
	public Transform gunCenter;
	public Player_Controller player_Control;

	public int BulletMana;
	public int FireMana;
	public int BaseFireMana;
	public int LaserMana;
	public int IceMana;

	public GameObject GameManager;
	SharedStats shareStat;

	[SerializeField] float normalBullet_FireRate = 0.1f;
	[SerializeField] float laserBullet_FireRate = 4.0f;
	[SerializeField] float iceBullet_FireRate = 2.0f;

	[SerializeField] float normalBullet_NextFire = 0.0f;
	[SerializeField] float laserBullet_NextFire = 0.0f;
	[SerializeField] float iceBullet_NextFire = 0.0f;
	[SerializeField] float iceBullet_CastDelay = 0.5f;
	public float fireDuration = 0.0f;

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
	Fire fire;

	ParticleSystem tempPar;

	PlayerMovement movementScript;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(Shoot());
		bullet = bullet_Obj.GetComponent<Bullet>();
		iceBullet = iceBullet_Obj.GetComponent<IceBullet>();
		laserBeam = laserBeam_Obj.GetComponent<LaserBeam>();
		fire = flame_Particles.GetComponent<Fire>();
		movementScript = GetComponent<PlayerMovement>();
		GameManager = GameObject.Find ("GameManager");
		shareStat = GameManager.GetComponent<SharedStats> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (player_Control == Player_Controller.Keyboard_1) 
		{
			Keyboard1 ();
		} 
		else if (player_Control == Player_Controller.Keyboard_2) 
		{
			Keyboard2 ();
		} 
		else if (player_Control == Player_Controller.Controller_1) 
		{
			Controller1 ();
		} 
		else if (player_Control == Player_Controller.Controller_2) 
		{
			Controller2 ();
		}



	}

	void Keyboard1()
	{
		if(Input.GetAxis ("SquareK1")>0 && Time.time > normalBullet_NextFire  && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			normalBullet_NextFire = Time.time + normalBullet_FireRate;
			ShootBullet();
			shareStat.player_Mana -= BulletMana;
		}
		//if(Input.GetAxis (KeyCode.Alpha1))
		//{
		//	shareStat.setTime = 0.0f;
		//	SlowMo();
		//}
		if(shareStat.OnLaser == true){
			if(Input.GetAxis ("CircleK1")>0 && Time.time > laserBullet_NextFire && shareStat.player_Mana >= LaserMana)
			{
				shareStat.setTime = 0.0f;
				laserBullet_NextFire = Time.time + laserBullet_FireRate;
				ShootLaser();
				shareStat.player_Mana -= LaserMana;
			}
		}
		if (shareStat.OnIce == true) {
			if (Input.GetAxis ("TriangleK1") > 0 && Time.time > iceBullet_NextFire && shareStat.player_Mana >= IceMana) {
				shareStat.setTime = 0.0f;
				iceBullet_NextFire = Time.time + iceBullet_FireRate;
				ShootIceBullet ();
				shareStat.player_Mana -= IceMana;
			}
		}

		ShootFlame();
	}

	void Keyboard2()
	{
		if(Input.GetAxis ("SquareK2")>0 && Time.time > normalBullet_NextFire && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			normalBullet_NextFire = Time.time + normalBullet_FireRate;
			ShootBullet();
			shareStat.player_Mana -= BulletMana;
		}
		//if(Input.GetAxis (KeyCode.Alpha1))
		//{
		//	SlowMo();
		//}
		if (shareStat.OnLaser == true) {
			if (Input.GetAxis ("CircleK2") > 0 && Time.time > laserBullet_NextFire && shareStat.player_Mana >= LaserMana) {
				shareStat.setTime = 0.0f;
				laserBullet_NextFire = Time.time + laserBullet_FireRate;
				ShootLaser ();
				shareStat.player_Mana -= LaserMana;
			}
		}

		if (shareStat.OnIce == true) {
			if (Input.GetAxis ("TriangleK2") > 0 && Time.time > iceBullet_NextFire && shareStat.player_Mana >= IceMana) {
				shareStat.setTime = 0.0f;
				iceBullet_NextFire = Time.time + iceBullet_FireRate;
				ShootIceBullet ();
				shareStat.player_Mana -= IceMana;
			}
		}
		//ShootFlame();
	}

	void Controller1()
	{
		if(Input.GetAxis ("SquareP1")>0 && Time.time > normalBullet_NextFire && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			normalBullet_NextFire = Time.time + normalBullet_FireRate;
			ShootBullet();
			shareStat.player_Mana -= BulletMana;
		}
		//if(Input.GetAxis (KeyCode.Alpha1))
		//{
		//	SlowMo();
		//}
		if (shareStat.OnLaser == true) {
			if (Input.GetAxis ("CircleP1") > 0 && Time.time > laserBullet_NextFire && shareStat.player_Mana >= LaserMana) {
				shareStat.setTime = 0.0f;
				laserBullet_NextFire = Time.time + laserBullet_FireRate;
				ShootLaser ();
				shareStat.player_Mana -= LaserMana;
			}
		}

		if (shareStat.OnIce == true) {
			if (Input.GetAxis ("TriangleP1") > 0 && Time.time > iceBullet_NextFire && shareStat.player_Mana >= IceMana) {
				shareStat.setTime = 0.0f;
				iceBullet_NextFire = Time.time + iceBullet_FireRate;
				ShootIceBullet ();
				shareStat.player_Mana -= 5;
			}
		}

		//ShootFlame();
	}

	void Controller2()
	{
		if(Input.GetAxis ("SquareP2")>0 && Time.time > normalBullet_NextFire && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			normalBullet_NextFire = Time.time + normalBullet_FireRate;
			ShootBullet();
			shareStat.player_Mana -= BulletMana;
		}
		//if(Input.GetAxis (KeyCode.Alpha1))
		//{
		//	SlowMo();
		//}
		if (shareStat.OnLaser == true) {
			if (Input.GetAxis ("CircleP2") > 0 && Time.time > laserBullet_NextFire && shareStat.player_Mana >= LaserMana) {
				shareStat.setTime = 0.0f;
				laserBullet_NextFire = Time.time + laserBullet_FireRate;
				ShootLaser ();
				shareStat.player_Mana -= LaserMana;
			}
		}

		if (shareStat.OnIce == true) {
			if (Input.GetAxis ("TriangleP2") > 0 && Time.time > iceBullet_NextFire && shareStat.player_Mana >= IceMana) {
				shareStat.setTime = 0.0f;
				iceBullet_NextFire = Time.time + iceBullet_FireRate;
				ShootIceBullet ();
				shareStat.player_Mana -= IceMana;
			}
		}

		//ShootFlame();
	}

	void ShootBullet()
	{	
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_MB);

		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Right;
			Instantiate(bullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, 0.0f), Quaternion.identity);
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Left;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 3.0f, gun.position.y, 0.0f), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Up;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y + 1.0f, 0.0f), Quaternion.identity);
		}
		else if(movementScript.player_isDown == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Down;
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y - 1.0f, 0.0f), Quaternion.identity);
		}

	}

	void ShootIceBullet()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Ice);
		
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Right;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x + 1.0f, gun.position.y, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));

		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Left;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x - 3.0f, gun.position.y, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}
		else if(movementScript.player_isUp == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Up;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x, gun.position.y + 1.0f, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}
		else if(movementScript.player_isDown == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Down;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x, gun.position.y - 1.0f, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}

	}


	void ShootLaser()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Laser);

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
		if (shareStat.OnFire == true) {
			if (shareStat.player_Mana >= BaseFireMana && Input.GetKey (KeyCode.K)) {
				if (movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false) {
					fire.fire_Direction = Fire.Fire_SpawnDirection.Right;
				} else if (movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false) {
					fire.fire_Direction = Fire.Fire_SpawnDirection.Left;
				} else if (movementScript.player_isUp == true) {
					fire.fire_Direction = Fire.Fire_SpawnDirection.Up;
				} else if (movementScript.player_isDown == true) {
					fire.fire_Direction = Fire.Fire_SpawnDirection.Down;
				}
				fireDuration += Time.deltaTime;
				flame_Particles.Play ();
				if (fireDuration >= 0.5f) {
					shareStat.setTime = 0.0f;
					shareStat.player_Mana -= FireMana;
					fireDuration = 0;
				}
				if (shareStat.player_Mana < FireMana) {
					flame_Particles.Stop ();
				}
			} else if (Input.GetKeyUp (KeyCode.K)) {
				flame_Particles.Stop ();
			}
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

	IEnumerator WaitForIceBullet(float updateTime)
	{
		yield return new WaitForSeconds(updateTime);
		if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Right)
		{
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Left)
		{
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x - 3.0f, gun.position.y, -0.1f), Quaternion.identity);

		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Up)
		{
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x, gun.position.y + 1.0f, -0.1f), Quaternion.identity);
		
		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Down)
		{
			Instantiate(iceBullet_Obj, new Vector3(gun.position.x, gun.position.y - 1.0f, -0.1f), Quaternion.identity);
		
		}
		movementScript.player_rgBody.gravityScale = 3;
		movementScript.enabled = true;
	}

}