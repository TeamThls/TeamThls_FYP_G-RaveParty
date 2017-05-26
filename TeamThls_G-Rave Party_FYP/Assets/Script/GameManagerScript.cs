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

			spawner [i].transform.position = new Vector3 ((i-7+(i)/3) , -6 + o*3, -5);
				if (o >= 3) 
				{
					o=1;
				}
				else if (o < 3) 
				{
					o++;
				}
				
				
			}
		

		InvokeRepeating("check", 0.0f, 1.0f/15f); // update at 15 fps


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
				Vector3 tmp = new Vector3 (band[k]*2,band[k]*2,band[k]*2 /*spawner[k].transform.position.z*/);
				spawner[k].transform.localScale = tmp;
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
