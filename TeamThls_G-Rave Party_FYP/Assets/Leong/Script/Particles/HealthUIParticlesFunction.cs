using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIParticlesFunction : MonoBehaviour {

	[SerializeField] Transform healthUI_ObjPos;
	// Use this for initialization
	void Start () {
		if(healthUI_ObjPos == null)
		{
			healthUI_ObjPos = GameObject.Find("HealthUIObjectPos").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, healthUI_ObjPos.transform.position, Mathf.Lerp(0.15f, 1.0f, 0.15f));
		if(transform.position == healthUI_ObjPos.transform.position)
		{
			GetComponent<ParticleSystem>().Stop();
		}
	}
}
