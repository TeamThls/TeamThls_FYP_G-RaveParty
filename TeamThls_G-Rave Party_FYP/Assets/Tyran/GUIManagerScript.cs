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
	public GameObject GamaManager;
	public SharedStats sharedstats;
	public Image playerHealth;
	public Image playerMana;
	public Text playerGold;
	public Text playerScore;
	public bool paused = false;
	//public Canvas PauseUI;
	private string scene;

	// Use this for initialization
	void Start () 
	{
		//PauseUI.enabled = false;
		GamaManager = GameObject.Find("GameManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealth.fillAmount = sharedstats.player_Health/sharedstats.player_MaxHealth;
		playerMana.fillAmount = sharedstats.player_Mana/sharedstats.player_MaxMana;

		//Debug.Log (playerMana.fillAmount);
		//Debug.Log (sharedstats.player_Mana);

		playerGold.text = sharedstats.player_Gold.ToString();
		playerScore.text = sharedstats.player_Score.ToString();

		/*if(paused)
		{
			PauseUI.enabled = true;
			Time.timeScale = 0;
		}
		if(!paused)
		{
			PauseUI.enabled = false;

			Time.timeScale = 1;
		}*/
		//Debug.Log (playerHealth.fillAmount);
	}


	public void PauseButton()
	{
		
		paused = !paused;

	}

	public void ChangeScene (string sceneName)
	{
		
		scene = sceneName;
		Invoke ("ChangeSceneDelay",1.0f);
	}

	void ChangeSceneDelay ()
	{
		SceneManager.LoadScene (scene);
	}


	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


	}
}
