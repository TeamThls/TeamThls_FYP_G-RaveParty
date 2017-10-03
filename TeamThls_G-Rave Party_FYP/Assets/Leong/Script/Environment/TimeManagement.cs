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


	void Start()
	{
		if(tempPlayer1 == null)
		{
			tempPlayer1 = GameObject.Find("Player").transform.GetChild(1).gameObject;
		}	
		if(tempPlayer2 == null)
		{
			tempPlayer2 = GameObject.Find("Player2").transform.GetChild(1).gameObject;
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
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 0.8f;
				}

				obj_pm.player_SlowMo = true;
				

			}
		}
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
				obj.GetComponent<EnemyMovement>().speed = 2.0f;

			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = 2.0f;
				}
				else if(obj.GetComponent<StrEnemyMovement>() != null)
				{
					obj.GetComponent<StrEnemyMovement>().speed = 1.5f;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = 2.0f;
				}

			}
		}
		// Reset Enemy Movement Speed right after player Count = 0
		if(obj.layer == 8 && player_Count == 0)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = 4.0f;
			}
			else if(obj.GetComponent<EnemyMovement>() == null)
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = 4.0f;
				}
				else if(obj.GetComponent<StrEnemyMovement>() != null)
				{
					obj.GetComponent<StrEnemyMovement>().speed = 3.0f;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = 4.0f;
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
					obj.GetComponentInParent<Rigidbody2D>().gravityScale = 3.0f;
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
		if(obj.layer == 11)
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
		if(obj.layer == 8)
		{
			if(obj.GetComponent<EnemyMovement>() != null)
			{
				obj.GetComponent<EnemyMovement>().speed = 4.0f;
			}
			else
			{
				if(obj.GetComponent<WaypointPathfinding>() != null)
				{
					obj.GetComponent<WaypointPathfinding>().speed = 4.0f;
				}
				else if(obj.GetComponent<StrEnemyMovement>() != null)
				{
					obj.GetComponent<StrEnemyMovement>().speed = 3.0f;
				}
				else if(obj.GetComponent<ShootingEnemy>() != null)
				{
					obj.GetComponent<ShootingEnemy>().speed = 4.0f;
				}
			}
		}	

		
	}

}
