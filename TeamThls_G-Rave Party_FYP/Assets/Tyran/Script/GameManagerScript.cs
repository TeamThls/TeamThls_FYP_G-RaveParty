
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{


	// Use this for initialization



	public int numOfSamples = 8192; //Min: 64, Max: 8192

	public AudioSource   aSource;

	public float[] freqData;
	public float[] band;

	public GameObject[] spawner;
	public GameObject spawnpoint;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;
	public GameObject spawn5;
	public GameObject spawn6;
	public GameObject spawn7;
	public GameObject spawn8;
	public GameObject spawn9;

	public int score_singleplayer;
	public int score_multiplayer;

	void Start ()
	{
		SoundManagerScript.Instance.PlayBGM (AudioClipID.BGM_PHRASE);
		freqData = new float[numOfSamples];

		int n  = freqData.Length;

		// checks n is a power of 2 in 2's complement format
		if ((n & (n - 1)) != 0) 
		{
			Debug.LogError ("freqData length " + n + " is not a power of 2!!! Min: 64, Max: 8192.");        
			return;
		}

		int k = 0;
		for(int j = 0; j < freqData.Length; j++)
		{
			n = n / 2;
			if(n <= 0) break;
			k++;
		}

		band  = new float[k-1];
		spawner     = new GameObject[k-1];

		int o = 1;
		for (int i = 0; i < band.Length; i++) 
		{
			band [i] = 0;
			spawner [i] = GameObject.Instantiate (spawnpoint);

			/*spawner [i].transform.position = new Vector3 ((i-7+(i)/3) , -6 + o*3, -5);
				if (o >= 3) 
				{
					o=1;
				}
				else if (o < 3) 
				{
					o++;
				}*/
		}
		spawner [0].transform.position = new Vector3 (-20 ,0, 0);
		spawner [0].SetActive (false);
		spawner [1].transform.position = new Vector3 (-20 ,5, 0);
		spawner [1].SetActive (false);
		spawner [2].transform.position = new Vector3 (-20 ,10, 0);
		spawner [2].SetActive (false);

		/*
		spawner [3].transform.position = new Vector3 (-10 ,-5, 0);
		spawner [4].transform.position = new Vector3 (0 ,-5, 0);
		spawner [5].transform.position = new Vector3 (10 ,-5, 0);
		spawner [6].transform.position = new Vector3 (-10 ,0, 0);
		spawner [7].transform.position = new Vector3 (0 ,0, 0);
		spawner [8].transform.position = new Vector3 (10 ,0, 0);
		spawner [9].transform.position = new Vector3 (-10 ,5, 0);
		spawner [10].transform.position = new Vector3 (0 ,5, 0);
		spawner [11].transform.position = new Vector3 (10,5, 0);*/

		spawner [3].transform.parent = spawn1.transform;
		spawner [3].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [4].transform.parent = spawn2.transform;
		spawner [4].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [5].transform.parent = spawn3.transform;
		spawner [5].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [6].transform.parent = spawn4.transform;
		spawner [6].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [7].transform.parent = spawn5.transform;
		spawner [7].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [8].transform.parent = spawn6.transform;
		spawner [8].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [9].transform.parent = spawn7.transform;
		spawner [9].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [10].transform.parent = spawn8.transform;
		spawner [10].transform.localPosition = new Vector3 (0 ,0, -5);
		spawner [11].transform.parent = spawn9.transform;
		spawner [11].transform.localPosition = new Vector3 (0 ,0, -5);

		InvokeRepeating("check", 0.0f, 4.0f); // update at 15 fps
		InvokeRepeating("spawncontrol", 0.0f, 1.0f/15.0f);

	}

	private void spawncontrol()
	{
		int k = 0;
		for (int i = 0; i < freqData.Length; i++) 
		{
			float d = freqData[i];
			float b = band[k];
			band[k] = ( d > b )? d : b;
			Vector3 tmp = new Vector3 (band [k] * 2, band [k] * 2, band [k] * 2);
			spawner [k].transform.localScale = tmp;
			band[k] = 0;
			k++;
		}
	}

	private void check()
	{
		aSource.GetOutputData(freqData, 0/*, FFTWindow.Rectangular*/);

		int k = 0;
		int crossover = 4;

		for (int i = 0; i < freqData.Length; i++)
		{
			float d = freqData[i];
			float b = band[k];

			// find the max as the peak value in that frequency band.
			band[k] = ( d > b )? d : b;

			if (i > (crossover-2) )
			{
				crossover *= 2;   // frequency crossover point for each band.



				if (band [k]*2 >= 1.7f) 
				{
					spawner[k].GetComponent<SpawnBehaviour>().Spawn();
				}
				else if (band [11]*2 >= 1.6f && band [11]*2 < 1.7f  ) 
				{
					spawner[3].GetComponent<SpawnBehaviour>().Spawn();
					spawner[4].GetComponent<SpawnBehaviour>().Spawn();
					spawner[5].GetComponent<SpawnBehaviour>().Spawn();
				}
				else if (band [11]*2 >= 1.5f && band [11]*2 < 1.6f  ) 
				{
					spawner[6].GetComponent<SpawnBehaviour>().Spawn();
					spawner[7].GetComponent<SpawnBehaviour>().Spawn();
					spawner[8].GetComponent<SpawnBehaviour>().Spawn();
				}
				else if (band [11]*2 >= 1.4f && band [11]*2 < 1.5f  ) 
				{
					spawner[3].GetComponent<SpawnBehaviour>().Spawn();
					spawner[5].GetComponent<SpawnBehaviour>().Spawn();
					spawner[7].GetComponent<SpawnBehaviour>().Spawn();
					spawner[9].GetComponent<SpawnBehaviour>().Spawn();
				}
				else if (band [11]*2 > 1.3f && band [11]*2 < 1.4f  ) 
				{
					spawner[4].GetComponent<SpawnBehaviour>().Spawn();
					spawner[6].GetComponent<SpawnBehaviour>().Spawn();
					spawner[8].GetComponent<SpawnBehaviour>().Spawn();
					spawner[10].GetComponent<SpawnBehaviour>().Spawn();
				}
				else if (band [k]*2 <= 1.3f) 
				{
					int r = Random.Range (3, 11);
					spawner[r].GetComponent<SpawnBehaviour>().Spawn();
				}

				band[k] = 0;
				k++;

			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		/*AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 1; i < spectrum.Length - 1; i++) 
		{
			
		}*/
	}
}