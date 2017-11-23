using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour {

	Rigidbody2D rgd;
	GameObject Manager;
	GameObject GameManager;
	CameraShake cam_Shake;
	WaypointManager WayManager;
	SharedStats shareStat;

	GameObject target;
	GameObject Player;
	GameObject Player2;

	public GameObject targetPath;

	public List<GameObject> N_List;
	public Waypoint waypoint;

	float a;
	float b;

	float xPos;
	public bool flipx;	
	public bool detect;

	public float speed;
	float step;
	public float jump;

	public bool enemy_groundCheck;

	public bool collected;
	public float setTime;
	public float AttackTime;

	[SerializeField] ParticleSystem playerDamaged_Particles;

	// Use this for initialization
	void Start () {
		rgd = GetComponent<Rigidbody2D> ();
		Manager = GameObject.Find ("WaypointMap");
		GameManager = GameObject.Find ("GameManager");
		cam_Shake = Camera.main.GetComponent<CameraShake>();
		WayManager = Manager.GetComponent<WaypointManager> ();
		shareStat = GameManager.GetComponent<SharedStats> ();

		flipx = this.gameObject.GetComponent<SpriteRenderer> ().flipX;

		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		if (Player2 == null) {
			Player2 = Player;
		}

		targetDetection ();

		for(int i = 0 ; i < WayManager.childList.Count; i++){
			targetPath = WayManager.childList [i];
			if (WayManager.childList [i].GetComponent<Waypoint> ().W_Dist < targetPath.GetComponent<Waypoint> ().totalDist) {
				targetPath = WayManager.childList [i];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		step = speed * Time.deltaTime;

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
					Debug.Log ("123");
					//if (enemy_groundCheck == true) {
					detect = true;
					//}
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
					Debug.Log ("123");
					//if (enemy_groundCheck == true) {
					detect = true;
					//}
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

		if (collected == true) {
			for (int i = 0; i < N_List.Count; i++) {
				if (N_List [i].GetComponent<Waypoint> ().totalDist < targetPath.GetComponent<Waypoint> ().totalDist) {
					targetPath = N_List [i];
				}
			}
			collected = false;
		}

		if (detect == true) {
			setTime += Time.deltaTime;
			if (setTime >= AttackTime) {
				shareStat.player_Health -= 1;
				Debug.Log ("hitting" + shareStat.player_Health);
				setTime = 0.0f;
				cam_Shake.Shake(0.4f, 0.2f);
				target.GetComponent<Animator>().Play("PlayerDamaged");
				Instantiate(playerDamaged_Particles, target.transform.position, Quaternion.identity);
			}
		}
		else {
			Movement ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		waypoint = other.GetComponent<Waypoint> ();
		N_List = new List<GameObject> ();
		if (waypoint != null) {
			for(int i = 0; i < waypoint.NodeList.Count; i++)
			{
				N_List.Add (other.GetComponent<Waypoint> ().NodeList [i]);
				targetPath = N_List [0];
				collected = true;
			}
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

	void Movement(){
		transform.position = Vector3.MoveTowards(this.transform.position, targetPath.transform.position, step);
		//stopDuration += Time.deltaTime;
		//if (canJump == true ) {
			if (targetPath.transform.position.y - this.transform.position.y >= 2.0) {
				rgd.AddForce (transform.up * jump, ForceMode2D.Impulse);
				//canJump = false;
			//}
		}
	}
}
