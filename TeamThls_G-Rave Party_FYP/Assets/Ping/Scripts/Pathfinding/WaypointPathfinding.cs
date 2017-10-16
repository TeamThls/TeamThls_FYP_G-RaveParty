using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaypointPathfinding : MonoBehaviour {

	public List<GameObject> N_List;			// waypoint list linked from waypoint manager
	public List<GameObject> TargetList;		// used to calculate the distance
	public GameObject t_Waypoint;			// target waypoint to move;
	public GameObject target;				// player;
	public GameObject Manager;				// waypoint manager
	public GameObject GameManager;			// gameManager
	SharedStats shareStat;
	public GameObject Player;
	public GameObject Player2;

	public bool multiplayer = true;

	public int num;							// waypoint temp count;
	public int counter;						// for double checking;
	public float minDist;					// stock the minimum distance from the waypoint;
	public float distance;					// distance between this enemy with player;

	Rigidbody2D rgd;

	public GameObject temp = null;			// forget
	public GameObject temp2;
	public Waypoint TempWay;				// forget

	public float speed;						// Speed while in movement
	public float step;						// step = speed * time.deltatime
	public float xPos;						// stock the old position 

	public bool canCall = false;			// checking
	public bool canMove = true;				// checking
	public bool detect = false;				// checking for combat
	public bool flipx;						// checking for combat

	public bool enemy_groundCheck = false;	// checking is the enemy on ground or not, to avoid enemy combat enabled while jumping
	public float setTime = 0.0f;			// next attack cd time
	public float AttackTime = 0.0f;			// when setTime reach this, enemy will attack player

	public bool canJump;
	public float jump;
	public float jumpTime;

	public float a;
	public float b;

	public float stopDuration;
	public bool changeDetect;

	WaypointManager WayManager;

	// Use this for initialization
	void Start () {
		rgd = GetComponent<Rigidbody2D> ();
		Manager = GameObject.Find ("WaypointMap");
		GameManager = GameObject.Find ("GameManager");
		WayManager = Manager.GetComponent<WaypointManager> ();
		//t_Waypoint = TargetList [0];
		shareStat = GameManager.GetComponent<SharedStats> ();

		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		if (Player2 == null) {
			Player2 = Player;
		}

		// get the nearest waypoint to move when spawned
		for(int i = 0 ; i < WayManager.childList.Count(); i++){
			t_Waypoint = WayManager.childList [i];
			if (WayManager.childList [i].GetComponent<Waypoint> ().W_Dist < t_Waypoint.GetComponent<Waypoint> ().W_Dist) {
				t_Waypoint = WayManager.childList [i];
			}
		}

		targetDetection ();

		flipx = this.gameObject.GetComponent<SpriteRenderer> ().flipX;
	}
	
	// Update is called once per frame
	void Update () {
		targetDetection ();
		if (canJump == false) {
			jumpTime += Time.deltaTime;
			if (jumpTime >= 0.5f) {
				canJump = true;
				jumpTime = 0.0f;
			}
		}

		if (stopDuration >= 3.0f) {
			changeDetect = true;
		}

		if (changeDetect == true) {
			for(int i = 0 ; i < WayManager.childList.Count(); i++){
				t_Waypoint = WayManager.childList [i];
				if (WayManager.childList [i].GetComponent<Waypoint> ().W_Dist < t_Waypoint.GetComponent<Waypoint> ().W_Dist) {
					t_Waypoint = WayManager.childList [i];
				}
			}
			changeDetect = false;
		}

		if (this.transform.position.x < xPos) {
			flipx = false;
			xPos = this.transform.position.x;
		}
		else if(this.transform.position.x > xPos){
			flipx = true;
			xPos = this.transform.position.x;
		}

		if (flipx == true) {
			LayerMask layerMask = LayerMask.NameToLayer("Enemy");
			RaycastHit2D hitInfo;
			hitInfo = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y) + Vector2.right * 1.0f, Vector2.right, 1.0f, ~(0 << layerMask.value));
			Debug.DrawRay (new Vector2 (transform.position.x, transform.position.y) + Vector2.right, Vector2.right * 1.0f, Color.yellow);

			if(hitInfo.collider != null)
			{
				if(hitInfo.collider.gameObject.tag == "Player")
				{
					if (enemy_groundCheck == true) {
						detect = true;
					}
					target = hitInfo.collider.gameObject;
				}
				else
				{
					detect = false;
				}
			}
			else
			{
				detect = false;
			}
		} 
		else if (flipx == false) {
			LayerMask layerMask = LayerMask.NameToLayer("Enemy");
			RaycastHit2D hitInfo;
			hitInfo = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y) + Vector2.left * 1.0f, Vector2.left, 1.0f, ~(0 << layerMask.value));
			Debug.DrawRay (new Vector2 (transform.position.x, transform.position.y) + Vector2.left, Vector2.left * 1.0f, Color.yellow);

			if(hitInfo.collider != null)
			{
				if(hitInfo.collider.gameObject.tag == "Player")
				{
					if (enemy_groundCheck == true) {
						detect = true;
					}
					target = hitInfo.collider.gameObject;
				}
				else
				{
					detect = false;
				}
			}
			else
			{
				detect = false;
			}
		}



		if (detect == false) {
			setTime = 0.0f;
			step = speed * Time.deltaTime;
			distance = Vector3.Distance (this.gameObject.transform.position, target.transform.position);
		
			if (canMove == true) {
				Movement ();
			}

			//stop movement
			if (this.transform.position == TargetList [num].transform.position) {
				canMove = false;
				temp = TargetList [num];			
			}

			//calculate all the waypoint's total distance
			if (canCall == true && counter == 1) {
				for (int i = 0; i < N_List.Count (); i++) {
					N_List [i].GetComponent<Waypoint> ().W_Dist = Vector3.Distance (this.gameObject.transform.position, N_List [i].transform.position);
				} 
				canCall = false;
				counter = 2;
			}

			//get the minimun distance
			if (canCall == false && counter == 2) {
				minDist = N_List [0].GetComponent<Waypoint> ().totalDist;
				t_Waypoint = N_List [0];
				stopDuration = 0.0f;
				for (int i = 0; i < N_List.Count (); i++) {
					if (N_List [i].GetComponent<Waypoint> ().totalDist < t_Waypoint.GetComponent<Waypoint> ().totalDist) {
						if (N_List [i] == temp) {
							N_List.Remove (N_List [i]);
						}
						t_Waypoint = N_List [i];
					}
				}
				Movement ();
				counter = 3;
				canCall = true;
			}
		} 
		else if (detect == true) {
			setTime += Time.deltaTime;
			if (setTime >= AttackTime) {
				shareStat.player_Health -= 1;
				setTime = 0.0f;
			}
		}

	}

	// waypoint movement;
	void Movement(){
		transform.position = Vector3.MoveTowards(this.transform.position, t_Waypoint.transform.position, step);
		stopDuration += Time.deltaTime;
		//if (canJump == true) {
			if (t_Waypoint.transform.position.y - this.transform.position.y >= 2.0) {
				rgd.AddForce (transform.up * jump, ForceMode2D.Impulse);
			//	canJump = false;
			//}
		}
	}

	// trigger waypoint for add next waypoint
	void OnTriggerEnter2D(Collider2D other){
		TempWay = other.GetComponent<Waypoint> ();
		counter = 0;
		N_List = new List<GameObject> ();
		if (TempWay != null) {
			for(int i = 0; i < TempWay.NodeList.Count(); i++)
			{
				N_List.Add (other.GetComponent<Waypoint> ().NodeList [i]);
			}
			canCall = true;
			counter = 1;
		}
	}

	void targetDetection(){
		a = Vector3.Distance (this.transform.position, Player.transform.position);
		b = Vector3.Distance (this.transform.position, Player2.transform.position);
		if (a < b) {
			target = Player;
		} 
		else {
			target = Player2;
		}
	}
}
