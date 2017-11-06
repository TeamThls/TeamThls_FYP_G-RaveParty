using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneColliderFunction : MonoBehaviour {

	[SerializeField] ParticleSystem rune_Particles;
	[SerializeField] List<ParticleSystem> rune_ChildParticles;
	SharedStats sharedStats_Script;
	[SerializeField] ParticleSystem player_CircleParticles;
	[SerializeField] ParticleSystem player2_CircleParticles;

	[SerializeField] bool isAvailable;
	[SerializeField] float timeToEnableRune;
	[SerializeField] float currentTime;
	// Use this for initialization
	void Start () 
	{
		isAvailable = true;
		rune_Particles = GetComponentInParent<ParticleSystem>();

		for(int i = 0; i < rune_Particles.transform.childCount - 1; i++)
		{
			rune_ChildParticles.Add (rune_Particles.transform.GetChild(i).GetComponent<ParticleSystem>());
		}
		sharedStats_Script = GameObject.Find("GameManager").GetComponent<SharedStats>();
		player_CircleParticles = GameObject.Find("Player").transform.GetChild(7).GetComponent<ParticleSystem>();
		player2_CircleParticles = GameObject.Find("Player2").transform.GetChild(7).GetComponent<ParticleSystem>();
	}

	void Update()
	{
		if(isAvailable == true)
		{
			for(int i = 0; i < rune_ChildParticles.Count - 2; i++)
			{
				if(rune_ChildParticles[i].isPlaying == false)
				{
					rune_ChildParticles[i].Play();
				}
			}
		}
		else
		{
			for(int i = 0; i < rune_ChildParticles.Count - 2; i++)
			{
				if(rune_ChildParticles[i].isPlaying == true)
				{
					rune_ChildParticles[i].Stop();
				}
			}
			currentTime += Time.deltaTime;
			if(currentTime > timeToEnableRune)
			{
				isAvailable = true;
				currentTime = 0.0f;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 11)
		{
			RuneDamage();
			Destroy(col.gameObject);
		}
	}

	public void RuneDamage()
	{
		if(isAvailable == true)
		{
			isAvailable = false;
			player_CircleParticles.Emit(1);
			player2_CircleParticles.Emit(1);
			RandomizeEffect();
		}
		rune_ChildParticles[3].Emit(1);
	}
	void RandomizeEffect()
	{
		int randomizeNumber = Random.Range(0, 3);
		switch(randomizeNumber)
		{
			case 0:
				sharedStats_Script.player_Health += 33;
				if(sharedStats_Script.player_Health > sharedStats_Script.player_MaxHealth)
				{
					sharedStats_Script.player_Health = sharedStats_Script.player_MaxHealth;
				}
				Debug.Log("Healing");
				break;

			case 1:
				sharedStats_Script.player_Mana += 33;
				if(sharedStats_Script.player_Mana > sharedStats_Script.player_MaxMana)
				{
					sharedStats_Script.player_Mana = sharedStats_Script.player_MaxMana;
				}
				Debug.Log("Mana");	
				break;

			case 2:
				sharedStats_Script.abilityExtendedDuration = 30.0f;
				Debug.Log("Extra 30 Sec for current ability!");
				break;
		}


	}
}
