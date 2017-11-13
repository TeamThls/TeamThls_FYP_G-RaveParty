using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowRoomEffect : MonoBehaviour {

	TimeManagement time_Script;

	[SerializeField] float slowMoEffect_Time;
	[SerializeField] float playerDuration = 5.0f;
	[SerializeField] float enemyDuration = 15.0f;
	[SerializeField] float normalDuration = 25.0f;

	Camera cam;

	// Use this for initialization
	void Start () 
	{
		if(time_Script == null)
		{
			time_Script = GameObject.Find("TimeManager").GetComponent<TimeManagement>();
		}
		if(cam == null)
		{
			cam = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		SlowMoCountdown();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		time_Script.PlusPlayerCount(col.gameObject);
	}

	void OnTriggerStay2D(Collider2D col)
	{
		time_Script.SlowDown(col.gameObject);
		if(col.gameObject.layer != 10)
		{
			time_Script.ResetTime(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		time_Script.ResetTime(col.gameObject);
		time_Script.ReducePlayerCount(col.gameObject);
		cam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = false;
	}

	void SlowMoCountdown()
	{
		if(time_Script.timeFlow_ActivationStatus == true)
		{
			if(time_Script.player_Count > 0)
			{
				slowMoEffect_Time += Time.deltaTime;
				if(slowMoEffect_Time <= playerDuration)
				{
					time_Script.currentSlowState = TimeManagement.CurrentSlowMoState.Player;
					cam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = true;
				}
				else if(slowMoEffect_Time <= enemyDuration)
				{
					time_Script.ResetTime(time_Script.tempPlayer1);
					if(time_Script.tempPlayer2 != null)
					{
						time_Script.ResetTime(time_Script.tempPlayer2);
					}
					time_Script.currentSlowState = TimeManagement.CurrentSlowMoState.Enemy;
					cam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = false;
				}
				else
				{
					time_Script.currentSlowState = TimeManagement.CurrentSlowMoState.Normal;
					time_Script.ResetTime(time_Script.tempPlayer1);
					if(time_Script.tempPlayer2 != null)
					{
						time_Script.ResetTime(time_Script.tempPlayer2);
					}
					cam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = false;
					if(slowMoEffect_Time >= normalDuration)
					{
						slowMoEffect_Time = 0.0f;
					}
				}
			}

		}

	}
}
