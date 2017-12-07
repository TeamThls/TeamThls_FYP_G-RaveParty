﻿using System.Collections;
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
	public GameObject GameManager;
	public SharedStats sharedstats;
	public Image playerHealth;
	public Image playerMana;
	public Text playerGold;
	public Text playerScore;
	public bool paused = false;
	//public Canvas PauseUI;
	private string scene;

	public Transform Compass;
	public Transform UpgradeMenu;
	public Transform bookIcon;
	public Transform bookCompass;

	public GameObject magicRune;
	public ActiveMagic Magic;
	public bool triggered;
	public float setTime;
	public float setTime2;
	public float targetTime;

	public Slider musicduration;
	bool reset;
	public int counter;

	void Awake(){
		magicRune = GameObject.Find ("MagicSkill");
		Compass = this.transform.GetChild (6);
		UpgradeMenu = this.transform.GetChild (8);
		UpgradeMenu.gameObject.SetActive (false);
		bookIcon = Compass.GetChild (0);
		bookCompass = Compass.GetChild (2);
	}

	// Use this for initialization
	void Start () 
	{
		//PauseUI.enabled = false;
		GameManager = GameObject.Find("GameManager");
		sharedstats = GameManager.GetComponent<SharedStats> ();
		Magic = magicRune.GetComponent<ActiveMagic> ();
		if(sharedstats.enabled != true)
		{
			sharedstats.enabled = true;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		targetTime = Magic.setTime;
		playerHealth.fillAmount = sharedstats.player_Health/sharedstats.player_MaxHealth;
		playerMana.fillAmount = sharedstats.player_Mana/sharedstats.player_MaxMana;

		//Debug.Log (playerMana.fillAmount);
		//Debug.Log (sharedstats.player_Mana);


		if (sharedstats.levelPassed == true && sharedstats.wave_count <= 2) 
		{
			UpgradeMenu.gameObject.SetActive (true);
		} 
		else {
			UpgradeMenu.gameObject.SetActive (false);
		}

		//playerGold.text = sharedstats.player_Gold.ToString();
		playerScore.text = "Score: " + sharedstats.player_Score.ToString();

		if (Magic.inCd == false) {
			bookCompass.GetComponent<Image> ().enabled = true;
			bookIcon.GetComponent<Image> ().fillAmount = 1;
			setTime = 0.0f;
			setTime2 = 0.0f;
			counter = 0;
		}
		else if (Magic.inCd == true) {
			bookCompass.GetComponent<Image> ().enabled = false;
		}

		if (Magic.inCd == true && counter == 0) {
			bookIcon.GetComponent<Image> ().fillAmount = 0;
			reset = true;
			triggered = false;
			counter += 1;
		}

		if (Magic.inCd == true && counter == 1) {
			setTime += Time.deltaTime;
			setTime2 += Time.deltaTime;
			if (setTime2 >= 1.0f) {
				bookIcon.GetComponent<Image> ().fillAmount += 1.0f / targetTime;
				setTime2 = 0.0f;
			}
			if (setTime >= targetTime) {
				bookIcon.GetComponent<Image> ().fillAmount = 1.0f;
				setTime = 0.0f;
			}
		}
		musicduration.value = SoundManagerScript.Instance.bgmAudioSource.time / SoundManagerScript.Instance.bgmAudioSource.clip.length;



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


	public void NextScene(){
		SceneManager.LoadScene (4);
	}
}
