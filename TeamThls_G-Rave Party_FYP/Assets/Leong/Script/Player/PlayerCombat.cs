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

	[SerializeField] GameObject bullet_Obj;
	[SerializeField] GameObject laserBeam_Obj;
	//public GameObject iceBullet_CurrentObj;


	//public ParticleSystem iceCasting_CurrentParticles;

	public ParticleSystem muzzle_Particles;
	public Transform gun;
	public Transform gunCenter;
	public Player_Controller player_Control;

	public float BulletMana;
	public float FireMana;
	public float BaseFireMana;
	public float LaserMana;
	public float IceMana;

	public GameObject GameManager;
	SharedStats shareStat;
	BulletUpgrades bulletUpg_Script;

	[SerializeField] float normalBullet_FireRate = 0.3f;
	[SerializeField] float laserBullet_FireRate = 4.0f;
	[SerializeField] float iceBullet_FireRate = 2.0f;

	[SerializeField] float iceBullet_CastDelay = 0.5f;
	public float fireDuration = 0.0f;

	public bool isSlowMo = false;
	public bool isShootingIce = false;
	public bool canShootNormalBullet = true;
	public bool canShootIceBullet = true;
	public bool canShootLaser = true;


	private IEnumerator coroutine;
	Bullet bullet;
	[SerializeField] IceBullet iceBullet;
	[SerializeField] LaserBeam laserBeam;
	[SerializeField] Fire fire;

	PlayerMovement movementScript;

	// Use this for initialization
	void Start () 
	{
		bulletUpg_Script = GetComponent<BulletUpgrades>();
		bullet = bullet_Obj.GetComponent<Bullet>();
		//laserBeam = laserBeam_Obj.GetComponent<LaserBeam>();
		movementScript = GetComponent<PlayerMovement>();
		GameManager = GameObject.Find ("GameManager");
		shareStat = GameManager.GetComponent<SharedStats> ();

		BulletMana = shareStat.BulletMana;
		FireMana = shareStat.FireMana;
		BaseFireMana = shareStat.BaseFireMana;
		LaserMana = shareStat.LaserMana;
		IceMana = shareStat.IceMana;
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
		if(Input.GetAxis ("SquareK1") > 0 && canShootNormalBullet == true && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			StartCoroutine(ShootBullet(normalBullet_FireRate));
			shareStat.player_Mana -= BulletMana;
		}


		if(Input.GetAxis ("CircleK1") > 0)
		{
			if(shareStat.OnLaser == true && canShootLaser == true && shareStat.player_Mana >= LaserMana)
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootLaser(laserBullet_FireRate));
				shareStat.player_Mana -= LaserMana;
			}
			else if (shareStat.OnIce == true && canShootIceBullet == true && shareStat.player_Mana >= IceMana) 
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootIceBullet(iceBullet_FireRate));
				shareStat.player_Mana -= IceMana;
			}
			else if (shareStat.OnFire == true) 
			{
				shareStat.setTime = 0.0f;
				ShootFlame();
				//shareStat.player_Mana -= IceMana;
			}

		}
	

			//if (Input.GetAxis ("TriangleK1") > 0 && canShootIceBullet == true && shareStat.player_Mana >= IceMana) 
	}

	void Keyboard2()
	{
		if(Input.GetAxis ("SquareK2") > 0 && canShootNormalBullet == true && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			StartCoroutine(ShootBullet(normalBullet_FireRate));
			shareStat.player_Mana -= BulletMana;

		}

		if(Input.GetAxis ("CircleK2") > 0)
		{
			if(shareStat.OnLaser == true && canShootLaser == true && shareStat.player_Mana >= LaserMana)
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootLaser(laserBullet_FireRate));
				shareStat.player_Mana -= LaserMana;
			}
			else if (shareStat.OnIce == true && canShootIceBullet == true && shareStat.player_Mana >= IceMana) 
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootIceBullet(iceBullet_FireRate));
				shareStat.player_Mana -= IceMana;
			}
			else if (shareStat.OnFire == true) 
			{
				shareStat.setTime = 0.0f;
				ShootFlame();
				//shareStat.player_Mana -= IceMana;
			}

		}

	}

	void Controller1()
	{
		if (Input.GetAxis ("SquareP1") > 0) 
		{
			Debug.Log ("Strangefake");
		}
		if(Input.GetAxis ("SquareP1") > 0 && canShootNormalBullet == true && shareStat.player_Mana >= BulletMana)
		{
			Debug.Log ("Shoot");
			shareStat.setTime = 0.0f;
			StartCoroutine(ShootBullet(normalBullet_FireRate));
			shareStat.player_Mana -= BulletMana;

		}

		if(Input.GetAxis ("CircleP1") > 0)
		{
			if(shareStat.OnLaser == true && canShootLaser == true && shareStat.player_Mana >= LaserMana)
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootLaser(laserBullet_FireRate));
				shareStat.player_Mana -= LaserMana;
			}
			else if (shareStat.OnIce == true && canShootIceBullet == true && shareStat.player_Mana >= IceMana) 
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootIceBullet(iceBullet_FireRate));
				shareStat.player_Mana -= IceMana;
			}
			else if (shareStat.OnFire == true) 
			{
				shareStat.setTime = 0.0f;
				ShootFlame();
				//shareStat.player_Mana -= IceMana;
			}

		}

	}

	void Controller2()
	{
		if(Input.GetAxis ("SquareP2")>0 && canShootNormalBullet == true && shareStat.player_Mana >= BulletMana)
		{
			shareStat.setTime = 0.0f;
			StartCoroutine(ShootBullet(normalBullet_FireRate));
			shareStat.player_Mana -= BulletMana;

		}

		if(Input.GetAxis ("CircleP2") > 0)
		{
			if(shareStat.OnLaser == true && canShootLaser == true && shareStat.player_Mana >= LaserMana)
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootLaser(laserBullet_FireRate));
				shareStat.player_Mana -= LaserMana;
			}
			else if (shareStat.OnIce == true && canShootIceBullet == true && shareStat.player_Mana >= IceMana) 
			{
				shareStat.setTime = 0.0f;
				StartCoroutine(ShootIceBullet(iceBullet_FireRate));
				shareStat.player_Mana -= IceMana;
			}
			else if (shareStat.OnFire == true) 
			{
				shareStat.setTime = 0.0f;
				ShootFlame();
				//shareStat.player_Mana -= IceMana;
			}

		}

	}

	IEnumerator ShootBullet(float duration)
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_MB);
		canShootNormalBullet = false;
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Right;
			Instantiate(bullet_Obj, new Vector2(gun.position.x + 2.0f, gun.position.y), Quaternion.identity);
			Instantiate(muzzle_Particles, new Vector2(gun.position.x + 2.0f, gun.position.y), Quaternion.identity);
		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Left;
			Instantiate(bullet_Obj, new Vector2(gun.position.x - 2.0f, gun.position.y), Quaternion.identity);
			Instantiate(muzzle_Particles, new Vector2(gun.position.x - 2.0f, gun.position.y), Quaternion.identity);
		}
		else if(movementScript.player_isUp == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Up;
			Instantiate(bullet_Obj, new Vector2(gun.position.x, gun.position.y + 2.0f), Quaternion.identity);
			Instantiate(muzzle_Particles, new Vector2(gun.position.x, gun.position.y + 2.0f), Quaternion.identity);
		}
		else if(movementScript.player_isDown == true)
		{
			bullet.bullet_Direction = Bullet.Bullet_SpawnDirection.Down;
			Instantiate(bullet_Obj, new Vector2(gun.position.x, gun.position.y - 2.0f), Quaternion.identity);
			Instantiate(muzzle_Particles, new Vector2(gun.position.x, gun.position.y - 2.0f), Quaternion.identity);
		}
		yield return new WaitForSeconds(duration);
		canShootNormalBullet = true;
	}

	IEnumerator ShootIceBullet(float duration)
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Ice);
		iceBullet = bulletUpg_Script.ice_CurrentObj.GetComponent<IceBullet>();
		bulletUpg_Script.iceBullet = iceBullet;
		isShootingIce = true;
		canShootIceBullet = false;
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Right;
			Instantiate(bulletUpg_Script.ice_CurrentCastingParticles, new Vector3(gun.position.x + 1.0f, gun.position.y, gun.position.z - 1), Quaternion.identity);

			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));

		}
		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Left;
			Instantiate(bulletUpg_Script.ice_CurrentCastingParticles, new Vector3(gun.position.x - 2.0f, gun.position.y, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}
		else if(movementScript.player_isUp == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Up;
			Instantiate(bulletUpg_Script.ice_CurrentCastingParticles, new Vector3(gun.position.x, gun.position.y + 1.0f, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}
		else if(movementScript.player_isDown == true)
		{
			iceBullet.bullet_Direction = IceBullet.Bullet_SpawnDirection.Down;
			Instantiate(bulletUpg_Script.ice_CurrentCastingParticles, new Vector3(gun.position.x, gun.position.y - 1.0f, gun.position.z - 1), Quaternion.identity);
			movementScript.enabled = false;
			movementScript.player_rgBody.velocity = new Vector2(0, 0);
			movementScript.player_rgBody.gravityScale = 0;
			StartCoroutine(WaitForIceBullet(iceBullet_CastDelay));
		}
		yield return new WaitForSeconds(duration);
		canShootIceBullet = true;
	}

	IEnumerator ShootLaser(float duration)
	{	
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Laser);
		laserBeam = bulletUpg_Script.laser_CurrentObj.GetComponent<LaserBeam>();

		canShootLaser = false;

		// Shoot Right Direction
		if(movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Right;
			Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x + 4.0f, gun.position.y, -0.1f), Quaternion.identity);
			// When Level 3, Shoot Three Laser in Northeast, East, Southeast directions

			if(laserBeam.laser_Level == 3)
			{
				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Northeast;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x + 4.0f, gun.position.y, -0.1f), Quaternion.identity);

				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Southeast;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x + 4.0f, gun.position.y, -0.1f), Quaternion.identity);

			}
		}
		// Shoot left Direction

		else if(movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Left;
			Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x - 4.0f, gun.position.y, -0.1f), Quaternion.identity);
			// When Level 3, Shoot Three Laser in Northwest, West, Southwest directions

			if(laserBeam.laser_Level == 3)
			{
				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Northwest;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x - 4.0f, gun.position.y, -0.1f), Quaternion.identity);

				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Southwest;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x - 4.0f, gun.position.y, -0.1f), Quaternion.identity);

			}
		}
		// Shoot Up Direction

		else if(movementScript.player_isUp == true)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Up;
			Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y + 2.0f, -0.1f), Quaternion.identity);
			// When Level 3, Shoot Three Laser in Northeast, North, Northwest directions

			if(laserBeam.laser_Level == 3)
			{
				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Northeast;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y + 2.0f, -0.1f), Quaternion.identity);

				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Northwest;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y + 2.0f, -0.1f), Quaternion.identity);

			}
		}
		// Shoot Down Direction

		else if(movementScript.player_isDown == true)
		{
			laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Down;
			Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y - 2.0f, -0.1f), Quaternion.identity);
			// When Level 3, Shoot Three Laser in Southeast, South, Southwest directions

			if(laserBeam.laser_Level == 3)
			{
				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Southeast;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y - 2.0f, -0.1f), Quaternion.identity);

				laserBeam.laser_Direction = LaserBeam.Laser_SpawnDirection.Southwest;
				Instantiate(bulletUpg_Script.laser_CurrentObj, new Vector3(gun.position.x, gun.position.y - 2.0f, -0.1f), Quaternion.identity);

			}
		}
		yield return new WaitForSeconds(duration);
		canShootLaser = true;
	}

	void ShootFlame()
	{
		if (shareStat.OnFire == true )//&& Input.GetKey (KeyCode.K) ) 
		{
			fire = bulletUpg_Script.fire_CurrentObj.GetComponent<Fire>();
			if (shareStat.player_Mana >= BaseFireMana ) 
			{
				if (movementScript.player_isRight == true && movementScript.player_isUp == false && movementScript.player_isDown == false) 
				{
					fire.fire_Direction = Fire.Fire_SpawnDirection.Right;
				} 
				else if (movementScript.player_isLeft == true && movementScript.player_isUp == false && movementScript.player_isDown == false) 
				{
					fire.fire_Direction = Fire.Fire_SpawnDirection.Left;
				} 
				else if (movementScript.player_isUp == true) 
				{
					fire.fire_Direction = Fire.Fire_SpawnDirection.Up;
				} 
				else if (movementScript.player_isDown == true) 
				{
					fire.fire_Direction = Fire.Fire_SpawnDirection.Down;
				}

				fireDuration += Time.deltaTime;
				bulletUpg_Script.fire_CurrentObj.Emit(2);

			}

			if (fireDuration >= 0.5f) 
			{
				shareStat.setTime = 0.0f;
				shareStat.player_Mana -= FireMana;
				fireDuration = 0;
			}
			if (shareStat.player_Mana < FireMana) 
			{
				bulletUpg_Script.fire_CurrentObj.Stop ();
			}
		}

		else if (shareStat.OnFire == false || Input.GetKeyUp (KeyCode.K)) 
		{
			bulletUpg_Script.fire_CurrentObj.Stop ();
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
			Instantiate(bulletUpg_Script.ice_CurrentObj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Left)
		{
			Instantiate(bulletUpg_Script.ice_CurrentObj, new Vector3(gun.position.x - 3.0f, gun.position.y, -0.1f), Quaternion.identity);

		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Up)
		{
			Instantiate(bulletUpg_Script.ice_CurrentObj, new Vector3(gun.position.x, gun.position.y + 1.0f, -0.1f), Quaternion.identity);
		
		}
		else if(iceBullet.bullet_Direction == IceBullet.Bullet_SpawnDirection.Down)
		{
			Instantiate(bulletUpg_Script.ice_CurrentObj, new Vector3(gun.position.x, gun.position.y - 1.0f, -0.1f), Quaternion.identity);
		
		}
		if(movementScript.player_SlowMo == true)
		{
			movementScript.player_rgBody.gravityScale = 0.8f;
		}
		else
		{
			movementScript.player_rgBody.gravityScale = 3;
		}
		movementScript.enabled = true;
		isShootingIce = false;
	}

}