using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour {

	public GameObject player;
	public GameObject player2;
	public PlayerCombat combat_Script;

	Camera mainCam;

	Vector3 camera_CenterPoint;
	Vector3 camera_Destination;

	float camera_ZoomFactor = 1.5f;
	float camera_FollowTimeDelta = 1.5f;
	float camera_Distance;
	[SerializeField] float camera_MinDistance = 10.0f;
	[SerializeField] float camera_MaxDistance = 40.0f;

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
		player = GameObject.Find("Player");
		player2 = GameObject.Find("Player2");
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		/*if(combat_Script.isSlowMo == true)
		{
			if(mainCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount < 8.1f)
			{
				mainCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount += 2.0f * Time.deltaTime;
			}
			else
			{
				mainCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 8.0f;
			}

		}
		else
		{
			if(mainCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount > 0.0f)
			{
				mainCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount -= 3.0f * Time.deltaTime;
			}
		}*/

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
