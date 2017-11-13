using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLightingEffects : MonoBehaviour {

	[SerializeField] Color[] colors_Array = new Color[8];
	Light lightComp;

	public int randomNumber;
	[SerializeField] float lightFrequency;
	public float value;

	// Use this for initialization
	void Start () 
	{
		lightFrequency = 25;
		lightComp = GetComponent<Light>();
		colors_Array[0] = Color.blue;
		colors_Array[1] = Color.cyan;
		colors_Array[2] = Color.gray;
		colors_Array[3] = Color.green;
		colors_Array[4] = Color.magenta;
		colors_Array[5] = Color.red;
		colors_Array[6] = Color.yellow;
		colors_Array[7] = Color.white;
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
		if(lightComp.color == colors_Array[randomNumber])
		{
			RandomizeLightColors();
			value = 0.0f;

		}
		else
		{
			value += Time.deltaTime / lightFrequency;
			lightComp.color = Color.Lerp(lightComp.color, colors_Array[randomNumber], value);
		}
	}
}
