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
					ChangeScene ("Instructions 2");
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
			else if (this.gameObject.name == "Single") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Instructions 1");
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
			else if (this.gameObject.name == "SingleFree") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("FreeMode Single Selection");		
				}
			}
			else if (this.gameObject.name == "Co-opFree") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("FreeMode Multi Selection");	
				}
			}
			else if (this.gameObject.name == "ExitMenu") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Main Menu");	
				}
			}
			else if (this.gameObject.name == "Play") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Wave Mode");	
				}
			}
			else if (this.gameObject.name == "Free") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Free Mode");	
				}
			}
			else if (this.gameObject.name == "Credits") 
			{
				DisplaySpriteI();
				if (Input.GetAxis ("TriangleP1") > 0 || Input.GetAxis ("TriangleP2") > 0 || Input.GetAxis ("TriangleK1") > 0 || Input.GetAxis ("TriangleK2") > 0) 
				{
					ChangeScene ("Credits");	
				}
			}

			
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(this.gameObject.name == "Play")
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Single")
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Free")
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Leaderboard") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Co-op") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "SingleFree")
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Co-opFree") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Exit") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "ExitMenu") 
			{
				DisableSpriteI();
			}
			else if(this.gameObject.name == "Credits") 
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
