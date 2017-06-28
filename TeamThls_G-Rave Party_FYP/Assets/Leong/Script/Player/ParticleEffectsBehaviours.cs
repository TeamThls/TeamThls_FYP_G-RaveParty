using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsBehaviours : MonoBehaviour {

	// This Script is shared among the particles who have the same functionalities such as auto-destruct after stopped
	ParticleSystem sharedParticles;
	// Use this for initialization
	void Start () {
		sharedParticles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(sharedParticles.isStopped == true)
		{
			Destroy(this.gameObject);
		}
	}
}
