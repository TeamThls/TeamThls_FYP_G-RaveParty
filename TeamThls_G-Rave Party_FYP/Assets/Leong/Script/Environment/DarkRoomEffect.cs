using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomEffect : MonoBehaviour {

	[SerializeField] GameObject level_Obj;
	[SerializeField] GameObject level_Vegetation;
	[SerializeField] GameObject level_Props;
	public List<SpriteRenderer> darkRoom_Obj;
	public Material darkRoom_Mat;
	public float currentColor_increaseValue;
	public enum darkRoom_State
	{
		Activated, Deactivated, Null
	};
	public darkRoom_State darkRoom_CurrentState = darkRoom_State.Null;
	// Use this for initialization
	void Start () {
		darkRoom_Mat.color = Color.white;
		//ListingAllDarkRoomObjects();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(darkRoom_CurrentState == darkRoom_State.Activated && currentColor_increaseValue <= 1.0f)
		{
			currentColor_increaseValue += 0.001f;
			DarkenMaterialColor(currentColor_increaseValue);
		}
		else if(darkRoom_CurrentState == darkRoom_State.Deactivated && currentColor_increaseValue >= 0.0f)
		{
			currentColor_increaseValue -= 0.001f;
			ResetMaterialColor(currentColor_increaseValue);
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

	void ListingAllDarkRoomObjects()
	{
		if(level_Obj == null)
		{
			level_Obj = GameObject.Find("Level 9");
		}
		if(level_Vegetation == null)
		{
			level_Vegetation = level_Obj.transform.Find("Vegetation").gameObject;
		}
		if(level_Props == null)
		{
			level_Props = level_Obj.transform.Find("Props").gameObject;
		}
		for(int i = 0; i < level_Obj.transform.childCount; i++)
		{
			if(level_Obj.transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
			{
				darkRoom_Obj.Add(level_Obj.transform.GetChild(i).GetComponent<SpriteRenderer>());
			}
		}
		for(int j = 0; j < level_Vegetation.transform.childCount; j++)
		{
			if(level_Vegetation.transform.GetChild(j).GetComponent<SpriteRenderer>() != null)
			{
				darkRoom_Obj.Add(level_Vegetation.transform.GetChild(j).GetComponent<SpriteRenderer>());
			}
		}
		for(int k = 0; k < level_Props.transform.childCount; k++)
		{
			if(level_Props.transform.GetChild(k).GetComponent<SpriteRenderer>() != null)
			{
				darkRoom_Obj.Add(level_Props.transform.GetChild(k).GetComponent<SpriteRenderer>());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			darkRoom_CurrentState = darkRoom_State.Activated;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.layer == 10 && darkRoom_CurrentState == darkRoom_State.Deactivated)
		{
			darkRoom_CurrentState = darkRoom_State.Activated;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			darkRoom_CurrentState = darkRoom_State.Deactivated;
		}
	}
}
