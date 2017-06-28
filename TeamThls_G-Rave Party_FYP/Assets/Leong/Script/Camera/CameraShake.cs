using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	Camera mainCam;

	float shakeAmount = 0;

	void Awake()
	{
		if (mainCam == null)
		{
			mainCam = Camera.main;
		}
	}

	void Update()
	{
		
	}

	public void Shake(float amount, float length)
	{
		shakeAmount = amount;
		InvokeRepeating ("BeginShake", 0, 0.01f);
		Invoke ("StopShake", length);
	}

	// The randomizing method can also applied with the Perlin Noise method
	void BeginShake()
	{
		if (shakeAmount > 0)
		{
			Vector3 camPos = mainCam.transform.position;

			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			camPos.x = offsetX;
			camPos.y = offsetY;
			camPos.z = 0f;
			mainCam.transform.localPosition = camPos;

		}
	}

	void StopShake()
	{
		CancelInvoke ("BeginShake");
		mainCam.transform.localPosition = Vector3.zero;
	}
}
