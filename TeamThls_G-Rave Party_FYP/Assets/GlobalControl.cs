using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

	public static GlobalControl Instance;

	public float p_Health;
	public float p_MaxHealth;

	public float p_Mana;
	public float p_MaxMana;

	public int p_Gold = 0;
	public int p_Score = 0;

	public int wave_count = 0;

	public int B_Damage;
	public int F_Damage;
	public int I_Damage;
	public int L_Damage;

	public int Mana_Reg;

	public int B_Mana;
	public int F_Mana;
	public int Base_Mana;
	public int L_Mana;
	public int I_Mana;

	public float F_Duration;
	public float L_Duration;
	public float I_Duration;

	public float ablty_Duration;

	public int F_Range;

	void Awake() {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} 
		else if (Instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
