using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

	public LineRenderer line_Ren;
	bool line_Ren_Decrease;

	float speed = 100.0f;
	float time;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		line_Ren.SetPosition(0, new Vector3(1, 0, 0 ));
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
}
