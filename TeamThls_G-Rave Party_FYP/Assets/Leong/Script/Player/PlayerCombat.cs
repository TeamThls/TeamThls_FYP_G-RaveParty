using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour {

	public Bullet bullet_Script;
	public GameObject bullet_Obj;
	public GameObject laserBeam_Obj;
	public ParticleSystem flame_Particles;
	public ParticleSystem iceCasting_Particles;
	public Transform gun;
	public Transform gunCenter;

	public float fireRate = 0.25f;
	public float nextFire = 0.0f;

	public bool isSlowMo = false;

	//float updateTime = 1.0f;


	Vector3 offset;
	Vector3 objPos;
	Vector3 pos;

	float angle;

	private IEnumerator coroutine;

	PlayerMovement movementScript;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(Shoot());

		movementScript = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(iceCasting_Particles, new Vector3(gun.position.x + 0.5f, gun.position.y, gun.position.z - 0.1f), Quaternion.identity);
			Shoot();
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SlowMo();
		}
		if(Input.GetKey(KeyCode.Mouse1) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			ShootLaser();
		}

		ShootFlame();

	}

	void Shoot ()
	{	
		if(movementScript.player_isRight == true)
		{
			Instantiate(bullet_Obj, new Vector3(gun.position.x + 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}
		else
		{
			Instantiate(bullet_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
		}

	}

	void ShootLaser()
	{
		Instantiate(laserBeam_Obj, new Vector3(gun.position.x - 1.0f, gun.position.y, -0.1f), Quaternion.identity);
	}

	void ShootFlame()
	{
		if(Input.GetKey(KeyCode.J))
		{
			flame_Particles.Play();
			Debug.Log("Flame");
		}
		else if(Input.GetKeyUp(KeyCode.J))
		{
			flame_Particles.Stop();
			Debug.Log("FlameNo");
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
