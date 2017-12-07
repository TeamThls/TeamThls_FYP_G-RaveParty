using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public bool isSpawning;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	//public int r1;
	//public int r2;
	public int r;

	public GameObject GamaManager;
	public SharedStats sharedstats;
	//public GameObject zeroObj;


	// Use this for initialization
	void Start () 
	{
		GamaManager = GameObject.Find("GameManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Spawn()
	{
		//Instantiate (enemy2, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);	
		//InvokeRepeating("actualspawn", 0.0f, 10.0f);
		//r1 = Random.Range (1, 4);
		//r2 = Random.Range (1, 5);
		//Debug.Log (r);

		r = Random.Range (1, 5);
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
		else if (r == 4) 
		{

			Instantiate (enemy4, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}


		/*if (sharedstats.wave_count == 1 || sharedstats.wave_count == 2) 
		{
			if (r1 == 1) 
			{

				Instantiate (enemy1, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			} 
			else if (r1 == 2) 
			{

				Instantiate (enemy2, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			} 
			else if (r1 == 3) 
			{

				Instantiate (enemy3, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			} 
		}
		if (sharedstats.wave_count == 3) 
		{
			if (r2 == 1) 
			{
			
				Instantiate (enemy1, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			}
			else if (r2 == 2) 
			{

				Instantiate (enemy2, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			} 
			else if (r2 == 3) 
			{

				Instantiate (enemy3, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			} 
			else if (r2 == 4) 
			{

				Instantiate (enemy4, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			}

		}*/
	}

}
