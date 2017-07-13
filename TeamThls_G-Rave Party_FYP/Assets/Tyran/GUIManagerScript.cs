using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManagerScript : MonoBehaviour {


	private static GUIManagerScript mInstance;

	public static GUIManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("GUIManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_GUIManager");
					mInstance = obj.AddComponent<GUIManagerScript>();
					obj.tag = "GUIManager";
					//DontDestroyOnLoad(obj);
				}
				else
				{
					mInstance = tempObject.GetComponent<GUIManagerScript >();
				}
			}
			return mInstance;
		}
	}


	//HUD
	//Health
	public SharedStats sharedstats;
	public Image playerHealth;
	public Image playerMana;
	public Text playerGold;
	public Text playerScore;



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealth.fillAmount = sharedstats.player_Health/sharedstats.player_MaxHealth;
		playerMana.fillAmount = sharedstats.player_Mana/sharedstats.player_MaxMana;
		playerGold.text = sharedstats.player_Gold.ToString();
		playerScore.text = sharedstats.player_Score.ToString();

		//Debug.Log (playerHealth.fillAmount);
	}
}
