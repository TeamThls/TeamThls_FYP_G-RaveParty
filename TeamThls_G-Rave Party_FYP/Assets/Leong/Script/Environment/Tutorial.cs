using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	[SerializeField] GameObject moveTutorial, jumpTutorial, magicTutorial, firstHealthImage, SecondHealthImage;
	[SerializeField] float currentTime;
	[SerializeField] float moveTutorial_TimeToDisable = 0.0f;
	[SerializeField] float jumpTutorial_TimeToDisable = 0.0f;
	[SerializeField] float magicTutorial_TimeToDisable = 0.0f;
	[SerializeField] float healthTutorial_TimeToDisable = 0.0f;

	[SerializeField] float magic_CurrentTime;
	public bool magicBook_StartCounting;
	public bool firstTutorial;

	[SerializeField] float health_CurrentTime;
	public bool healthStand_StartCounting;
	//[SerializeField] GameObject magicBook;

	// Use this for initialization
	void Start () 
	{
		firstTutorial = true;
		magicBook_StartCounting = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(firstTutorial == true)
		{
			currentTime += Time.deltaTime;
			if(currentTime >= moveTutorial_TimeToDisable)
			{
				moveTutorial.SetActive(false);
			}
			if(currentTime >= jumpTutorial_TimeToDisable)
			{
				jumpTutorial.SetActive(false);
				firstTutorial = false;
				currentTime = 0.0f;
			}
		}

		if(magicTutorial.activeInHierarchy == true)
		{
			if(magicBook_StartCounting == true)
			{
				magic_CurrentTime += Time.deltaTime;
				if(magic_CurrentTime >= magicTutorial_TimeToDisable)
				{
					magicTutorial.SetActive(false);
					magic_CurrentTime = 0.0f;
				}
			}
		}

		if(firstHealthImage.activeInHierarchy == true ||
		   SecondHealthImage.activeInHierarchy == true)
	 		{
				if(healthStand_StartCounting == true)
				{
					health_CurrentTime += Time.deltaTime;
					if(health_CurrentTime >= healthTutorial_TimeToDisable)
					{
						firstHealthImage.SetActive(false);
						SecondHealthImage.SetActive(false);
						health_CurrentTime = 0.0f;
					}
				}
			}
		
		

	}
}
