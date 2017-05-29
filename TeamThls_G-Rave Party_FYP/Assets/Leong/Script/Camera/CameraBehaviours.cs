using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour {

	public GameObject player;
	public Transform gun;
	public Combat combat_Script;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(combat_Script.isSlowMo)
		{
			if(GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount < 8.1f)
			{
				GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount += 2.0f * Time.deltaTime;
			}
			else
			{
				GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 8.0f;
			}

		}
		else
		{
			if(GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount > 0.0f)
			{
				GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount -= 3.0f * Time.deltaTime;
			}
		}


	}
}
