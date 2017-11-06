using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLightingEffects : MonoBehaviour {

	[SerializeField] List<Light> lights;
	[SerializeField] Color[] colors_Array = new Color[8];

	public int randomNumber;
	public float value;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < this.transform.childCount; i++)
		{
			for (int j = 0; j < transform.GetChild(i).childCount; j++)
			{
				lights.Add(transform.GetChild(i).GetChild(j).GetComponent<Light>());
			}
		}
		colors_Array[0] = Color.blue;
		colors_Array[1] = Color.cyan;
		colors_Array[2] = Color.gray;
		colors_Array[3] = Color.green;
		colors_Array[4] = Color.magenta;
		colors_Array[5] = Color.red;
		colors_Array[6] = Color.yellow;
		colors_Array[7] = Color.white;
		//Debug.Log( colors_Array.Length);
	}

	
	// Update is called once per frame
	void Update () 
	{
		LightSwitchingColor();
	}

	void RandomizeLightColors()
	{
		randomNumber = Random.Range(0, colors_Array.Length);
	}

	void LightSwitchingColor()
	{
		for(int i = 0; i < lights.Count; i++)
		{
			if(lights[i].color == colors_Array[randomNumber])
			{
				RandomizeLightColors();
				value = 0.0f;
				//lights[i].color = Color.Lerp(lights[i].color, colors_Array[randomNumber], value);
			}
			else
			{
				value += Time.deltaTime / 50;
				lights[i].color = Color.Lerp(lights[i].color, colors_Array[randomNumber], value);
			}
		}
	}
}
