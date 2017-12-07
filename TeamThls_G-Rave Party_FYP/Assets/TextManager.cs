using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

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

	GameObject leaderboard;
	HighScore score;

	public Text SingleMulti;

	public string multi;
	public string single;

	// Use this for initialization
	void Start () {
		leaderboard = GameObject.Find ("HighscoreManager");
		score = leaderboard.GetComponent<HighScore> ();
		t_wave0.text = score.s_Wave[0].ToString ();
		t_wave1.text = score.s_Wave[1].ToString ();
		t_wave2.text = score.s_Wave[2].ToString ();
		t_wave3.text = score.s_Wave[3].ToString ();
		t_wave4.text = score.s_Wave[4].ToString ();

		t_name0.text = score.s_Names[0].ToString ();
		t_name1.text = score.s_Names[1].ToString ();
		t_name2.text = score.s_Names[2].ToString ();
		t_name3.text = score.s_Names[3].ToString ();
		t_name4.text = score.s_Names[4].ToString ();

		text0.text = score.s_score [0].ToString ();
		text1.text = score.s_score [1].ToString ();
		text2.text = score.s_score [2].ToString ();
		text3.text = score.s_score [3].ToString ();
		text4.text = score.s_score [4].ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (score.counter == 0) {
			t_wave0.text = score.s_Wave[0].ToString ();
			t_wave1.text = score.s_Wave[1].ToString ();
			t_wave2.text = score.s_Wave[2].ToString ();
			t_wave3.text = score.s_Wave[3].ToString ();
			t_wave4.text = score.s_Wave[4].ToString ();

			t_name0.text = score.s_Names[0].ToString ();
			t_name1.text = score.s_Names[1].ToString ();
			t_name2.text = score.s_Names[2].ToString ();
			t_name3.text = score.s_Names[3].ToString ();
			t_name4.text = score.s_Names[4].ToString ();

			text0.text = score.s_score [0].ToString ();
			text1.text = score.s_score [1].ToString ();
			text2.text = score.s_score [2].ToString ();
			text3.text = score.s_score [3].ToString ();
			text4.text = score.s_score [4].ToString ();

			SingleMulti.text = single;
		}
		if (score.counter == 1) {
			t_wave0.text = score.m_Wave[0].ToString ();
			t_wave1.text = score.m_Wave[1].ToString ();
			t_wave2.text = score.m_Wave[2].ToString ();
			t_wave3.text = score.m_Wave[3].ToString ();
			t_wave4.text = score.m_Wave[4].ToString ();

			t_name0.text = score.m_Names[0].ToString ();
			t_name1.text = score.m_Names[1].ToString ();
			t_name2.text = score.m_Names[2].ToString ();
			t_name3.text = score.m_Names[3].ToString ();
			t_name4.text = score.m_Names[4].ToString ();

			text0.text = score.m_score [0].ToString ();
			text1.text = score.m_score [1].ToString ();
			text2.text = score.m_score [2].ToString ();
			text3.text = score.m_score [3].ToString ();
			text4.text = score.m_score [4].ToString ();

			SingleMulti.text = multi;
		}
	}
}
