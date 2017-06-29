using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public bool isSpawning;
	public GameObject enemy;
	//public GameObject zeroObj;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Spawn()
	{
		//InvokeRepeating("actualspawn", 0.0f, 10.0f);
		Instantiate(enemy, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
	}


}
