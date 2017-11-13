using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

	public GameObject gui;
	public Transform upgradeMenu;

	public Transform detail01;
	public Transform detail02;
	public Transform detail03;

	public Transform MagicBook;
	public Transform MagicSkill;
	public Transform Character;

	// Use this for initialization
	void Start () {
		gui = GameObject.Find ("GUI");
		upgradeMenu = gui.transform.GetChild (7);
		MagicBook = upgradeMenu.transform.GetChild (1);
		MagicSkill = upgradeMenu.transform.GetChild (2);
		Character = upgradeMenu.transform.GetChild (3);
		detail01 = upgradeMenu.transform.GetChild (4);
		detail02 = upgradeMenu.transform.GetChild (5);
		detail03 = upgradeMenu.transform.GetChild (6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseOver(){
		
	}
}
