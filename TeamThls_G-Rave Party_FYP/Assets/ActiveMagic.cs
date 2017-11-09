using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMagic : MonoBehaviour {

	public GameObject Manager;
	public GameObject GUI;
	SharedStats sharestat;
	SpriteRenderer spr;
	public bool inCd = false;
	public float setTime = 0.0f;
	public float currTime = 0.0f;
	public int num = 0;
	public int temp = 0;
	public bool randomed;
	[SerializeField] Tutorial tutorial_Object;

	public GameObject cdText;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		GUI = GameObject.Find ("GUI");
		sharestat = Manager.GetComponent<SharedStats> ();
		spr = this.GetComponent<SpriteRenderer> ();
		randomFunction ();
		cdText = GameObject.Find ("CD text");
		if(tutorial_Object == null)
		{
			tutorial_Object = GameObject.Find("Tutorial").GetComponent<Tutorial>();
		}
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

		if (inCd == false && randomed == false) {
			randomFunction ();
			if (num == 1) {
				spr.color = Color.red;
				randomed = true;
			} 
			else if (num == 2) {
				spr.color = Color.blue;
				randomed = true;
			} 
			else if (num == 3) {
				spr.color = Color.green;
				randomed = true;
			} 
			else {
				spr.color = Color.gray;
			}
		}

		/*if (inCd == true) {
			currTime += Time.deltaTime;
			cdText.GetComponent<TextMesh> ().text = currTime.ToString ();;
			cdText.GetComponent<TextMesh> ().fontSize = 8;
			spr.color = Color.gray;
		}*/

		if (currTime >= setTime) {
			inCd = false;
			randomed = false;
			currTime = 0.0f;
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (inCd == true) {
			currTime += Time.deltaTime;
			spr.color = Color.gray;
			this.GetComponent<SpriteRenderer> ().enabled = false;
			if (GUI.GetComponent<GUIManagerScript> ().setTime == 0.0f) {
				GUI.GetComponent<GUIManagerScript> ().triggered = true;
			}
		}
	}

	void randomFunction(){
		num = Random.Range (1, 4);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if(tutorial_Object.magicBook_StartCounting == false)
			{
				tutorial_Object.magicBook_StartCounting = true;
			}
			if (inCd == false) 
			{
				sharestat.RandomNum = num;
				if (sharestat.RandomNum == 1) {
					sharestat.OnFire = true;
					sharestat.OnIce = false;
					sharestat.OnLaser = false;
				} 
				else if (sharestat.RandomNum == 2) {
					sharestat.OnFire = false;
					sharestat.OnIce = true;
					sharestat.OnLaser = false;
				} 
				else if (sharestat.RandomNum == 3) {
					sharestat.OnFire = false;
					sharestat.OnIce = false;
					sharestat.OnLaser = true;
				} 
				else if(sharestat.RandomNum == 0) {
					sharestat.OnFire = false;
					sharestat.OnIce = false;
					sharestat.OnLaser = false;
				}
				this.GetComponentInParent<MagicBookManager> ().Switch ();
				inCd = true;

			}
		}
	}
}
