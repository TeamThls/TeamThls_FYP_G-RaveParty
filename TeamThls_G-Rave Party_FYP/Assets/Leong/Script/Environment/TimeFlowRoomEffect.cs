﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowRoomEffect : MonoBehaviour {

	TimeManagement time_Script;

	[SerializeField] float slowMoEffect_Time;
	[SerializeField] float playerDuration = 5.0f;
	[SerializeField] float enemyDuration = 15.0f;
	[SerializeField] float normalDuration = 25.0f;

	// Use this for initialization
	void Start () 
	{
		if(time_Script == null)
		{
			time_Script = GameObject.Find("TimeManager").GetComponent<TimeManagement>();
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
	}

	void OnTriggerExit2D(Collider2D col)
	{
		time_Script.ResetTime(col.gameObject);
		time_Script.ReducePlayerCount(col.gameObject);
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
				}
				else if(slowMoEffect_Time <= enemyDuration)
				{
					time_Script.ResetTime(time_Script.tempPlayer1);
					time_Script.ResetTime(time_Script.tempPlayer2);
					time_Script.currentSlowState = TimeManagement.CurrentSlowMoState.Enemy;
				}
				else
				{
					time_Script.currentSlowState = TimeManagement.CurrentSlowMoState.Normal;
					time_Script.ResetTime(time_Script.tempPlayer1);
					time_Script.ResetTime(time_Script.tempPlayer2);
					if(slowMoEffect_Time >= normalDuration)
					{
						slowMoEffect_Time = 0.0f;
					}
				}
			}

		}

	}
}
