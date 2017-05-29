using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Combat : MonoBehaviour {

	public Bullet bullet_Script;
	public GameObject bullet_Obj;
	public GameObject laserBeam_Obj;
	public ParticleSystem flame_Obj;
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

	Movement movementScript;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(Shoot());

		movementScript = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*objPos = Camera.main.WorldToScreenPoint(gunCenter.position);
		pos = Input.mousePosition - objPos;
		angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		gunCenter.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
		if(Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
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
		if(movementScript.isRight == true)
		{
			Instantiate(bullet_Obj, new Vector2(gun.position.x + 1.0f, gun.position.y), Quaternion.identity);
		}
		else
		{
			Instantiate(bullet_Obj, new Vector2(gun.position.x - 1.0f, gun.position.y), Quaternion.identity);
		}

	}

	void ShootLaser()
	{
		Instantiate(laserBeam_Obj, new Vector2(gun.position.x - 1.0f, gun.position.y), Quaternion.identity);
	}

	void ShootFlame()
	{
		if(Input.GetKey(KeyCode.J))
		{
			flame_Obj.Play();
			Debug.Log("Flame");
		}
		else if(Input.GetKeyUp(KeyCode.J))
		{
			flame_Obj.Stop();
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
