using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomEffect : MonoBehaviour {

	[SerializeField] GameObject level_Obj;

	public List<SpriteRenderer> darkRoom_Obj;
	public List<Light> darkRoom_Light;
	public Material darkRoom_Mat;
	public float currentColor_increaseValue;
	public float currentLight_Range;
	public int player_Count;

	public enum darkRoom_State
	{
		Activated, Deactivated, Null
	};
	public darkRoom_State darkRoom_CurrentState = darkRoom_State.Null;
	// Use this for initialization
	void Start () 
	{
		darkRoom_Mat.color = Color.white;
		//ListingAllDarkRoomObjects();
		FindAffectedLights();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(darkRoom_CurrentState == darkRoom_State.Activated && currentColor_increaseValue <= 1.0f)
		{
			currentColor_increaseValue += 0.001f;
			currentLight_Range += 0.001f;
			DarkenMaterialColor(currentColor_increaseValue);
			DarkenLights(currentLight_Range);
		}
		else if(darkRoom_CurrentState == darkRoom_State.Deactivated && currentColor_increaseValue >= 0.0f)
		{
			currentColor_increaseValue -= 0.001f;
			currentLight_Range -= 0.001f;
			ResetMaterialColor(currentColor_increaseValue);
			DarkenLights(currentLight_Range);
		}
		if(darkRoom_Mat.color == Color.white)
		{
			darkRoom_CurrentState = darkRoom_State.Null;
			currentColor_increaseValue = 0.0f;
		}
	}

	void DarkenMaterialColor(float value)
	{
		if(darkRoom_Mat.color != Color.black)
		{
			darkRoom_Mat.color = Color.Lerp(Color.white, Color.black, value);
		}
	}

	void ResetMaterialColor(float value)
	{
		if(darkRoom_Mat.color != Color.white)
		{
			darkRoom_Mat.color = Color.Lerp(Color.white, Color.black, value);
		}
	}

	void FindAffectedLights()
	{
		Transform light = GameObject.Find(this.transform.parent.name + " Light").GetComponent<Transform>();
		foreach (Transform child in light)
		{
			darkRoom_Light.Add(child.GetComponent<Light>());
		}
	}

	void DarkenLights(float value)
	{
		for(int i = 0; i < darkRoom_Light.Count; i++)
		{
			darkRoom_Light[i].range = Mathf.Lerp(40.0f, 0.0f, value);
		}
	}

	void ResetLights(float value)
	{
		if(darkRoom_Light != null)
		{
			for(int i = 0; i < darkRoom_Light.Count; i++)
			{
				darkRoom_Light[i].range = Mathf.Lerp(40.0f, 0.0f, value);

			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			darkRoom_CurrentState = darkRoom_State.Activated;
		}
		if(col.gameObject.layer == 8)
		{
			//col.GetComponent<SpriteRenderer>().color = darkRoom_Mat.color;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.layer == 10 && darkRoom_CurrentState == darkRoom_State.Deactivated)
		{
			darkRoom_CurrentState = darkRoom_State.Activated;
		}
		if(col.gameObject.layer == 8)
		{
			col.GetComponent<Renderer>().material = darkRoom_Mat;
			//Debug.Log(col.GetComponent<SpriteRenderer>().color);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			darkRoom_CurrentState = darkRoom_State.Deactivated;
		}
		if(col.gameObject.layer == 8)
		{
			//col.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

}
