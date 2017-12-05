using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour {

	public GameObject tempPlayer1, tempPlayer2;
	public enum CurrentSlowMoState
	{
		Player, Enemy, Normal
	};
	public CurrentSlowMoState currentSlowState = CurrentSlowMoState.Normal;
	public bool timeFlow_ActivationStatus;
	public int player_Count = 0;
	SceneManagement sceneManager;


	void Start()
	{
		sceneManager = Camera.main.GetComponentInParent<SceneManagement>();
		if(tempPlayer1 == null)
		{
			tempPlayer1 = GameObject.Find("Player").transform.GetChild(1).gameObject;
			tempPlayer1.transform.parent.GetChild(10).GetComponent<SpriteRenderer>().enabled = false;
			tempPlayer1.transform.parent.GetChild(11).GetComponent<SpriteRenderer>().enabled = false;
			tempPlayer1.transform.parent.GetChild(12).GetComponent<SpriteRenderer>().enabled = false;
		}	
		if(tempPlayer2 == null)
		{
			if(sceneManager.isSinglePlayer == false)
			{
				tempPlayer2 = GameObject.Find("Player2").transform.GetChild(1).gameObject;
				tempPlayer2.transform.parent.GetChild(10).GetComponent<SpriteRenderer>().enabled = false;
				tempPlayer2.transform.parent.GetChild(11).GetComponent<SpriteRenderer>().enabled = false;
				tempPlayer2.transform.parent.GetChild(12).GetComponent<SpriteRenderer>().enabled = false;
			}
			else
			{
				tempPlayer2 = null;
			}
		}
	}

	void TimeFlowIndicator(GameObject player)
	{
		SpriteRenderer obj_PositiveTimeSpr = player.transform.parent.GetChild(10).GetComponent<SpriteRenderer>();
		SpriteRenderer obj_NegativeTimeSpr = player.transform.parent.GetChild(11).GetComponent<SpriteRenderer>();
		SpriteRenderer obj_NormalTimeSpr = player.transform.parent.GetChild(12).GetComponent<SpriteRenderer>();
		switch(currentSlowState)
		{
			case CurrentSlowMoState.Player:
				if(obj_NegativeTimeSpr.enabled == false)
				{
					obj_PositiveTimeSpr.enabled = false;
					obj_NegativeTimeSpr.enabled = true;
					obj_NormalTimeSpr.enabled = false;
					Debug.Log("Negative");
				}
				break;

			case CurrentSlowMoState.Enemy:
				if(obj_PositiveTimeSpr.enabled == false)
				{
					obj_PositiveTimeSpr.enabled = true;
					obj_NegativeTimeSpr.enabled = false;
					obj_NormalTimeSpr.enabled = false;
					Debug.Log("Positive");
				}
				break;

			case CurrentSlowMoState.Normal:
				if(obj_NormalTimeSpr.enabled == false)
				{
					obj_PositiveTimeSpr.enabled = false;
					obj_NegativeTimeSpr.enabled = false;
					obj_NormalTimeSpr.enabled = true;
					Debug.Log("Normal");
				}
				break;
		}
	}

	public void SlowDown(GameObject obj)
	{
		if(obj.layer == 10)
		{
			timeFlow_ActivationStatus = true;

			PlayerMovement obj_pm = obj.GetComponentInParent<PlayerMovement>();
			PlayerCombat obj_pc = obj.GetComponentInParent<PlayerCombat>();

			if(obj_pm.player_SlowMo == false)
			{
				obj_pm.player_TimeFactor = 0.5f;

				if(obj_pc.isShootingIce == true)
				{
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 0.0f;
				}
				else
				{
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 1.5f;
				}

				obj_pm.player_SlowMo = true;

			}
			TimeFlowIndicator(obj);

		}
		/*if(obj.layer == 10 && currentSlowState == CurrentSlowMoState.Enemy)
		{
			SpriteRenderer obj_PositiveTimeSpr = obj.transform.parent.GetChild(10).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NegativeTimeSpr = obj.transform.parent.GetChild(11).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NormalTimeSpr = obj.transform.parent.GetChild(12).GetComponent<SpriteRenderer>();
			if(obj_PositiveTimeSpr.enabled == false)
			{
				obj_PositiveTimeSpr.enabled = true;
				obj_NegativeTimeSpr.enabled = false;
				obj_NormalTimeSpr.enabled = false;
				Debug.Log("Positive");
			}
		}
		if(obj.layer == 10 && currentSlowState == CurrentSlowMoState.Normal)
		{
			SpriteRenderer obj_PositiveTimeSpr = obj.transform.parent.GetChild(10).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NegativeTimeSpr = obj.transform.parent.GetChild(11).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NormalTimeSpr = obj.transform.parent.GetChild(12).GetComponent<SpriteRenderer>();
			if(obj_NormalTimeSpr.enabled == false)
			{
				obj_PositiveTimeSpr.enabled = false;
				obj_NegativeTimeSpr.enabled = false;
				obj_NormalTimeSpr.enabled = true;
				Debug.Log("Normal");
			}
		}*/
		if(obj.layer == 11 && currentSlowState == CurrentSlowMoState.Player && timeFlow_ActivationStatus == true && player_Count > 0)
		{
			if(obj.tag == "NormalBullet")
			{
				obj.GetComponent<Bullet>().bullet_TimeFactor = 0.5f;
			}
			if(obj.tag == "IceBullet")
			{
				obj.GetComponent<IceBullet>().iceBullet_TimeFactor = 0.5f;
			}
		}
		if(obj.layer == 8 && currentSlowState == CurrentSlowMoState.Enemy && timeFlow_ActivationStatus == true && player_Count > 0)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = obj.GetComponent<EnemyMovement>().maxSpeed / 2.0f;

			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = obj.GetComponent<WaypointPathfinding>().maxSpeed / 2.0f;
				}
				else if(obj.GetComponent<StrengthEnemyMovement>() != null)
				{
					obj.GetComponent<StrengthEnemyMovement>().speed = obj.GetComponent<StrengthEnemyMovement>().maxSpeed / 2.0f;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = obj.GetComponent<ShootingEnemy>().maxSpeed / 2.0f;
				}

			}
		}
		// Reset Enemy Movement Speed right after player Count = 0
		if(obj.layer == 8 && player_Count == 0)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = obj.GetComponent<EnemyMovement>().maxSpeed;

			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = obj.GetComponent<WaypointPathfinding>().maxSpeed;
				}
				else if(obj.GetComponent<StrengthEnemyMovement>() != null)
				{
					obj.GetComponent<StrengthEnemyMovement>().speed = obj.GetComponent<StrengthEnemyMovement>().maxSpeed;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = obj.GetComponent<ShootingEnemy>().maxSpeed;
				}

			}
		}
	}

	public void PlusPlayerCount(GameObject obj)
	{
		if(obj.layer == 10)
		{
			player_Count ++;
		}
	}

	public void ReducePlayerCount(GameObject obj)
	{		
		if(obj.layer == 10)
		{
			player_Count --;
			SpriteRenderer obj_PositiveTimeSpr = obj.transform.parent.GetChild(10).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NegativeTimeSpr = obj.transform.parent.GetChild(11).GetComponent<SpriteRenderer>();
			SpriteRenderer obj_NormalTimeSpr = obj.transform.parent.GetChild(12).GetComponent<SpriteRenderer>();

			obj_PositiveTimeSpr.enabled = false;
			obj_NegativeTimeSpr.enabled = false;
			obj_NormalTimeSpr.enabled = false;
			
		}
	}

	// Reset every affected variables once the TimeFlow switch mode
	public void ResetTime(GameObject obj)
	{
		if(obj.layer == 10)
		{
			// Reset back the time once the enum changed
			PlayerMovement obj_pm = obj.GetComponentInParent<PlayerMovement>();
			PlayerCombat obj_pc = obj.GetComponentInParent<PlayerCombat>();

			if(obj_pm.player_SlowMo == true)
			{
				if(obj_pc.isShootingIce == false)
				{
					obj_pm.player_TimeFactor = 1.0f;
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 6.0f;
					obj_pm.player_SlowMo = false;	
				}
				else
				{
					obj_pm.player_TimeFactor = 1.0f;
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 0.0f;
					obj_pm.player_SlowMo = false;	
				}
			}
		}

		if(obj.layer == 11 && currentSlowState != CurrentSlowMoState.Player)
		{
			if(obj.tag == "NormalBullet")
			{
				obj.GetComponent<Bullet>().bullet_TimeFactor = 1.0f;
			}
			if(obj.tag == "IceBullet")
			{
				obj.GetComponent<IceBullet>().iceBullet_TimeFactor = 1.0f;
			}
		}
		if(obj.layer == 8 && currentSlowState != CurrentSlowMoState.Enemy)
		{
			StartCoroutine(DelayRecover(1.0f));
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = obj.GetComponent<EnemyMovement>().maxSpeed;
			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = obj.GetComponent<WaypointPathfinding>().maxSpeed;
				}
				else if(obj.GetComponent<StrengthEnemyMovement>() != null)
				{
					obj.GetComponent<StrengthEnemyMovement>().speed = obj.GetComponent<StrengthEnemyMovement>().maxSpeed;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = obj.GetComponent<ShootingEnemy>().maxSpeed;
				}
			}
		}	
	}

	IEnumerator DelayRecover(float duration)
	{
		yield return new WaitForSeconds(duration);
	}

}
