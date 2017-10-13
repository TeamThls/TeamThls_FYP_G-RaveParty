using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

	public Transform magicBook, healthStation, cameraTransform;
	[SerializeField] RectTransform magicBookArrow_UITransform, healthStation_UITransform;


	void Start () 
	{
		cameraTransform = Camera.main.GetComponent<Transform>();
		if(magicBook == null)
		{
			magicBook = GameObject.Find ("MagicSkill").GetComponent<Transform>();
		}
		if(healthStation == null)
		{
			healthStation = GameObject.Find ("P_HealDevice").GetComponent<Transform>();
		}
		if(magicBookArrow_UITransform == null)
		{
			magicBookArrow_UITransform = GameObject.Find ("MagicArrow").GetComponent<RectTransform>();
		}
		if(healthStation_UITransform == null)
		{
			healthStation_UITransform = GameObject.Find ("HealthArrow").GetComponent<RectTransform>();
		}
	}

	void FixedUpdate () 
	{
		RotateCompass(magicBook, magicBookArrow_UITransform);
		RotateCompass(healthStation, healthStation_UITransform);
	}
	//
	void RotateCompass(Transform Obj, RectTransform UIImage)
	{
		if(Obj.position.x < cameraTransform.position.x)
		{
			if(Obj.position.x < cameraTransform.position.x && Obj.position.y > cameraTransform.position.y + 3.0f)
			{
				UIImage.rotation = Quaternion.Euler(0, 0, 225);
			}
			else if(Obj.position.x < cameraTransform.position.x && Obj.position.y < cameraTransform.position.y - 3.0f)
			{
				
				UIImage.rotation = Quaternion.Euler(0, 0, 315);
			}
			else
			{
				UIImage.rotation = Quaternion.Euler(0, 0, 270);
			}
			Debug.Log("Left");	
		}
		else if(Obj.position.x > cameraTransform.position.x)
		{
			if(Obj.position.x > cameraTransform.position.x && Obj.position.y < cameraTransform.position.y - 3.0f)
			{
				UIImage.rotation = Quaternion.Euler(0, 0, 45);
			}
			else if(Obj.position.x > cameraTransform.position.x && Obj.position.y > cameraTransform.position.y + 3.0f)
			{
				UIImage.rotation = Quaternion.Euler(0, 0, 135);
			}
			else
			{
				UIImage.rotation = Quaternion.Euler(0, 0, 90);
			}
			Debug.Log("Right");	
		}
		else if(Obj.position.y > cameraTransform.position.y)
		{
			
			UIImage.rotation = Quaternion.Euler(0, 0, 180);
			Debug.Log("Up");	
		}
		else if(Obj.position.y < cameraTransform.position.y)
		{
			UIImage.rotation = Quaternion.Euler(0, 0, 0);
			Debug.Log("Down");	
		}
	}


}
