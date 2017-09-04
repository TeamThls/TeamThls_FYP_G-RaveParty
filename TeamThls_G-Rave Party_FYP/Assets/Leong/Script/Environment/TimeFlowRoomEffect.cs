using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowRoomEffect : MonoBehaviour {

	TimeManagement time_Script;
	// Use this for initialization
	void Start () 
	{
		if(time_Script == null)
		{
			time_Script = GameObject.Find("TimeManager").GetComponent<TimeManagement>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		/*if(col.gameObject.layer == 10)
		{
			time_Script.SlowDown();
			Debug.Log("123456");
		}*/
	}

	void OnTriggerStay2D(Collider2D col)
	{
		time_Script.SlowDown(col.gameObject);
	}

	void OnTriggerExit2D(Collider2D col)
	{
		time_Script.ResetTime(col.gameObject);		
	}
}
