using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float player_WalkSpeed = 10.0f;
	public float player_JumpStrength = 20.0f;
	public bool player_isWalking = false;
	public bool player_isLeft;
	public bool player_isRight;
	public bool player_grounded;
	Animator anim;
	SpriteRenderer player_spriteRen;
	Rigidbody2D rgBody;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();
		anim = transform.Find("Sprite").GetComponent<Animator>();
		player_spriteRen = transform.Find("Sprite").GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		anim.SetBool("IsWalking", player_isWalking);

		if(Input.GetKey(KeyCode.D))
		{
			player_isWalking = true;
			player_spriteRen.flipX = false;
			player_isRight = true;
			player_isLeft = false;
			rgBody.velocity = new Vector2(Mathf.Lerp(0, player_WalkSpeed, 7.0f), rgBody.velocity.y);

		}
		if(Input.GetKey(KeyCode.A))
		{
			player_spriteRen.flipX = true;
			player_isWalking = true;
			player_isRight = false;
			player_isLeft = true;
			rgBody.velocity = new Vector2(Mathf.Lerp(0, -player_WalkSpeed, 7.0f), rgBody.velocity.y);

		}
		if(Input.GetKeyDown(KeyCode.Space) && player_grounded == true)
		{
			rgBody.AddForce(Vector2.up * player_JumpStrength, ForceMode2D.Impulse);
			player_grounded = false;
		}


	}
}
