using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float player_WalkSpeed = 10.0f;
	public float player_horizontalSpeed;
	public float player_JumpStrength = 20.0f;
	public bool player_isWalking = false;
	public bool player_isLeft = false;
	public bool player_isRight = true;
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
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("Horizontal");

		bool flipSprite = (player_spriteRen.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite) 
		{
			player_spriteRen.flipX = !player_spriteRen.flipX;
			player_isRight = !player_isRight ;
			player_isLeft = !player_isLeft;
		}

		if (player_horizontalSpeed == 0.0f) 
		{
			player_isWalking = false;
		} 
		else 
		{
			player_isWalking = true;
		}

		player_horizontalSpeed = move.x * player_WalkSpeed;
		rgBody.velocity = new Vector2(Mathf.Lerp(0, player_horizontalSpeed, 7.0f), rgBody.velocity.y);
		//rgBody.AddForce (new Vector2 (player_horizontalSpeed, 0.0f), ForceMode2D.Impulse);
		/*if(Input.GetKey(KeyCode.D))
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

		}*/
		if(Input.GetButtonDown("Jump") && player_grounded)
		{
			rgBody.AddForce(Vector2.up * player_JumpStrength, ForceMode2D.Impulse);
			player_grounded = false;
		}

		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
    	Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
 
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
										,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);

	}
}
