using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomEffect : MonoBehaviour {

	[SerializeField] GameObject level_Obj;

	public List<SpriteRenderer> darkRoom_Obj;
	public List<Light> darkRoom_Light;
	public Material darkRoom_Mat;
	public Material darkRoom_AltMat;
	public float currentColor_increaseValue;
	public float currentLight_Range;
	public int player_Count;

	[SerializeField] float timeToActivate;
	[SerializeField] bool isTutorialRoom;
	[SerializeField] SharedStats sharedStats_Script;
	[SerializeField] float damage_CurrentTime;
	int darkness_Damage = 2;
	float damage_MaxTime = 2.0f;
	ScreenFlashingRedEffect redFlash_Script;

	public enum darkRoom_State
	{
		Activated, Deactivated, Null
	};
	public darkRoom_State darkRoom_CurrentState = darkRoom_State.Null;

	void Awake()
	{
		sharedStats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
		redFlash_Script = GameObject.Find("GUI").GetComponent<ScreenFlashingRedEffect>();
	}

	// Use this for initialization
	void Start () 
	{
		darkRoom_Mat.color = Color.white;
		darkRoom_AltMat.color = Color.white;
		//ListingAllDarkRoomObjects();
		//FindAffectedLights();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isTutorialRoom == true)
		{
			timeToActivate += Time.deltaTime;
			if(timeToActivate > 10.0f)
			{
				isTutorialRoom = false;
				timeToActivate = 0.0f;
			}
		}
		else
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
			if(darkRoom_AltMat.color == Color.white)
			{
				darkRoom_CurrentState = darkRoom_State.Null;
				currentColor_increaseValue = 0.0f;

			}
			DarknessDamage();
			ColorSmoothing();
		}

	}

	void ColorSmoothing()
	{
		darkRoom_Mat.color = new Color(darkRoom_AltMat.color.r + 0.1f, darkRoom_AltMat.color.g + 0.1f, darkRoom_AltMat.color.b + 0.1f);
	}

	void DarkenMaterialColor(float value)
	{
		if(darkRoom_AltMat.color != Color.black)
		{
			darkRoom_AltMat.color = Color.Lerp(Color.white, Color.black, value);
		}

	}

	void ResetMaterialColor(float value)
	{
		if(darkRoom_AltMat.color != Color.white)
		{
			darkRoom_AltMat.color = Color.Lerp(Color.white, Color.black, value);
		}
	}

	void DarknessDamage()
	{
		if(darkRoom_AltMat.color == Color.black)
		{
			damage_CurrentTime += Time.deltaTime;
			if(damage_CurrentTime >= damage_MaxTime)
			{
				damage_CurrentTime = 0.0f;
				sharedStats_Script.player_Health -= darkness_Damage;
				StartCoroutine(redFlash_Script.ScreenFlash(0.1f));
				//redFlash_Script.ScreenRed();
			}
		}
		else
		{
			damage_CurrentTime = 0.0f;
		}
	}

	/*void FindAffectedLights()
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
	}*/

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
		if(col.gameObject.layer == 8)
		{
			col.GetComponent<Renderer>().material = darkRoom_Mat;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			darkRoom_CurrentState = darkRoom_State.Deactivated;
			damage_CurrentTime = 0.0f;
		}
	}

}
