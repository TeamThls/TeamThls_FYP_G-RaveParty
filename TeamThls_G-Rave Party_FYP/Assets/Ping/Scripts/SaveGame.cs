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

	public Text t_name0;
	public Text t_name1;
	public Text t_name2;
	public Text t_name3;
	public Text t_name4;
	//public Text t_name5;
	//public Text t_name6;
	//public Text t_name7;
	//public Text t_name8;
	//public Text t_name9;

	public Text t_wave0;
	public Text t_wave1;
	public Text t_wave2;
	public Text t_wave3;
	public Text t_wave4;
	//public Text t_wave5;
	//public Text t_wave6;
	//public Text t_wave7;
	//public Text t_wave8;
	//public Text t_wave9;

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

	int wave0;
	int wave1;
	int wave2;
	int wave3;
	int wave4;
	//int wave5;
	//int wave6;
	//int wave7;
	//int wave8;
	//int wave9;

	string name0;
	string name1;
	string name2;
	string name3;
	string name4;
	//string name5;
	//string name6;
	//string name7;
	//string name8;
	//string name9;

	public int tempScore;
	int temp;

	public int tempWave;
	int wave;

	public string tempName;
	string name;

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

		t_wave0.text = wave0.ToString ();
		t_wave1.text = wave1.ToString ();
		t_wave2.text = wave2.ToString ();
		t_wave3.text = wave3.ToString ();
		t_wave4.text = wave4.ToString ();
		//t_wave5.text = wave5.ToString ();
		//t_wave6.text = wave6.ToString ();
		//t_wave7.text = wave7.ToString ();
		//t_wave8.text = wave8.ToString ();
		//t_wave9.text = wave9.ToString ();

		t_name0.text = name0.ToString ();
		t_name1.text = name1.ToString ();
		t_name2.text = name2.ToString ();
		t_name3.text = name3.ToString ();
		t_name4.text = name4.ToString ();
		//t_name5.text = name5.ToString ();
		//t_name6.text = name6.ToString ();
		//t_name7.text = name7.ToString ();
		//t_name8.text = name8.ToString ();
		//t_name9.text = name9.ToString ();
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

			t_name0.text = wave0.ToString ();
			t_name1.text = wave1.ToString ();
			t_name2.text = wave2.ToString ();
			t_name3.text = wave3.ToString ();
			t_name4.text = wave4.ToString ();
			//t_name5.text = wave5.ToString ();
			//t_name6.text = wave6.ToString ();
			//t_name7.text = wave7.ToString ();
			//t_name8.text = wave8.ToString ();
			//t_name9.text = wave9.ToString ();

			t_wave0.text = name0.ToString ();
			t_wave1.text = name1.ToString ();
			t_wave2.text = name2.ToString ();
			t_wave3.text = name3.ToString ();
			t_wave4.text = name4.ToString ();
			//t_wave5.text = name5.ToString ();
			//t_wave6.text = name6.ToString ();
			//t_wave7.text = name7.ToString ();
			//t_wave8.text = name8.ToString ();
			//t_wave9.text = name9.ToString ();
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

		saveData.wave0 = wave0;
		saveData.wave1 = wave1;
		saveData.wave2 = wave2;
		saveData.wave3 = wave3;
		saveData.wave4 = wave4;
		//saveData.wave5 = wave5;
		//saveData.wave6 = wave6;
		//saveData.wave7 = wave7;
		//saveData.wave8 = wave8;
		//saveData.wave9 = wave9;

		saveData.name0 = name0;
		saveData.name1 = name1;
		saveData.name2 = name2;
		saveData.name3 = name3;
		saveData.name4 = name4;
		//saveData.name5 = name5;
		//saveData.name6 = name6;
		//saveData.name7 = name7;
		//saveData.name8 = name8;
		//saveData.name9 = name9;

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

			wave0 = saveData.wave0;
			wave1 = saveData.wave1;
			wave2 = saveData.wave2;
			wave3 = saveData.wave3;
			wave4 = saveData.wave4;
			//wave5 = saveData.wave5;
			//wave6 = saveData.wave6;
			//wave7 = saveData.wave7;
			//wave8 = saveData.wave8;
			//wave9 = saveData.wave9;

			name0 = saveData.name0;
			name1 = saveData.name1;
			name2 = saveData.name2;
			name3 = saveData.name3;
			name4 = saveData.name4;
			//name5 = saveData.name5;
			//name6 = saveData.name6;
			//name7 = saveData.name7;
			//name8 = saveData.name8;
			//name9 = saveData.name9;
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

		wave = tempWave;
		int num;

		name = tempName;
		string word;

		// checking same number;
		/*if (temp == score0) {
			num = wave0;
			word = name0;
			tempNum = score0;
			wave0 = wave;
			name0 = name;
			score0 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score1) {
			num = wave1;
			word = name1;
			tempNum = score1;
			wave1 = wave;
			name1 = name;
			score1 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score2) {
			num = wave2;
			word = name2;
			tempNum = score2;
			wave2 = wave;
			name2 = name;
			score2 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score3) {
			num = wave3;
			word = name3;
			tempNum = score3;
			wave3 = wave;
			name3 = name;
			score3 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score4) {
			num = wave4;
			word = name4;
			tempNum = score4;
			wave4 = wave;
			name4 = name;
			score4 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}*/
		/*else if (temp == score5) {
			num = wave5;
			word = name5;
			tempNum = score5;
			wave5 = wave;
			name5 = name;
			score5 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score6) {
			num = wave6;
			word = name6;
			tempNum = score6;
			wave6 = wave;
			name6 = name;
			score6 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score7) {
			num = wave7;
			word = name7;
			tempNum = score7;
			wave7 = wave;
			name7 = name;
			score7 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score8) {
			num = wave8;
			word = name8;
			tempNum = score8;
			wave8 = wave;
			name8 = name;
			score8 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		else if (temp == score9) {
			num = wave9;
			word = name9;
			tempNum = score9;
			wave9 = wave;
			name9 = name;
			score9 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}*/

		// checking new highscore
		if ((temp >= score0) || (temp == score0)){
			num = wave0;
			word = name0;
			tempNum = score0;
			wave0 = wave;
			name0 = name;
			score0 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if ((temp < score0 && temp > score1) || (temp == score1)){
			num = wave1;
			word = name1;
			tempNum = score1;
			wave1 = wave;
			name1 = name;
			score1 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if ((temp < score1 && temp > score2) || (temp == score2)) {
			num = wave2;
			word = name2;
			tempNum = score2;
			wave2 = wave;
			name2 = name;
			score2 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if ((temp < score2 && temp > score3) || (temp == score3)){
			num = wave3;
			word = name3;
			tempNum = score3;
			wave3 = wave;
			name3 = name;
			score3 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if ((temp < score3 && temp > score4) || (temp == score4)){
			num = wave4;
			word = name4;
			tempNum = score4;
			wave4 = wave;
			name4 = name;
			score4 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
	/*	if (temp < score4 && temp > score5) {
	 		num = wave5;
			word = name5;
			tempNum = score5;
			wave5 = wave;
			name5 = name;
			score5 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if (temp < score5 && temp > score6) {
			num = wave6;
			word = name6;
			tempNum = score6;
			wave6 = wave;
			name6 = name;
			score6 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if (temp < score6 && temp > score7) {
			num = wave7;
			word = name7;
			tempNum = score7;
			wave7 = wave;
			name7 = name;
			score7 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if (temp < score7 && temp > score8) {
			num = wave8;
			word = name8;
			tempNum = score8;
			wave8 = wave;
			name8 = name;
			score8 = temp;
			wave = num;
			name = word;
			temp = tempNum;
		}
		if (temp < score8 && temp > score9) {
			num = wave9;
			word = name9;
			tempNum = score9;
			wave9 = wave;
			name9 = name;
			score9 = temp;
			wave = num;
			name = word;
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

	public int wave0;
	public int wave1;
	public int wave2;
	public int wave3;
	public int wave4;
	public int wave5;
	public int wave6;
	public int wave7;
	public int wave8;
	public int wave9;

	public string name0;
	public string name1;
	public string name2;
	public string name3;
	public string name4;
	public string name5;
	public string name6;
	public string name7;
	public string name8;
	public string name9;

	public int m_score0;
	public int m_score1;
	public int m_score2;
	public int m_score3;
	public int m_score4;
	public int m_score5;
	public int m_score6;
	public int m_score7;
	public int m_score8;
	public int m_score9;

	public int m_wave0;
	public int m_wave1;
	public int m_wave2;
	public int m_wave3;
	public int m_wave4;
	public int m_wave5;
	public int m_wave6;
	public int m_wave7;
	public int m_wave8;
	public int m_wave9;

	public string m_name0;
	public string m_name1;
	public string m_name2;
	public string m_name3;
	public string m_name4;
	public string m_name5;
	public string m_name6;
	public string m_name7;
	public string m_name8;
	public string m_name9;

	public int level;
}