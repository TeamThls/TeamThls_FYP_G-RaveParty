using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ShootEnemy") {
			Debug.Log (other.tag);
			if (other.GetComponent<ShootingEnemy> ().touched == false) {
				other.GetComponent<ShootingEnemy> ().num += 1;
				other.GetComponent<ShootingEnemy> ().touched = true;
				Debug.Log ("detected");
			}
		}
	}*/
}
