using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {

	public GameObject Manager;
	public GameObject Player;
	public GameObject Player2;
	public GameObject Target;

	SharedStats shrd;
	CameraShake cam_Shake;
	[SerializeField] ParticleSystem playerDamaged_Particles;

	float a;
	float b;

	public float speed;
	public float setTime;

	public bool isRight;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		Player = GameObject.Find ("Player");
		Player2 = GameObject.Find ("Player2");
		shrd = Manager.GetComponent<SharedStats> ();
		cam_Shake = Camera.main.GetComponent<CameraShake>();
		Target = Player;
		targetDetection ();
		if (this.transform.position.x > Target.transform.position.x) {
			isRight = false;
		}
		else if (this.transform.position.x < Target.transform.position.x) {
			isRight = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		setTime += Time.deltaTime;
		if (isRight) {
			this.transform.Translate (Vector3.right * speed * Time.deltaTime);
		} 
		else if (!isRight) {
			this.transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (setTime >= 10.0f) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			shrd.player_Health -= 1;
			other.transform.GetChild(1).GetComponent<Animator>().Play("PlayerDamaged");
			cam_Shake.Shake(0.4f, 0.2f);
			Instantiate(playerDamaged_Particles, other.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}

	void targetDetection()
	{
		a = Vector3.Distance (this.transform.position, Player.transform.position);
		b = Vector3.Distance (this.transform.position, Player2.transform.position);

		if (a > b) {
			Target = Player2;
		} 
		else if (a < b) {
			Target = Player;
		}
	}
}
