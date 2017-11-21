using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public GameObject GamaManager;
	public SharedStats sharedstats;
	public GameObject scoreManager;
	//public SaveGame saveGame;
	public HighScore highscore;
	public Text playerGold;
	public Text playerScore;
	private string scene;
	public Text playerWin;

	public Transform field;
	public InputField input_f;

	public int player_count;

	public bool checking = false;

	// Use this for initialization
	void Start () 
	{
		GamaManager = GameObject.Find("GameManager");
		scoreManager = GameObject.Find ("HighscoreManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
		//saveGame = scoreManager.GetComponent<SaveGame> ();
		highscore = scoreManager.GetComponent<HighScore>();
		input_f = field.GetComponent<InputField> ();
		player_count = sharedstats.player_Number;
		checking = true;
	}

	// Update is called once per frame
	void Update () 
	{
		playerScore.text = sharedstats.player_Score.ToString();
		if (sharedstats.levelPassed) 
		{
			playerWin.enabled = true;
		}
		else if (!sharedstats.levelPassed) 
		{
			playerWin.enabled = false;
		}

		if (checking == false) {
			if (player_count == 1) {
				highscore.loadDataFromDisk ();

				highscore.single_score = sharedstats.player_Score;
				highscore.s_score.Add (sharedstats.player_Score);

				highscore.s_Names.Add (sharedstats.player_name);
				highscore.s_Wave.Add (sharedstats.wave_count);

				highscore.saveDataToDisk ();

				checking = true;
			}
			else if (player_count == 2) {
				highscore.loadDataFromDisk ();

				highscore.multi_score = sharedstats.player_Score;
				highscore.m_score.Add (sharedstats.player_Score);

				highscore.m_Names.Add (sharedstats.player_name);
				highscore.m_Wave.Add (sharedstats.wave_count);

				highscore.saveDataToDisk ();

				checking = true;
			}
		}
		if (checking == true) {
			highscore.arrangeSingleScore ();
			highscore.arrangeMultiScore ();
			highscore.saveDataToDisk ();

			sharedstats.Reset ();
		}
	}

	public void ChangeScene (string sceneName)
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		sharedstats.Reset ();
		scene = sceneName;
		Invoke ("ChangeSceneDelay",1.0f);
	}

	void ChangeSceneDelay ()
	{
		sharedstats.levelPassed = false;
		SceneManager.LoadScene (scene);
	}

	public void saveName(){
		sharedstats.player_name = input_f.text;
		checking = false;
	}
}
