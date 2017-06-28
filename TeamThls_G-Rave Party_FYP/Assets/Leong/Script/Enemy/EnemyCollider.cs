using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health = 100.0f;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	[SerializeField] ParticleSystem p_BloodOnDeath;
	Rigidbody2D rgBody;
	float death_PauseTimer = 0.0f;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0.0f)
		{
			// WIP, a tiny pause when killed an enemy 
			death_PauseTimer += Time.deltaTime;
			if(death_PauseTimer < 0.01f)
			{
				Time.timeScale = 0.01f;
			}
			else
			{
				Time.timeScale = 1.0f;
				Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
				this.gameObject.SetActive(false);
			}
		}

	}

	public void WhitenedWhenHit()
	{
		anim.Play("EnemyHitted");
	}
}
