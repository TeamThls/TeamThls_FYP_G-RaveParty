using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCostScript : MonoBehaviour {

	public GameObject Player;
	SharedStats shrStat;
	Slider slider;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		slider = GetComponent<Slider> ();
		shrStat = Player.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = shrStat.player_Mana;
	}
}
