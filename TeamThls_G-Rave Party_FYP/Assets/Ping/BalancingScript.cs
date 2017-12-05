using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancingScript : MonoBehaviour {
	
	SharedStats stts;

	public int wave_Count;
	public int player_Count;

	// SINGLE
	public int SW1_enDamage;
	public int SW1_pfDamage;
	public int SW1_seDamage;

	public int SW2_enDamage;
	public int SW2_pfDamage;
	public int SW2_seDamage;

	public int SW3_enDamage;
	public int SW3_pfDamage;
	public int SW3_seDamage;

	public float SW1_enHealth;
	public float SW1_pfHealth;
	public float SW1_seHealth;
	public float SW1_stHealth;

	public float SW2_enHealth;
	public float SW2_pfHealth;
	public float SW2_seHealth;
	public float SW2_stHealth;

	public float SW3_enHealth;
	public float SW3_pfHealth;
	public float SW3_seHealth;
	public float SW3_stHealth;

	public float SW1_enSpeed;
	public float SW1_pfSpeed;
	public float SW1_seSpeed;
	public float SW1_stSpeed;

	public float SW2_enSpeed;
	public float SW2_pfSpeed;
	public float SW2_seSpeed;
	public float SW2_stSpeed;

	public float SW3_enSpeed;
	public float SW3_pfSpeed;
	public float SW3_seSpeed;
	public float SW3_stSpeed;

	// MULTI
	public int MW1_enDamage;
	public int MW1_pfDamage;
	public int MW1_seDamage;

	public int MW2_enDamage;
	public int MW2_pfDamage;
	public int MW2_seDamage;

	public int MW3_enDamage;
	public int MW3_pfDamage;
	public int MW3_seDamage;

	public float MW1_enHealth;
	public float MW1_pfHealth;
	public float MW1_seHealth;
	public float MW1_stHealth;

	public float MW2_enHealth;
	public float MW2_pfHealth;
	public float MW2_seHealth;
	public float MW2_stHealth;

	public float MW3_enHealth;
	public float MW3_pfHealth;
	public float MW3_seHealth;
	public float MW3_stHealth;

	public float MW1_enSpeed;
	public float MW1_pfSpeed;
	public float MW1_seSpeed;
	public float MW1_stSpeed;

	public float MW2_enSpeed;
	public float MW2_pfSpeed;
	public float MW2_seSpeed;
	public float MW2_stSpeed;

	public float MW3_enSpeed;
	public float MW3_pfSpeed;
	public float MW3_seSpeed;
	public float MW3_stSpeed;

	// Use this for initialization
	void Start () {
		stts = this.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		wave_Count = stts.wave_count;
		player_Count = stts.player_Number;

		if (player_Count == 1) {
			if (wave_Count == 1) {
				stts.enemy_Damage = SW1_enDamage;
				stts.path_Damage = SW1_pfDamage;
				stts.str_Damage = SW1_seDamage;

				stts.enemy_Health = SW1_enHealth;
				stts.path_Health = SW1_pfHealth;
				stts.str_Health = SW1_seHealth;
				stts.shoot_Health = SW1_stHealth;

				stts.enemy_Speed = SW1_enSpeed;
				stts.path_Speed = SW1_pfSpeed;
				stts.str_Speed = SW1_seSpeed;
				stts.shoot_Speed = SW1_stSpeed;
			}

			if (wave_Count == 2) {
				stts.enemy_Damage = SW2_enDamage;
				stts.path_Damage = SW2_pfDamage;
				stts.str_Damage = SW2_seDamage;

				stts.enemy_Health = SW2_enHealth;
				stts.path_Health = SW2_pfHealth;
				stts.str_Health = SW2_seHealth;
				stts.shoot_Health = SW2_stHealth;

				stts.enemy_Speed = SW2_enSpeed;
				stts.path_Speed = SW2_pfSpeed;
				stts.str_Speed = SW2_seSpeed;
				stts.shoot_Speed = SW2_stSpeed;
			}

			if (wave_Count == 3) {
				stts.enemy_Damage = SW3_enDamage;
				stts.path_Damage = SW3_pfDamage;
				stts.str_Damage = SW3_seDamage;

				stts.enemy_Health = SW3_enHealth;
				stts.path_Health = SW3_pfHealth;
				stts.str_Health = SW3_seHealth;
				stts.shoot_Health = SW3_stHealth;

				stts.enemy_Speed = SW3_enSpeed;
				stts.path_Speed = SW3_pfSpeed;
				stts.str_Speed = SW3_seSpeed;
				stts.shoot_Speed = SW3_stSpeed;
			}
		}

		if (player_Count == 2) {
			if (wave_Count == 1) {
				stts.enemy_Damage = MW1_enDamage;
				stts.path_Damage = MW1_pfDamage;
				stts.str_Damage = MW1_seDamage;

				stts.enemy_Health = MW1_enHealth;
				stts.path_Health = MW1_pfHealth;
				stts.str_Health = MW1_seHealth;
				stts.shoot_Health = MW1_stHealth;

				stts.enemy_Speed = MW1_enSpeed;
				stts.path_Speed = MW1_pfSpeed;
				stts.str_Speed = MW1_seSpeed;
				stts.shoot_Speed = MW1_stSpeed;
			}

			if (wave_Count == 2) {
				stts.enemy_Damage = MW2_enDamage;
				stts.path_Damage = MW2_pfDamage;
				stts.str_Damage = MW2_seDamage;

				stts.enemy_Health = MW2_enHealth;
				stts.path_Health = MW2_pfHealth;
				stts.str_Health = MW2_seHealth;
				stts.shoot_Health = MW2_stHealth;

				stts.enemy_Speed = MW2_enSpeed;
				stts.path_Speed = MW2_pfSpeed;
				stts.str_Speed = MW2_seSpeed;
				stts.shoot_Speed = MW2_stSpeed;
			}

			if (wave_Count == 3) {
				stts.enemy_Damage = MW3_enDamage;
				stts.path_Damage = MW3_pfDamage;
				stts.str_Damage = MW3_seDamage;

				stts.enemy_Health = MW3_enHealth;
				stts.path_Health = MW3_pfHealth;
				stts.str_Health = MW3_seHealth;
				stts.shoot_Health = MW3_stHealth;

				stts.enemy_Speed = MW3_enSpeed;
				stts.path_Speed = MW3_pfSpeed;
				stts.str_Speed = MW3_seSpeed;
				stts.shoot_Speed = MW3_stSpeed;
			}
		}
	}
}
