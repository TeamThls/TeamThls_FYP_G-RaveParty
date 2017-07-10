using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCostScript : MonoBehaviour {

	public GameObject GameManager;
	SharedStats shrStat;
	Slider slider;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		slider = GetComponent<Slider> ();
		shrStat = GameManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = shrStat.player_Mana;
	}
}
