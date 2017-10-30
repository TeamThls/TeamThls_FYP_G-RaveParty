using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGame : MonoBehaviour {

	private SaveData saveData;    // the Dictionary used to save and load data to/from disk
	protected string savePath;

	//public int score;
	public Text text0;
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	//public Text text5;
	//public Text text6;
	//public Text text7;
	//public Text text8;
	//public Text text9;

	int score0;
	int score1;
	int score2;
	int score3;
	int score4;
	//int score5;
	//int score6;
	//int score7;
	//int score8;
	//int score9;

	public int tempScore;
	int temp;

	void Awake(){
		this.saveData = new SaveData();
		loadDataFromDisk();
	}

	// Use this for initialization
	void Start () {
		text0.text = score0.ToString ();
		text1.text = score1.ToString ();
		text2.text = score2.ToString ();
		text3.text = score3.ToString ();
		text4.text = score4.ToString ();
		//text5.text = score5.ToString ();
		//text6.text = score6.ToString ();
		//text7.text = score7.ToString ();
		//text8.text = score8.ToString ();
		//text9.text = score9.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		setScore ();

		if (Input.GetKeyDown (KeyCode.A)) {
			saveDataToDisk ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			saveDataToDisk ();
			loadDataFromDisk ();
			text0.text = score0.ToString();
			text1.text = score1.ToString();
			text2.text = score2.ToString();
			text3.text = score3.ToString();
			text4.text = score4.ToString();
			//text5.text = score5.ToString();
			//text6.text = score6.ToString();
			//text7.text = score7.ToString();
			//text8.text = score8.ToString();
			//text9.text = score9.ToString();
		}
	}

	public void saveDataToDisk()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.temporaryCachePath + "/save.dat");

		saveData.score0 = score0;
		saveData.score1 = score1;
		saveData.score2 = score2;
		saveData.score3 = score3;
		saveData.score4 = score4;
		//saveData.score5 = score5;
		//saveData.score6 = score6;
		//saveData.score7 = score7;
		//saveData.score8 = score8;
		//saveData.score9 = score9;

		bf.Serialize(file, saveData);
		file.Close();
	}

	/*
         Loads the save data from the disk
          */
	public void loadDataFromDisk()
	{
		if (File.Exists (Application.temporaryCachePath + "/save.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.temporaryCachePath + "/save.dat", FileMode.Open);
			this.saveData = (SaveData)bf.Deserialize(file);

			file.Close ();
			score0 = saveData.score0;
			score1 = saveData.score1;
			score2 = saveData.score2;
			score3 = saveData.score3;
			score4 = saveData.score4;
			//score5 = saveData.score5;
			//score6 = saveData.score6;
			//score7 = saveData.score7;
			//score8 = saveData.score8;
			//score9 = saveData.score9;
		}
	}
	public void AddScore ()
	{
		
	}

	public int GetScore ()
	{
		return score0;
	}

	void setScore(){
		temp = tempScore;
		int tempNum;
		if (temp >= score0) {
			tempNum = score0;
			score0 = temp;
			temp = tempNum;
		}
		if (temp < score0 && temp > score1) {
			tempNum = score1;
			score1 = temp;
			temp = tempNum;
		}
		if (temp < score1 && temp > score2) {
			tempNum = score2;
			score2 = temp;
			temp = tempNum;
		}
		if (temp < score2 && temp > score3) {
			tempNum = score3;
			score3 = temp;
			temp = tempNum;
		}
		if (temp < score3 && temp > score4) {
			tempNum = score4;
			score4 = temp;
			temp = tempNum;
		}
	/*	if (temp < score4 && temp > score5) {
			tempNum = score5;
			score5 = temp;
			temp = tempNum;
		}
		if (temp < score5 && temp > score6) {
			tempNum = score6;
			score6 = temp;
			temp = tempNum;
		}
		if (temp < score6 && temp > score7) {
			tempNum = score7;
			score7 = temp;
			temp = tempNum;
		}
		if (temp < score7 && temp > score8) {
			tempNum = score8;
			score8 = temp;
			temp = tempNum;
		}
		if (temp < score8 && temp > score9) {
			tempNum = score9;
			score9 = temp;
			temp = tempNum;
		}   */
	}
}

[Serializable]

class SaveData {
	public int temp;

	public int score0;
	public int score1;
	public int score2;
	public int score3;
	public int score4;
	public int score5;
	public int score6;
	public int score7;
	public int score8;
	public int score9;

	public int level;
}