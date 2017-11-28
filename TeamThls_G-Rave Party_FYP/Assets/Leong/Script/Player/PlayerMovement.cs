using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public enum Player_Controller
	{
		Keyboard_1, 
		Keyboard_2,
		Controller_1,
		Controller_2
	}

	public float player_WalkSpeed = 10.0f;
	public float player_horizontalSpeed;
	public float player_JumpStrength = 20.0f;
	public float player_TimeFactor = 1.0f;
	public bool player_isWalking = false;
	public bool player_isLeft = false;
	public bool player_isRight = true;
	public bool player_isUp = false;
	public bool player_isDown = false;
	public bool player_grounded;
	public bool player_SlowMo;
	[SerializeField] ParticleSystem ground_Particles;

	//Animator anim;
	SpriteRenderer player_spriteRen;
	public Rigidbody2D player_rgBody;
	GameObject player1, player2;
	public Player_Controller player_Control;

	// Use this for initialization
	void Start () 
	{
		player_rgBody = GetComponent<Rigidbody2D>();
		//anim = transform.Find("Sprite").GetComponent<Animator>();
		player_spriteRen = transform.Find("Sprite").GetComponent<SpriteRenderer>();
		player1 = GameObject.Find("Player");
		player2 = GameObject.Find("Player2");
		if(ground_Particles == null)
		{
			ground_Particles = this.transform.GetChild(9).GetComponent<ParticleSystem>();
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (player_Control == Player_Controller.Keyboard_1) 
		{
			Keyboard1 ();
			Controller1 ();
		} 
		else if (player_Control == Player_Controller.Keyboard_2) 
		{
			Keyboard2 ();
			Controller2 ();
		} 
		else if (player_Control == Player_Controller.Controller_1) 
		{
			Controller1 ();
		} 
		else if (player_Control == Player_Controller.Controller_2) 
		{
			Controller2 ();
		}
	}



	void Keyboard1()
	{
		//anim.SetBool("IsWalking", player_isWalking);
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("HorizontalK1");
		move.y = Input.GetAxis ("VerticalK1");


		bool flipSpriteX = (player_spriteRen.flipX ? (move.x > 0.0f) : (move.x < -0.01f));

		if (flipSpriteX) 
		{
			player_spriteRen.flipX = !player_spriteRen.flipX;
			player_isRight = !player_isRight;
			player_isLeft = !player_isLeft;
		}
		if(move.y > 0.0f)
		{
			player_isUp = true;

			player_isDown = false;
		}
		else if(move.y < 0.0f)
		{
			player_isUp = false;

			player_isDown = true;
		}
		else if(move.y == 0.0f)
		{
			player_isUp =  false;
			player_isDown = false;
		}


		if (player_horizontalSpeed == 0.0f) 
		{
			player_isWalking = false;
		} 
		else 
		{
			player_isWalking = true;

		}
		if(player_horizontalSpeed != 0.0f && player_grounded)
		{
			StartCoroutine(SpawnGroundDust(0.75f, 1));

		}

		player_horizontalSpeed = move.x * player_WalkSpeed * player_TimeFactor;
		player_rgBody.velocity = new Vector2(Mathf.Lerp(0, player_horizontalSpeed, 7.0f), player_rgBody.velocity.y);



		if(Input.GetButtonDown("JumpK1") && player_grounded)
		{
			player_rgBody.AddForce(Vector2.up * player_JumpStrength * player_TimeFactor, ForceMode2D.Impulse);
			player_grounded = false;
			StartCoroutine(SpawnGroundDust(0.25f, 1));

		}

		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
		Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
			,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);

		


		if(transform.position.y <= camera_MinScreenLimit.y + 1 ||
		   transform.position.y >= camera_MaxScreenLimit.y - 1)
		   {
		   Debug.Log("Teleport");
		   		if(this.gameObject.name == "Player")
		   		{
		   			if(player2 != null)
		   			{
						player1.transform.position = player2.transform.position;
		   				
		   			}

		   		}
		   		else
		   		{
		   			if(player1 != null)
		   			{
						player2.transform.position = player1.transform.position;
		   				
		   			}
		   		}
		   }

	}

	void Keyboard2()
	{
		//anim.SetBool("IsWalking", player_isWalking);
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("HorizontalK2");
		move.y = Input.GetAxis ("VerticalK2");


		bool flipSpriteX = (player_spriteRen.flipX ? (move.x > 0.0f) : (move.x < -0.01f));

		if (flipSpriteX) 
		{
			player_spriteRen.flipX = !player_spriteRen.flipX;
			player_isRight = !player_isRight;
			player_isLeft = !player_isLeft;
		}
		if(move.y > 0.0f)
		{
			player_isUp = true;

			player_isDown = false;
		}
		else if(move.y < 0.0f)
		{
			player_isUp = false;

			player_isDown = true;
		}
		else if(move.y == 0.0f)
		{
			player_isUp =  false;
			player_isDown = false;
		}


		if (player_horizontalSpeed == 0.0f) 
		{
			player_isWalking = false;
		} 
		else 
		{
			player_isWalking = true;
		}
		if(player_horizontalSpeed != 0.0f && player_grounded)
		{
			StartCoroutine(SpawnGroundDust(0.75f, 1));

		}

		player_horizontalSpeed = move.x * player_WalkSpeed * player_TimeFactor;
		player_rgBody.velocity = new Vector2(Mathf.Lerp(0, player_horizontalSpeed, 7.0f), player_rgBody.velocity.y);


		if(Input.GetButtonDown("JumpK2") && player_grounded)
		{
			player_rgBody.AddForce(Vector2.up * player_JumpStrength * player_TimeFactor, ForceMode2D.Impulse);
			player_grounded = false;
			StartCoroutine(SpawnGroundDust(0.25f, 1));
		}

		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
		Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
			,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);

		
		if(transform.position.y <= camera_MinScreenLimit.y + 1||
		   transform.position.y >= camera_MaxScreenLimit.y - 1)
		   {
			Debug.Log("Teleport");
		   		if(this.gameObject.name == "Player")
		   		{
		   			player1.transform.position = player2.transform.position;
		   		}
		   		else
		   		{
		   			player2.transform.position = player1.transform.position;
		   		}
		   }

	}

	void Controller1()
	{
		//anim.SetBool("IsWalking", player_isWalking);
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("HorizontalP1");
		move.y = Input.GetAxis ("VerticalP1");

		// I change the value here, sprite flipping no longer a problem - Leong
		bool flipSpriteX = (player_spriteRen.flipX ? (move.x > 0.0f) : (move.x < -0.01f));

		if (flipSpriteX) 
		{
			player_spriteRen.flipX = !player_spriteRen.flipX;
			player_isRight = !player_isRight;
			player_isLeft = !player_isLeft;
		}
		if(move.y > 0.0f)
		{
			player_isUp = true;

			player_isDown = false;
		}
		else if(move.y < 0.0f)
		{
			player_isUp = false;

			player_isDown = true;
		}
		else if(move.y == 0.0f)
		{
			player_isUp =  false;
			player_isDown = false;
		}


		if (player_horizontalSpeed == 0.0f) 
		{
			player_isWalking = false;
		} 
		else 
		{
			player_isWalking = true;
		}
		if(player_horizontalSpeed != 0.0f && player_grounded)
		{
			StartCoroutine(SpawnGroundDust(0.75f, 1));

		}

		player_horizontalSpeed = move.x * player_WalkSpeed * player_TimeFactor;
		player_rgBody.velocity = new Vector2(Mathf.Lerp(0, player_horizontalSpeed, 7.0f), player_rgBody.velocity.y);

		if(Input.GetButtonDown("JumpP1") && player_grounded)
		{
			player_rgBody.AddForce(Vector2.up * player_JumpStrength * player_TimeFactor, ForceMode2D.Impulse);
			player_grounded = false;
			StartCoroutine(SpawnGroundDust(0.25f, 1));
		}

		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
		Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
			,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);
	}

	void Controller2()
	{
		//anim.SetBool("IsWalking", player_isWalking);
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("HorizontalP2");
		move.y = Input.GetAxis ("VerticalP2");

		// I change the value here, sprite flipping no longer a problem - Leong
		bool flipSpriteX = (player_spriteRen.flipX ? (move.x > 0.0f) : (move.x < -0.01f));

		if (flipSpriteX) 
		{
			player_spriteRen.flipX = !player_spriteRen.flipX;
			player_isRight = !player_isRight;
			player_isLeft = !player_isLeft;
		}
		if(move.y > 0.0f)
		{
			player_isUp = true;

			player_isDown = false;
		}
		else if(move.y < 0.0f)
		{
			player_isUp = false;

			player_isDown = true;
		}
		else if(move.y == 0.0f)
		{
			player_isUp =  false;
			player_isDown = false;
		}


		if (player_horizontalSpeed == 0.0f) 
		{
			player_isWalking = false;
		} 
		else 
		{
			player_isWalking = true;

		}
		if(player_horizontalSpeed != 0.0f && player_grounded)
		{
			StartCoroutine(SpawnGroundDust(0.75f, 1));

		}

		player_horizontalSpeed = move.x * player_WalkSpeed * player_TimeFactor;
		player_rgBody.velocity = new Vector2(Mathf.Lerp(0, player_horizontalSpeed, 7.0f), player_rgBody.velocity.y);
		//rgBody.AddForce (new Vector2 (player_horizontalSpeed, 0.0f), ForceMode2D.Impulse);

		if(Input.GetButtonDown("JumpP2") && player_grounded)
		{
			player_rgBody.AddForce(Vector2.up * player_JumpStrength * player_TimeFactor, ForceMode2D.Impulse);
			player_grounded = false;
			StartCoroutine(SpawnGroundDust(0.25f, 1));

		}

		// Min Screen Limit Vector3, everything is zero (Left Side)
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
		Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
			,Mathf.Clamp(transform.position.y, camera_MinScreenLimit.y + 1, camera_MaxScreenLimit.y - 1), transform.position.z);
	}

	void TeleportBackToOtherPlayer(GameObject teleportingPlayer1, GameObject teleportingPlayer2)
	{
		if(player1)
		{
			teleportingPlayer1.transform.position = teleportingPlayer2.transform.position;
		}
		else if(player2)
		{
			teleportingPlayer2.transform.position = teleportingPlayer1.transform.position;
		}
	}

	// Put checking statement if want delay every movement
	IEnumerator SpawnGroundDust(float interval, int particleEmission)
	{
		ground_Particles.Emit(particleEmission);
	
		yield return new WaitForSeconds(interval);

	}
}