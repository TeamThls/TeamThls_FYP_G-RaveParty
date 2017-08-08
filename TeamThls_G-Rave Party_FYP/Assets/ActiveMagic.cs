using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMagic : MonoBehaviour {

	public GameObject Manager;
	SharedStats sharestat;
	SpriteRenderer spr;
	public bool inCd = false;
	public float setTime = 0.0f;
	public float currTime = 0.0f;
	public int num = 0;
	public int temp = 0;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		sharestat = Manager.GetComponent<SharedStats> ();
		spr = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inCd == true) {
			spr.color = Color.gray;
			currTime += Time.deltaTime;
			if (currTime >= setTime) {
				spr.color = Color.red;
				inCd = false;
				currTime = 0.0f;
			}
		}

		if (num == 1) {
			sharestat.OnFire = true;
			sharestat.OnIce = false;
			sharestat.OnLaser = false;
		} 
		else if (num == 2) {
			sharestat.OnFire = false;
			sharestat.OnIce = true;
			sharestat.OnLaser = false;
		} 
		else if (num == 3) {
			sharestat.OnFire = false;
			sharestat.OnIce = false;
			sharestat.OnLaser = true;
		}
	}

	void randomFunction(){
		num = Random.Range (1, 4);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (inCd == false) {
			if (other.tag == "Player") {
				temp = num;
				randomFunction ();
				if (num == temp) {
					randomFunction ();
				}
				inCd = true;
			}
		}
	}
}
