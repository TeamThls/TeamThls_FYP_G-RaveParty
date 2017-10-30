using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public GameObject GamaManager;
	public SharedStats sharedstats;
	public GameObject scoreManager;
	public SaveGame saveGame;
	public Text playerGold;
	public Text playerScore;
	private string scene;
	public Text playerWin;
	// Use this for initialization
	void Start () 
	{
		GamaManager = GameObject.Find("GameManager");
		scoreManager = GameObject.Find ("HighscoreManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
		saveGame = scoreManager.GetComponent<SaveGame> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		saveGame.tempScore = sharedstats.player_Score;
		saveGame.saveDataToDisk ();
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
