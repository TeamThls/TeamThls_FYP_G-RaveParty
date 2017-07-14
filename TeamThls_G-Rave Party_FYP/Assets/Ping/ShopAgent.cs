using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAgent : MonoBehaviour {

	public GameObject player;
	public Transform Shop;
	public float setTime;
	public float setTime2;
	public float duration;
	public bool inCD = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Shop.gameObject.activeInHierarchy == true) {
			Time.timeScale = 0.0f;
			setTime ++;
		}
		if (Shop.gameObject.activeInHierarchy == false) {
			Time.timeScale = 1.0f;
		}

		if (setTime >= duration) {
			Shop.gameObject.SetActive (false);
			inCD = true;
			setTime = 0.0f;
		}
		if (inCD == true) {
			setTime2 += Time.deltaTime;
			if (setTime2 >= 15.0f) {
				inCD = false;
				setTime2 = 0.0f;
			}
		}
	}

	void OnTriggerStay2D(Collider2D player){
		if (Shop.gameObject.activeInHierarchy == false && inCD == false) {
			Shop.gameObject.SetActive(true);
		}
	}
}
