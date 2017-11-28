using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public bool isSinglePlayer;
	// Use this for initialization

	void Awake () 
	{
		CheckSingleOrMulti();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckSingleOrMulti()
	{
		if(SceneManager.GetActiveScene().name == "Single-Player Level" || 
			SceneManager.GetActiveScene().name == "Single-Player Level 2" || 
			SceneManager.GetActiveScene().name == "Single-Player Level 3" ||
			SceneManager.GetActiveScene().name == "FreeMode Single")
			{
				isSinglePlayer = true;
			}
			else
			{
				isSinglePlayer = false;
			}
	}


}
