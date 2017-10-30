using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneColliderFunction : MonoBehaviour {

	[SerializeField] ParticleSystem rune_Particles;
	[SerializeField] List<ParticleSystem> rune_ChildParticles;
	SharedStats sharedStats_Script;

	public bool isAvailable;
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
	}

	void Update()
	{
		if(isAvailable == true)
		{
			for(int i = 0; i < rune_ChildParticles.Count; i++)
			{
				if(rune_ChildParticles[i].isPlaying == false)
				{
					rune_ChildParticles[i].Play();
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == 11)
		{
			if(isAvailable == true)
			{
				for(int i = 0; i < rune_ChildParticles.Count; i++)
				{
					if(rune_ChildParticles[i].isPlaying == true)
					{
						rune_ChildParticles[i].Stop();
						isAvailable = false;
						RandomizeEffect();
					}
				}
			}
			Destroy(col.gameObject);
		}
	}

	void RandomizeEffect()
	{
		int randomizeNumber = Random.Range(0, 3);
		switch(randomizeNumber)
		{
			case 1:
				sharedStats_Script.player_Health += 50;
				if(sharedStats_Script.player_Health > sharedStats_Script.player_MaxHealth)
				{
					sharedStats_Script.player_Health = sharedStats_Script.player_MaxHealth;
				}
				Debug.Log("Healing");
				break;

			case 2:
				sharedStats_Script.player_Mana += 50;
				if(sharedStats_Script.player_Mana > sharedStats_Script.player_MaxMana)
				{
					sharedStats_Script.player_Mana = sharedStats_Script.player_MaxMana;
				}
				Debug.Log("Mana");	
				break;
				
		}


	}
}
