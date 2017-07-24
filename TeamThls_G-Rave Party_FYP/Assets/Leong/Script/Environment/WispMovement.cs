using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispMovement : MonoBehaviour {

	public Vector2 target;
	public Vector2 self;
	float timer; 
	int sec;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(Movement(0.5f));
	}

	IEnumerator Movement(float updateTime)
	{
		yield return new WaitForSeconds(updateTime);
		target.x = UnityEngine.Random.insideUnitCircle.x + transform.position.x;
		target.y = UnityEngine.Random.insideUnitCircle.y + transform.position.y;
		transform.position = target;
	}

}
