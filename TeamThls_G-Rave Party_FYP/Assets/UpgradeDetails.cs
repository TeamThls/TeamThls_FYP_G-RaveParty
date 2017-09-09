using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDetails : MonoBehaviour {

	public Text playerInfo;
	SharedStats shrd;
	GameObject GameManager;

	public int wordSize;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		shrd = GameManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerInfo.fontSize = wordSize;
		playerInfo.text = "Player Info" + 
			"\nPlayer Health : " + shrd.player_Health + "/" + shrd.player_MaxHealth +
			"\nPlayer MP : " + shrd.player_Mana + "/" + shrd.player_MaxMana +
			"\n\nAbility detail" +
			"\nFire Damage : " + shrd.Fire_Damage +
			"\nFire Mana : " + shrd.FireMana +
			"\nIce Damage : " + shrd.Ice_Damage +
			"\nIce Mana : " + shrd.IceMana +
			"\nLaser Damage : " + shrd.Laser_Damage +
			"\nLaser Mana : " + shrd.LaserMana;
	}
}
