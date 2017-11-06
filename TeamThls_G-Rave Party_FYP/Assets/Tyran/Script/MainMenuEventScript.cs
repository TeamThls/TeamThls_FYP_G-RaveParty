using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEventScript : MonoBehaviour {

	private string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ChangeScene ("Highscore");
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" ) 
		{
			if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
			{
				if (this.gameObject.name == "Play") 
				{
					ChangeScene ("Control Scheme 2");
				}
				else if (this.gameObject.name == "Leaderboard") 
				{
					ChangeScene ("Highscore");
				}
				else if (this.gameObject.name == "Option") 
				{
					//ChangeScene()
				}
				else if (this.gameObject.name == "Exit") 
				{
					Exit();
				}
			}
			
		}
	}

	public void ChangeScene (string sceneName)
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		scene = sceneName;
		Invoke ("ChangeSceneDelay",0.1f);
	}

	void ChangeSceneDelay ()
	{
		SceneManager.LoadScene (scene);
	}

	public void Exit()
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		Application.Quit();
	}

	public void goMainMenu(){
		ChangeScene ("Main Menu");
	}
}
