using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public bool isSpawning;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public int r;
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
		//Instantiate (enemy2, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);	
		//InvokeRepeating("actualspawn", 0.0f, 10.0f);
		r = Random.Range (1, 4);
		Debug.Log (r);
		if (r == 1)
		{
			
			Instantiate (enemy1, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}
		else if (r == 2)
		{

			Instantiate (enemy2, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}
		else if (r == 3)
		{

			Instantiate (enemy3, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}

	}


}
