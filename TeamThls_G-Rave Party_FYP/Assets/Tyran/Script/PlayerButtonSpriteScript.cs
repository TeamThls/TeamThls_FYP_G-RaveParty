using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonSpriteScript : MonoBehaviour {

	SpriteRenderer spr_Ren;
	// Use this for initialization
	void Start () {
		spr_Ren = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		CheckDisplayButton()	;
	}

	void CheckDisplayButton()
	{
		if(spr_Ren.flipX == true)
		{
			transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
			transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		}
		else
		{
			transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);

		}
	}
}
