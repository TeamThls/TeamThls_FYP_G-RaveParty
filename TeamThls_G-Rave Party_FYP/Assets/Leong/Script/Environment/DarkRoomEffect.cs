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
	[SerializeField] int player_Count;

	[SerializeField] float damageColor_Value;
	[SerializeField] float timeToActivate;
	[SerializeField] bool isTutorialRoom;
	[SerializeField] SharedStats sharedStats_Script;
	SceneManagement sceneManagement;
	[SerializeField] float damage_CurrentTime;
	int darkness_Damage = 1;
	float damage_MaxTime = 3.0f;
	//ScreenFlashingRedEffect redFlash_Script;
	public Animator player1_Anim, player2_Anim;

	public enum darkRoom_State
	{
		Activated, Deactivated, FullDark, Null
	};
	[SerializeField] darkRoom_State darkRoom_CurrentState;

	void Awake()
	{
		sharedStats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
		sceneManagement = Camera.main.GetComponentInParent<SceneManagement>();
		//redFlash_Script = GameObject.Find("GUI").GetComponent<ScreenFlashingRedEffect>();
	}

	// Use this for initialization
	void Start () 
	{
		darkRoom_CurrentState = darkRoom_State.Deactivated;
		darkRoom_Mat.color = Color.white;
		darkRoom_AltMat.color = Color.white;
		player1_Anim = GameObject.Find("Player").GetComponentInChildren<Animator>();
		if(sceneManagement.isSinglePlayer != true)
		{
			player2_Anim = GameObject.Find("Player2").GetComponentInChildren<Animator>();
		}
		else
		{
			player2_Anim = null;
		}
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
			if(darkRoom_AltMat.color == Color.black)
			{
				darkRoom_CurrentState = darkRoom_State.FullDark;
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

	// Needed Smoothing Lerping after damage
	void DarknessDamage()
	{
		if(darkRoom_CurrentState == darkRoom_State.FullDark)
		{
			damage_CurrentTime += Time.deltaTime;
			damageColor_Value += Time.deltaTime;
			darkRoom_AltMat.color = Color.Lerp(Color.black, Color.red, 0.1f + (damageColor_Value * 0.25f));
			
			if(damage_CurrentTime >= damage_MaxTime)
			{
				damage_CurrentTime = 0.0f;
				damageColor_Value = 0.0f;
				darkRoom_AltMat.color = Color.Lerp(Color.black, Color.red, 0.1f);
				sharedStats_Script.player_Health -= darkness_Damage;
				player1_Anim.Play("PlayerDamaged");

				if(player2_Anim != null)
				{
					player2_Anim.Play("PlayerDamaged");
				}
			}
		}
		else
		{
			damageColor_Value = 0.0f;
			damage_CurrentTime = 0.0f;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			if(player_Count < 2)
			{
				player_Count++;
				if(darkRoom_CurrentState != darkRoom_State.FullDark)
				{
					darkRoom_CurrentState = darkRoom_State.Activated;

				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(player_Count > 0)
		{
			if(col.gameObject.layer == 10 && darkRoom_CurrentState == darkRoom_State.Deactivated)
			{
				darkRoom_CurrentState = darkRoom_State.Activated;
			}
			if(col.gameObject.layer == 8)
			{
				if(col.transform.childCount > 1)
				{
					col.transform.GetChild(1).GetComponent<Renderer>().material = darkRoom_Mat;
				}
				else
				{
					col.GetComponent<Renderer>().material = darkRoom_Mat;

				}
			}
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == 10)
		{
			if(player_Count > 0)
			{
				player_Count--;
				if(player_Count == 0)
				{
					darkRoom_CurrentState = darkRoom_State.Deactivated;
					damage_CurrentTime = 0.0f;
				}
			}
		}
		
	}

}
