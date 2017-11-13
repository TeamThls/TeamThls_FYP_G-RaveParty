using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScore : MonoBehaviour {

	private SaveScore Score;

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

	public List<int> s_score;
	public List<int> m_score;

	public List<string> s_Names;
	public List<string> m_Names;

	public List<int> s_Wave;
	public List<int> m_Wave;

	public int single_score;
	public int multi_score;

	public int counter;

	// Use this for initialization
	void Start () {
		this.Score = new SaveScore ();
		s_score = new List<int>();
		m_score = new List<int>();

		loadDataFromDisk ();

		t_wave0.text = s_Wave[0].ToString ();
		t_wave1.text = s_Wave[1].ToString ();
		t_wave2.text = s_Wave[2].ToString ();
		t_wave3.text = s_Wave[3].ToString ();
		t_wave4.text = s_Wave[4].ToString ();

		t_name0.text = s_Names[0].ToString ();
		t_name1.text = s_Names[1].ToString ();
		t_name2.text = s_Names[2].ToString ();
		t_name3.text = s_Names[3].ToString ();
		t_name4.text = s_Names[4].ToString ();

		text0.text = s_score [0].ToString ();
		text1.text = s_score [1].ToString ();
		text2.text = s_score [2].ToString ();
		text3.text = s_score [3].ToString ();
		text4.text = s_score [4].ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == 0) {
			t_wave0.text = s_Wave[0].ToString ();
			t_wave1.text = s_Wave[1].ToString ();
			t_wave2.text = s_Wave[2].ToString ();
			t_wave3.text = s_Wave[3].ToString ();
			t_wave4.text = s_Wave[4].ToString ();

			t_name0.text = s_Names[0].ToString ();
			t_name1.text = s_Names[1].ToString ();
			t_name2.text = s_Names[2].ToString ();
			t_name3.text = s_Names[3].ToString ();
			t_name4.text = s_Names[4].ToString ();

			text0.text = s_score [0].ToString ();
			text1.text = s_score [1].ToString ();
			text2.text = s_score [2].ToString ();
			text3.text = s_score [3].ToString ();
			text4.text = s_score [4].ToString ();
		}
		if (counter == 1) {
			t_wave0.text = m_Wave[0].ToString ();
			t_wave1.text = m_Wave[1].ToString ();
			t_wave2.text = m_Wave[2].ToString ();
			t_wave3.text = m_Wave[3].ToString ();
			t_wave4.text = m_Wave[4].ToString ();

			t_name0.text = m_Names[0].ToString ();
			t_name1.text = m_Names[1].ToString ();
			t_name2.text = m_Names[2].ToString ();
			t_name3.text = m_Names[3].ToString ();
			t_name4.text = m_Names[4].ToString ();

			text0.text = m_score [0].ToString ();
			text1.text = m_score [1].ToString ();
			text2.text = m_score [2].ToString ();
			text3.text = m_score [3].ToString ();
			text4.text = m_score [4].ToString ();

		}

		if (counter >= 2) {
			counter = 0;
		}
	}

	public void saveDataToDisk()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.temporaryCachePath + "/highscore.dat");

		Score.single_Scores = s_score;
		Score.multi_Scores = m_score;

		Score.single_Name = s_Names;
		Score.multi_Name = m_Names;

		Score.single_Wave = s_Wave;
		Score.multi_Wave = m_Wave;

		Score.single_temp = single_score;
		Score.multi_temp = multi_score;

		bf.Serialize(file, Score);
		file.Close();
	}
		
    //Loads the save data from the disk
	public void loadDataFromDisk()
	{
		if (File.Exists (Application.temporaryCachePath + "/highscore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.temporaryCachePath + "/highscore.dat", FileMode.Open);
			this.Score = (SaveScore)bf.Deserialize(file);

			s_score = Score.single_Scores;
			m_score = Score.multi_Scores;

			s_Names = Score.single_Name;
			m_Names = Score.multi_Name;

			s_Wave = Score.single_Wave;
			m_Wave = Score.multi_Wave;

			single_score = Score.single_temp;
			multi_score = Score.multi_temp;

			file.Close ();
		}
	}

	public void arrangeSingleScore(){
		for (int i = 0; i < s_score.Count - 1; i++) {
			int temp;
			string t_name;
			int t_wave;
			if (s_score[i] <= s_score[i + 1]) {
				temp = s_score[i];
				t_name = s_Names [i];
				t_wave = s_Wave [i];

				s_score[i] = s_score[i + 1];
				s_Names [i] = s_Names [i + 1];
				s_Wave [i] = s_Wave [i + 1];

				s_score[i + 1] = temp;
				s_Names [i + 1] = t_name;
				s_Wave [i + 1] = t_wave;
			}
		}
		/*if (s_score.Count > 10) {
			s_score.Remove (s_score [10]);
		}
		if (m_score.Count > 10) {
			m_score.Remove (m_score [10]);
		}*/

		saveDataToDisk ();
	}

	public void arrangeMultiScore(){
		for (int j = 0; j < m_score.Count; j++) {
			int temp;
			string t_name;
			int t_wave;
			if (m_score[j] <= m_score[j + 1]) {
				temp = m_score[j];
				t_name = m_Names [j];
				t_wave = m_Wave [j];

				m_score[j] = m_score[j + 1];
				m_Names [j] = m_Names [j + 1];
				m_Wave [j] = m_Wave [j + 1];

				m_score[j + 1] = temp;
				m_Names [j + 1] = t_name;
				m_Wave [j + 1] = t_wave;
			}
		}
		saveDataToDisk ();
	}

	public void switchSingleorMulti(){
		counter += 1;
	}
}


[Serializable]

class SaveScore {
	public List<int> single_Scores;
	public List<int> multi_Scores;

	public List<string> single_Name;
	public List<string> multi_Name;

	public List<int> single_Wave;
	public List<int> multi_Wave;

	public int single_temp;
	public int multi_temp;
}