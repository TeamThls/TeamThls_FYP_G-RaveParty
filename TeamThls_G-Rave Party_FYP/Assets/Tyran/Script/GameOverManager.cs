using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public GameObject GamaManager;
	public SharedStats sharedstats;
	public Text playerGold;
	public Text playerScore;
	private string scene;
	public Text playerWin;
	// Use this for initialization
	void Start () 
	{
		GamaManager = GameObject.Find("GameManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		sharedstats.Reset ();

		playerScore.text = sharedstats.player_Score.ToString();
		if (sharedstats.levelPassed) 
		{
			playerWin.enabled = true;
		}
		else if (!sharedstats.levelPassed) 
		{
			playerWin.enabled = false;
		}

	}

	public void ChangeScene (string sceneName)
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		scene = sceneName;
		Invoke ("ChangeSceneDelay",1.0f);

	}

	void ChangeSceneDelay ()
	{
		sharedstats.levelPassed = false;
		SceneManager.LoadScene (scene);
	}
}
