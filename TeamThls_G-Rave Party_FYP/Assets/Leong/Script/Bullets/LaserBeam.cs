using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

	public LineRenderer line_Ren;
	bool line_Ren_Decrease;

	float speed = 100.0f;
	float time;

	public enum Laser_SpawnDirection
	{
		Up, Down, Left, Right
	}

	public Laser_SpawnDirection laser_Direction;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		LaserDirection();
		line_Ren.SetPosition(0, new Vector3(1, 0, 0));
		line_Ren.SetPosition(1, new Vector3(30, 0, 0));

		if(line_Ren_Decrease == false)
		{
			line_Ren.widthMultiplier += 50.0f;
			if(line_Ren.widthMultiplier >= 50.0)
			{
				line_Ren_Decrease = true;
			}
		}
		else
		{
			line_Ren.widthMultiplier -= speed * Time.deltaTime;
			if(line_Ren.widthMultiplier < 0.0)
			{
				this.gameObject.SetActive(false);
			}
		}
	}

	void LaserDirection ()
	{
		if(laser_Direction == Laser_SpawnDirection.Right)
		{
			
		}
		else if(laser_Direction == Laser_SpawnDirection.Left)
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
		}
		else if(laser_Direction == Laser_SpawnDirection.Up)
		{
			
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
		}
	}
}
