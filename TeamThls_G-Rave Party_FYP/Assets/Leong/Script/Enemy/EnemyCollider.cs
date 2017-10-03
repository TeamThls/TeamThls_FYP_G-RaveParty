using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health;
	[SerializeField] HealthDeviceHealing healthDevice;
	public SharedStats sharedstats;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	[SerializeField] ParticleSystem p_BloodOnDeath;
	[SerializeField] ParticleSystem p_IceBloodOnDeath;
	[SerializeField] ParticleSystem p_DustOnDeath;
	[SerializeField] ParticleSystem p_BurnedOnDeath;
	[SerializeField] ParticleSystem p_Soul;
	Rigidbody2D rgBody;
	TimeManagement timeManager;

	//float death_PauseTimer = 0.0f;
	public enum enemy_DeathState
	{
		Normal, Ice, Fire, Laser
	}
	public enemy_DeathState enemy_CurrentState;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();
		sharedstats = GameObject.Find ("GameManager").GetComponent<SharedStats>();
		anim = GetComponent<Animator>();
		spr_Ren = GetComponent<SpriteRenderer>();
		if(timeManager == null)
		{
			timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagement>();
		}
		if(healthDevice == null)
		{
			healthDevice = GameObject.Find("P_HealDeviceStand").GetComponent<HealthDeviceHealing>();
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0)
		{
			// WIP, a tiny pause when killed an enemy 
			//death_PauseTimer += Time.deltaTime;

			//Time.timeScale = 1.0f;
			DeathFunction();
			if(transform.parent != null)
			{
				Destroy(transform.parent.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
			sharedstats.player_Gold += 100;
			if(healthDevice.availableHealth < 5)
			{
				healthDevice.availableHealth += 1;
			}
			//sharedstats.player_Score += 100;

			
		}
	}

	void DeathFunction()
	{
		SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_Kill);

		//var main = p_BloodOnDeath.main;
		if(enemy_CurrentState == enemy_DeathState.Normal)
		{
			//main.startColor = Color.yellow;
			Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Ice)
		{
			//main.startColor = Color.cyan;
			Instantiate(p_IceBloodOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Laser)
		{
			Instantiate(p_DustOnDeath, transform.position, Quaternion.identity);
		}
		else if(enemy_CurrentState == enemy_DeathState.Fire)
		{
			Instantiate(p_BurnedOnDeath, transform.position, Quaternion.identity);
		}
		Instantiate(p_Soul, transform.position, Quaternion.identity);
	}

	public void NormalBulletReaction()
	{
		anim.Play("EnemyHitted");
		enemy_CurrentState = enemy_DeathState.Normal;
	}

	public void IceBulletReaction()
	{
		anim.Play("EnemyHittedByIce");

		enemy_CurrentState = enemy_DeathState.Ice;
		StartCoroutine(IceBulletSlow(2.0f));
	}

	public void LaserBulletReaction()
	{
		enemy_CurrentState = enemy_DeathState.Laser;
	}

	public void BurnedReaction()
	{
		anim.Play("EnemyHittedByFire");

		enemy_CurrentState = enemy_DeathState.Fire;
	}

	public IEnumerator IceBulletSlow(float duration)
	{
		if(this.gameObject.GetComponent<WaypointPathfinding>() != null)
		{
			WaypointPathfinding wp = this.gameObject.GetComponent<WaypointPathfinding>();
			wp.speed = 2.0f;

			yield return new WaitForSeconds(duration);
			wp.speed = 4.0f;
		}
		else if(this.gameObject.GetComponent<EnemyMovement>() != null)
		{
			EnemyMovement em = this.gameObject.GetComponent<EnemyMovement>();
			em.speed = 2.0f;

			yield return new WaitForSeconds(duration);
			em.speed = 4.0f;
		}
		else if(this.gameObject.GetComponent<ShootingEnemy>() != null)
		{
			ShootingEnemy se = this.gameObject.GetComponent<ShootingEnemy>();
			se.speed = 2.0f;

			yield return new WaitForSeconds(duration);
			se.speed = 4.0f;
		}


	}
}

