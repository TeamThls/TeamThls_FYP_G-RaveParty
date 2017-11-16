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
			if (this.gameObject.name == "Co-op") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Control Scheme 2");
				}
			}
			else if (this.gameObject.name == "Leaderboard") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Highscore");
				}
			}
			else if (this.gameObject.name == "Option") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					
				}
				//ChangeScene()
			}
			else if (this.gameObject.name == "Exit") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					Exit();		
				}
			}
			
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(this.gameObject.name == "Co-op")
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Leaderboard") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Option") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Exit") 
			{
				DisableSpriteI();
			}
		}
	}

	void DisplaySpriteI()
	{
		transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
		transform.GetChild(1).GetComponent<Light>().enabled = true;
	}

	void DisableSpriteI()
	{
		transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
		transform.GetChild(1).GetComponent<Light>().enabled = false;
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
