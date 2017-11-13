using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour {

	public GameObject player;
	public GameObject player2;
	public PlayerCombat combat_Script;

	Transform healthUI_Obj;

	Camera mainCam;

	Vector3 camera_CenterPoint;
	Vector3 camera_Destination;

	float camera_ZoomFactor = 1.5f;
	float camera_FollowTimeDelta = 1.5f;
	float camera_Distance;
	[SerializeField] float camera_MinDistance = 10.0f;
	[SerializeField] float camera_MaxDistance = 40.0f;
	[SerializeField] SceneManagement sceneManager;

	// Use this for initialization
	void Awake () 
	{
		if (mainCam == null)
		{
			mainCam = Camera.main;
		}

	}

	void Start ()
	{
		sceneManager = mainCam.GetComponentInParent<SceneManagement>();

		if(player == null)
		{
			player = GameObject.Find("Player");
		}
		if(player2 == null)
		{
			if(sceneManager.isSinglePlayer == true)
			{
				player2 = null;
			}
			else
			{
				player2 = GameObject.Find("Player2");
			}
		}

		healthUI_Obj = transform.GetChild(1).transform;
	}

	void FixedUpdate () 
	{
		if(sceneManager.isSinglePlayer == false)
		{
			MultiplayerCamera();
		}
		else
		{
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -7.69f);
		}
	}

	/*void SingleplayerCamera()
	{
		mainCam.
	}*/

	void MultiplayerCamera()
	{
		Vector3 camera_MinScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		// Max Screen Limit Vector3, take from camera screen width and height (Right Side)
		Vector3 camera_MaxScreenLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		healthUI_Obj.position = new Vector3(Mathf.Clamp(healthUI_Obj.position.x, camera_MinScreenLimit.x + 1, camera_MaxScreenLimit.x - 1)
			,Mathf.Clamp(healthUI_Obj.position.y, camera_MaxScreenLimit.y - 1, camera_MaxScreenLimit.y - 1), healthUI_Obj.position.z);



		// Find the Center Point between two desired objects
		camera_CenterPoint = (player.transform.position + player2.transform.position) / 2f;

		// Get the length of both objects' position in Vector2 or Vector3

		camera_Distance = (player.transform.position - player2.transform.position).magnitude;

		camera_Destination = camera_CenterPoint - transform.forward * camera_Distance * camera_ZoomFactor;

		// Using clamp to control the orthographic size of the camera
		mainCam.orthographicSize = Mathf.Clamp(camera_Distance, camera_MinDistance, camera_MaxDistance);

		// The First Line is for the Main Camera Object Position, the Second Line is for the Empty Object (Camera Parent) Position
		//mainCam.transform.position = Vector3.Slerp(transform.position, camera_Destination, camera_FollowTimeDelta);

		transform.position = Vector3.Slerp(transform.position, camera_Destination, camera_FollowTimeDelta);

		if((camera_Destination - transform.position).magnitude <= 0.05f)
		{
			transform.position = camera_Destination;
		}
	}
}

