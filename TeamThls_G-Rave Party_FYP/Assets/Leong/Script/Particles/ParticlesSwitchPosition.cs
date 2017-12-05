using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSwitchPosition : MonoBehaviour {

	public enum Object
	{
		Player, Enemy
	};

	enum ParticleType
	{
		Wand, Ground, Sync
	};
	public Object current_Obj;
	[SerializeField] ParticleType par_Type;
	SpriteRenderer obj_Spr;
	// Use this for initialization
	void Start () {
		if(current_Obj == Object.Player)
		{
			obj_Spr = transform.parent.GetChild (1).GetComponent<SpriteRenderer>();
		}
		else if(current_Obj == Object.Enemy)
		{
			obj_Spr = transform.parent.GetComponent<SpriteRenderer>();
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(current_Obj == Object.Player)
		{
			if(obj_Spr.flipX == true)
			{
				if(par_Type == ParticleType.Wand)
				{
					transform.localPosition = new Vector2(-0.62f, transform.localPosition.y);
				}
				else if(par_Type == ParticleType.Ground)
				{
					transform.localPosition = new Vector3(0.65f, transform.localPosition.y, -1.0f);
						
				}
				else if(par_Type == ParticleType.Sync)
				{
					transform.localPosition = new Vector3(0.15f, transform.localPosition.y, -1.0f);
						
				}
			}
			else
			{
				if(par_Type == ParticleType.Wand)
				{
					transform.localPosition = new Vector2(0.62f, transform.localPosition.y);
				}
				else if(par_Type == ParticleType.Ground)
				{
					transform.localPosition = new Vector3(-0.65f, transform.localPosition.y, -1.0f);
						
				}
				else if(par_Type == ParticleType.Sync)
				{
					transform.localPosition = new Vector3(-0.125f, transform.localPosition.y, -1.0f);
						
				}
			}
		}
		else
		{
			// 43.34f flipX, 133.34f !flipX
			if(obj_Spr.flipX == true)
			{
				transform.localPosition = new Vector2(-1.08f, transform.localPosition.y);
				transform.rotation = Quaternion.Euler(43.34f, 100, 0);
			}
			else
			{
				transform.localPosition = new Vector2(1.1f, transform.localPosition.y);
				transform.rotation = Quaternion.Euler(133.34f, 100, 0);

			}
		}
	}
}
