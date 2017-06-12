using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health = 100.0f;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	[SerializeField] ParticleSystem p_BloodOnDeath;
	Rigidbody2D rgBody;
	// Use this for initialization
	void Start () {
		rgBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0.0f)
		{
			Instantiate(p_BloodOnDeath, transform.position, Quaternion.identity);
			this.gameObject.SetActive(false);
		}

	}

	public void WhitenedWhenHit()
	{
		anim.Play("EnemyHitted");
	}
}
