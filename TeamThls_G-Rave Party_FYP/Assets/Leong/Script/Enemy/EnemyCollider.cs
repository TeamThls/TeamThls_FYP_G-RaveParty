using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health = 100.0f;
	public SharedStats sharedstats;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	[SerializeField] ParticleSystem p_BloodOnDeath;
	Rigidbody2D rgBody;
	float death_PauseTimer = 0.0f;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();
		sharedstats = GameObject.Find ("GameManager").GetComponent<SharedStats> ();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0.0f)
		{
			// WIP, a tiny pause when killed an enemy 
			death_PauseTimer += Time.deltaTime;
			if(death_PauseTimer < 0.017f)
			{
				Time.timeScale = 0.01f;
			}
			else
			{
				Time.timeScale = 1.0f;
				Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
				if(transform.parent != null)
				{
					Destroy(transform.parent.gameObject);
				}
				else
				{
					Destroy(this.gameObject);
				}
				sharedstats.player_Gold += 100;
				sharedstats.player_Score += 100;

			}
		}

	}

	public void NormalBulletReaction()
	{
		anim.Play("EnemyHitted");
	}

	public void IceBulletReaction()
	{
		anim.Play("EnemyHittedWithIce");
	}
}
