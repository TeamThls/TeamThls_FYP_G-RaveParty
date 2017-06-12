using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public enum Player_Controller
	{
		Player_1, Player_2
	}
	public float player_WalkSpeed = 10.0f;
	public float player_JumpStrength = 20.0f;
	public bool player_isWalking = false;
	public bool player_isLeft;
	public bool player_isRight;
	public bool player_grounded;
	Animator anim;
	SpriteRenderer player_spriteRen;
	Rigidbody2D rgBody;
	public Player_Controller player_Control;
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
		if(player_Control == Player_Controller.Player_1)
		{
			FirstPlayerControl ();
		}
		else
		{
			SecondPlayerControl ();
		}

	}

	void FirstPlayerControl ()
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
		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
    	Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
 
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
										,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);
	}

	void SecondPlayerControl ()
	{
		anim.SetBool("IsWalking", player_isWalking);


		if(Input.GetKey(KeyCode.RightArrow))
		{
			player_isWalking = true;
			player_spriteRen.flipX = false;
			player_isRight = true;
			player_isLeft = false;
			rgBody.velocity = new Vector2(Mathf.Lerp(0, player_WalkSpeed, 7.0f), rgBody.velocity.y);

		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			player_spriteRen.flipX = true;
			player_isWalking = true;
			player_isRight = false;
			player_isLeft = true;
			rgBody.velocity = new Vector2(Mathf.Lerp(0, -player_WalkSpeed, 7.0f), rgBody.velocity.y);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && player_grounded == true)
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
