using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

	public Transform magicBook, healthStation, cameraTransform;
	[SerializeField] RectTransform magicBookArrow_UITransform, healthStation_UITransform;
	[SerializeField] ActiveMagic magic_Script;
	[SerializeField] HealthDeviceHealing health_Script;
	[SerializeField] Image magicSpr, healthSpr;
	//[SerializeField] ParticleSystem health_Particles, magic_Particles;
	Animator health_Anim, magic_Anim;

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
		magic_Script = magicBook.GetComponent<ActiveMagic>();
		health_Script = GameObject.Find ("P_HealDeviceStand").GetComponent<HealthDeviceHealing>();
		magicSpr = transform.GetChild(0).GetComponent<Image>();
		magic_Anim = transform.GetChild(0).GetComponent<Animator>();
		healthSpr = transform.GetChild(1).GetComponent<Image>();
		health_Anim = transform.GetChild(1).GetComponent<Animator>();
	}

	void Update () 
	{
		if(magic_Script.inCd == false)
		{
			EnableCompass(magicBookArrow_UITransform, magic_Anim);
			RotateCompass(magicBook, magicBookArrow_UITransform);
			//magic_Particles.Play();
		}
		else
		{
			HideCompass(magicBookArrow_UITransform, magic_Anim);
		}
		if(health_Script.availableHealth == health_Script.health_Requirement)
		{
			EnableCompass(healthStation_UITransform, health_Anim);
			RotateCompass(healthStation, healthStation_UITransform);
			//health_Particles.Play();
		}
		else
		{
			HideCompass(healthStation_UITransform, health_Anim);
		}
	}

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

		}
		else if(Obj.position.y > cameraTransform.position.y)
		{
			UIImage.rotation = Quaternion.Euler(0, 0, 180);
		}
		else if(Obj.position.y < cameraTransform.position.y)
		{
			UIImage.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	void HideCompass (RectTransform UIImage, Animator anim)
	{
		anim.Play("Fade");

		UIImage.GetComponent<Image>().enabled = false;

	}

	void EnableCompass (RectTransform UIImage, Animator anim)
	{
		anim.Play("Glow");
		UIImage.GetComponent<Image>().enabled = true;

	}

}
