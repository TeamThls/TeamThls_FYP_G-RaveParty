using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 1.0f;
	public bool isWalking = false;
	public bool isLeft;
	public bool isRight;
	public bool grounded;
	Animator anim;
	SpriteRenderer spriteRen;

	Rigidbody2D rgBody;
	// Use this for initialization
	void Start () 
	{
		rgBody = GetComponent<Rigidbody2D>();
		anim = transform.Find("Sprite").GetComponent<Animator>();
		spriteRen = transform.Find("Sprite").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		anim.SetBool("IsWalking", isWalking);
		if(Input.GetKey(KeyCode.D))
		{
			isWalking = true;
			spriteRen.flipX = false;
			isRight = true;
			isLeft = false;
			transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
		}
		if(Input.GetKey(KeyCode.A))
		{
			spriteRen.flipX = true;
			isWalking = true;
			isRight = false;
			isLeft = true;
			transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
		}
		if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
		{
			rgBody.AddForce(new Vector2(0.0f, 10.0f), ForceMode2D.Impulse);
			grounded = false;
		}

	}
}
