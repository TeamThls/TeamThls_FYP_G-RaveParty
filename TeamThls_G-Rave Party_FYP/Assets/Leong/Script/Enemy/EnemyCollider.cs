using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	public float enemy_Health = 100.0f;
	[SerializeField] SpriteRenderer spr_Ren;
	[SerializeField] Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemy_Health <= 0.0f)
		{
			this.transform.parent.gameObject.SetActive(false);
		}

	}

	public void WhitenedWhenHit()
	{
		anim.Play("EnemyHitted");
	}
}
