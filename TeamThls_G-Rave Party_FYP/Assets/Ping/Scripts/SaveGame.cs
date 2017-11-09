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

	public Text t_name0;
	public Text t_name1;
	public Text t_name2;
	public Text t_name3;
	public Text t_name4;

	public Text t_wave0;
	public Text t_wave1;
	public Text t_wave2;
	public Text t_wave3;
	public Text t_wave4;

	int score0;
	int score1;
	int score2;
	int score3;
	int score4;

	int wave0;
	int wave1;
	int wave2;
	int wave3;
	int wave4;

	string name0;
	string name1;
	string name2;
	string name3;
	string name4;

	public int tempScore;
	int temp;

	public int tempWave;
	int wave;

	public string tempName;
	string name;

	// multi player
	int m_score0;
	int m_score1;
	int m_score2;
	int m_score3;
	int m_score4;

	int m_wave0;
	int m_wave1;
	int m_wave2;
	int m_wave3;
	int m_wave4;

	string m_name0;
	string m_name1;
	string m_name2;
	string m_name3;
	string m_name4;

	public int multiScore;
	int m_score;

	public int multiWave;
	int m_wave;

	public string multiName;
	string m_name;

	public int counter;

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

		t_wave0.text = wave0.ToString ();
		t_wave1.text = wave1.ToString ();
		t_wave2.text = wave2.ToString ();
		t_wave3.text = wave3.ToString ();
		t_wave4.text = wave4.ToString ();

		t_name0.text = name0.ToString ();
		t_name1.text = name1.ToString ();
		t_name2.text = name2.ToString ();
		t_name3.text = name3.ToString ();
		t_name4.text = name4.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		setScore ();
		if (counter == 0) {
			text0.text = score0.ToString ();
			text1.text = score1.ToString ();
			text2.text = score2.ToString ();
			text3.text = score3.ToString ();
			text4.text = score4.ToString ();

			t_wave0.text = wave0.ToString ();
			t_wave1.text = wave1.ToString ();
			t_wave2.text = wave2.ToString ();
			t_wave3.text = wave3.ToString ();
			t_wave4.text = wave4.ToString ();

			t_name0.text = name0.ToString ();
			t_name1.text = name1.ToString ();
			t_name2.text = name2.ToString ();
			t_name3.text = name3.ToString ();
			t_name4.text = name4.ToString ();
		}
		else if (counter == 1) {
			text0.text = m_score0.ToString ();
			text1.text = m_score1.ToString ();
			text2.text = m_score2.ToString ();
			text3.text = m_score3.ToString ();
			text4.text = m_score4.ToString ();

			t_wave0.text = m_wave0.ToString ();
			t_wave1.text = m_wave1.ToString ();
			t_wave2.text = m_wave2.ToString ();
			t_wave3.text = m_wave3.ToString ();
			t_wave4.text = m_wave4.ToString ();

			t_name0.text = m_name0.ToString ();
			t_name1.text = m_name1.ToString ();
			t_name2.text = m_name2.ToString ();
			t_name3.text = m_name3.ToString ();
			t_name4.text = m_name4.ToString ();
		}
		if (counter >= 2) {
			counter = 0;
		}
	}

	public void saveDataToDisk()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.temporaryCachePath + "/save2.dat");

		saveData.score0 = score0;
		saveData.score1 = score1;
		saveData.score2 = score2;
		saveData.score3 = score3;
		saveData.score4 = score4;

		saveData.wave0 = wave0;
		saveData.wave1 = wave1;
		saveData.wave2 = wave2;
		saveData.wave3 = wave3;
		saveData.wave4 = wave4;

		saveData.name0 = name0;
		saveData.name1 = name1;
		saveData.name2 = name2;
		saveData.name3 = name3;
		saveData.name4 = name4;

		saveData.m_score0 = m_score0;
		saveData.m_score1 = m_score1;
		saveData.m_score2 = m_score2;
		saveData.m_score3 = m_score3;
		saveData.m_score4 = m_score4;

		saveData.m_wave0 = m_wave0;
		saveData.m_wave1 = m_wave1;
		saveData.m_wave2 = m_wave2;
		saveData.m_wave3 = m_wave3;
		saveData.m_wave4 = m_wave4;

		saveData.m_name0 = m_name0;
		saveData.m_name1 = m_name1;
		saveData.m_name2 = m_name2;
		saveData.m_name3 = m_name3;
		saveData.m_name4 = m_name4;

		bf.Serialize(file, saveData);
		file.Close();
	}

	public void switchtable(){
		counter += 1;
	}

	/*
         Loads the save data from the disk
          */
	public void loadDataFromDisk()
	{
		if (File.Exists (Application.temporaryCachePath + "/save2.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.temporaryCachePath + "/save2.dat", FileMode.Open);
			this.saveData = (SaveData)bf.Deserialize(file);

			score0 = saveData.score0;
			score1 = saveData.score1;
			score2 = saveData.score2;
			score3 = saveData.score3;
			score4 = saveData.score4;

			wave0 = saveData.wave0;
			wave1 = saveData.wave1;
			wave2 = saveData.wave2;
			wave3 = saveData.wave3;
			wave4 = saveData.wave4;

			name0 = saveData.name0;
			name1 = saveData.name1;
			name2 = saveData.name2;
			name3 = saveData.name3;
			name4 = saveData.name4;

			m_score0 = saveData.m_score0;
			m_score1 = saveData.m_score1;
			m_score2 = saveData.m_score2;
			m_score3 = saveData.m_score3;
			m_score4 = saveData.m_score4;

			m_wave0 = saveData.m_wave0;
			m_wave1 = saveData.m_wave1;
			m_wave2 = saveData.m_wave2;
			m_wave3 = saveData.m_wave3;
			m_wave4 = saveData.m_wave4;

			m_name0 = saveData.m_name0;
			m_name1 = saveData.m_name1;
			m_name2 = saveData.m_name2;
			m_name3 = saveData.m_name3;
			m_name4 = saveData.m_name4;

			file.Close ();
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

		m_score = multiScore;
		int x_score;

		m_wave = multiWave;
		int x_wave;

		m_name = multiName;
		string x_name;

		if ((m_score >= m_score0) || (m_score == m_score0)){
			x_wave = m_wave0;
			x_name = m_name0;
			x_score = m_score0;
			m_wave0 = m_wave;
			m_name0 = m_name;
			m_score0 = m_score;
			m_wave = x_wave;
			m_name = x_name;
			m_score = x_score;
		}
		if ((m_score < m_score0 && m_score > m_score1) || (m_score == m_score1)){
			x_wave = m_wave1;
			x_name = m_name1;
			x_score = m_score1;
			m_wave1 = m_wave;
			m_name1 = m_name;
			m_score1 = m_score;
			m_wave = x_wave;
			m_name = x_name;
			m_score = x_score;
		}
		if ((m_score < m_score1 && m_score > m_score2) || (m_score == m_score2)) {
			x_wave = m_wave2;
			x_name = m_name2;
			x_score = m_score2;
			m_wave2 = m_wave;
			m_name2 = m_name;
			m_score2 = m_score;
			m_wave = x_wave;
			m_name = x_name;
			m_score = x_score;
		}
		if ((m_score < m_score2 && m_score > m_score3) || (m_score == m_score3)){
			x_wave = m_wave3;
			x_name = m_name3;
			x_score = m_score3;
			m_wave3 = wave;
			m_name3 = name;
			m_score3 = m_score;
			m_wave = x_wave;
			m_name = x_name;
			m_score = x_score;
		}
		if ((m_score < m_score3 && m_score > m_score4) || (m_score == m_score4)){
			x_wave = m_wave4;
			x_name = m_name4;
			x_score = m_score4;
			m_wave4 = m_wave;
			m_name4 = m_name;
			m_score4 = m_score;
			m_wave = x_wave;
			m_name = x_name;
			m_score = x_score;
		}
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