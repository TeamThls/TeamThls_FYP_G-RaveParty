using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuGUIScript : MonoBehaviour 
{
	private static MainMenuGUIScript mInstance;

	public static MainMenuGUIScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("MainMenuGUI");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_MainMenuGUI");
					mInstance = obj.AddComponent<MainMenuGUIScript>();
					obj.tag = "MainMenuGUI";
					//DontDestroyOnLoad(obj);
				}
				else
				{
					mInstance = tempObject.GetComponent<MainMenuGUIScript >();
				}
			}
			return mInstance;
		}
	}

	private string scene;
	List<string> controloptions = new List<string>() {"Please Select","Keyboard 1","Keyboard 2","Controller 1","Controller 2"};

	public Dropdown player1Dropdown;
	public Dropdown player2Dropdown;
	public GameObject player1;
	public PlayerMovement player1PM;
	public PlayerCombat player1PC;
	public GameObject player2;
	public PlayerMovement player2PM;
	public PlayerCombat player2PC;

	// Use this for initialization
	void Start () 
	{
		PopulateList1 ();
		PopulateList2 ();
		player1PM = player1.GetComponent<PlayerMovement> ();
		player2PM = player2.GetComponent<PlayerMovement> ();
		player1PC = player1.GetComponent<PlayerCombat> ();
		player2PC = player2.GetComponent<PlayerCombat> ();

	}
	

	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Dropdown1_IndexChanged (int index)
	{
		if (index == 1) 
		{
			player1PM.player_Control = PlayerMovement.Player_Controller.Keyboard_1;
			player1PC.player_Control = PlayerCombat.Player_Controller.Keyboard_1;

		} 
		else if (index == 2) 
		{
			player1PM.player_Control = PlayerMovement.Player_Controller.Keyboard_2;
			player1PC.player_Control = PlayerCombat.Player_Controller.Keyboard_2;

		}
		else if (index == 3) 
		{
			player1PM.player_Control = PlayerMovement.Player_Controller.Controller_1;
			player1PC.player_Control = PlayerCombat.Player_Controller.Controller_1;
		}
		else if (index == 4) 
		{
			player1PM.player_Control = PlayerMovement.Player_Controller.Controller_2;
			player1PC.player_Control = PlayerCombat.Player_Controller.Controller_2;
		}

	}

	public void Dropdown2_IndexChanged (int index)
	{
		if (index == 1) 
		{
			player2PM.player_Control = PlayerMovement.Player_Controller.Keyboard_1;
			player2PC.player_Control = PlayerCombat.Player_Controller.Keyboard_1;

		} 
		else if (index == 2) 
		{
			player2PM.player_Control = PlayerMovement.Player_Controller.Keyboard_2;
			player2PC.player_Control = PlayerCombat.Player_Controller.Keyboard_2;

		}
		else if (index == 3) 
		{
			player2PM.player_Control = PlayerMovement.Player_Controller.Controller_1;
			player2PC.player_Control = PlayerCombat.Player_Controller.Controller_1;
		}
		else if (index == 4) 
		{
			player2PM.player_Control = PlayerMovement.Player_Controller.Controller_2;
			player2PC.player_Control = PlayerCombat.Player_Controller.Controller_2;
		}

	}

	void PopulateList1()
	{
		player1Dropdown.AddOptions (controloptions);
	}

	void PopulateList2()
	{
		player2Dropdown.AddOptions (controloptions);
	}

	public void ChangeScene (string sceneName)
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		scene = sceneName;
		Invoke ("ChangeSceneDelay",1.0f);
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
}
