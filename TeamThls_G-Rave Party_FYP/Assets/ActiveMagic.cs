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
	public int temp = 0;

	public GameObject cdText;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		sharestat = Manager.GetComponent<SharedStats> ();
		spr = this.GetComponent<SpriteRenderer> ();
		randomFunction ();
		cdText = GameObject.Find ("CD text");
		//TextMesh cdt = cdText.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (inCd == true) {
			spr.color = Color.gray;
			currTime += Time.deltaTime;
			if (currTime >= setTime) {
				temp = sharestat.RandomNum;
				randomFunction ();
				if (sharestat.RandomNum == temp) {
					randomFunction ();
				}
				inCd = false;
				currTime = 0.0f;
			}
		}*/

		if (inCd == true) {
			currTime += Time.deltaTime;
			cdText.GetComponent<TextMesh> ().text = currTime.ToString ();;
			cdText.GetComponent<TextMesh> ().fontSize = 8;
			spr.color = Color.gray;
		}

		if (currTime >= setTime) {
			inCd = false;
			currTime = 0.0f;
		}

		if (inCd == true) {
			spr.color = Color.gray;
		}
	}

	void randomFunction(){
		sharestat.RandomNum = Random.Range (1, 4);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (inCd == false) {
				temp = sharestat.RandomNum;
				randomFunction ();
				if (sharestat.RandomNum == temp) {
					randomFunction ();
				}
				if (sharestat.RandomNum == 1) {
					sharestat.OnFire = true;
					sharestat.OnIce = false;
					sharestat.OnLaser = false;
					spr.color = Color.red;
				} 
				else if (sharestat.RandomNum == 2) {
					sharestat.OnFire = false;
					sharestat.OnIce = true;
					sharestat.OnLaser = false;
					spr.color = Color.blue;
				} 
				else if (sharestat.RandomNum == 3) {
					sharestat.OnFire = false;
					sharestat.OnIce = false;
					sharestat.OnLaser = true;
					spr.color = Color.green;
				} 
				else if(sharestat.RandomNum == 0) {
					sharestat.OnFire = false;
					sharestat.OnIce = false;
					sharestat.OnLaser = false;
				}
				inCd = true;
			}
		}
	}
}
