using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour {

	public GameObject player;
	public GameObject player2;
	public Transform gun;
	public PlayerCombat combat_Script;

	Camera cam;

	Vector3 camera_CenterPoint;
	Vector3 camera_Destination;

	float camera_ZoomFactor = 1.5f;
	float camera_FollowTimeDelta = 1.5f;
	float camera_Distance;

	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Camera>();
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

		// Find the Center Point between two desired objects
		camera_CenterPoint = (player.transform.position + player2.transform.position) / 2f;

		// Get the length of both objects' position in Vector2 or Vector3

		camera_Distance = (player.transform.position - player2.transform.position).magnitude;

		camera_Destination = camera_CenterPoint - transform.forward * camera_Distance * camera_ZoomFactor;

		// Using clamp to control the orthographic size of the camera
		cam.orthographicSize = Mathf.Clamp(camera_Distance, 15.0f, 40.0f);

		cam.transform.position = Vector3.Slerp(transform.position, camera_Destination, camera_FollowTimeDelta);

		if((camera_Destination - transform.position).magnitude <= 0.05f)
		{
			transform.position = camera_Destination;
		}
	}
}
