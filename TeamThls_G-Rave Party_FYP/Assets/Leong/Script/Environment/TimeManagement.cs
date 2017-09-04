using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour {

	public float time_SlowDownFactor = 0.5f;

	void Update()
	{
		//Time.timeScale += (1.0f / time_SlowDownFactor) * Time.unscaledDeltaTime;
		//Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
	}

	public void SlowMotion()
	{	
		Time.timeScale = time_SlowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	// Instead of hard-coding every objects, put one more variable into every motions, multiply it with half of the value
	// Take this in mind, once animation comes in, all these works probably need to redo
	public void SlowDown(GameObject obj)
	{
		if(obj.layer == 10)
		{
			obj.GetComponentInParent<PlayerMovement>().player_TimeFactor = 0.5f;
			obj.GetComponentInParent<Rigidbody2D>().gravityScale = 0.8f;
		}
		if(obj.layer == 11)
		{
			obj.GetComponent<Bullet>().bullet_TimeFactor = 0.5f;
		}
		if(obj.layer == 8)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = 2.0f;

			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				obj.GetComponent<WaypointPathfinding>().speed = 2.0f;
			}
		}	
	}

	public void ResetTime(GameObject obj)
	{
		if(obj.layer == 10)
		{
			obj.GetComponentInParent<PlayerMovement>().player_TimeFactor = 1.0f;
			obj.GetComponentInParent<Rigidbody2D>().gravityScale = 3.0f;
		
		}
		if(obj.layer == 11)
		{
			obj.GetComponent<Bullet>().bullet_TimeFactor = 1.0f;
		}
		if(obj.layer == 8)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = 4.0f;
			}
			else
			{
				obj.GetComponent<WaypointPathfinding>().speed = 4.0f;
			}
		}	

		
	}

}
