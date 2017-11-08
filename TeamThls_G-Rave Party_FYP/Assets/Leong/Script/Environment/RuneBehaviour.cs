using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBehaviour : MonoBehaviour {

	[SerializeField] List <GameObject> levels;
	[SerializeField] int currentRandomNumber;
	[SerializeField] float timeToMove;
	[SerializeField] float timeForStationary;
	[SerializeField] GameObject rune_Obj;
	[SerializeField] ParticleSystem rune_Molecule;

	[SerializeField] bool startTime;

	// Use this for initialization
	void Start () 
	{
		startTime = true;
		if(rune_Obj == null)
		{
			rune_Obj = transform.GetChild(9).gameObject;
		}
		for (int i = 0; i < 9; i++)
		{
			levels.Add(transform.GetChild(i).gameObject);
		}
		RandomizeNumber();
		rune_Molecule = rune_Obj.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(startTime == true)
		{
			timeForStationary += Time.deltaTime;
			/*if(rune_Molecule.isStopped == true)
			{
				rune_Molecule.Play();
			}*/

			if(timeForStationary > timeToMove)
			{
				timeForStationary = 0.0f;
				startTime = false;
			}
		}
		else
		{
			/*if(rune_Molecule.isStopped == false)
			{
				rune_Molecule.Stop();
			}*/
			rune_Obj.transform.position = Vector2.MoveTowards (rune_Obj.transform.position, levels[currentRandomNumber].transform.position, Mathf.Lerp (0.01f, 0.25f, 0.25f));
			if(rune_Obj.transform.position == levels[currentRandomNumber].transform.position)
			{
				RandomizeNumber();
				startTime = true;

			}
		}
	}

	void RandomizeNumber()
	{
		currentRandomNumber = Random.Range (0, 9);
	}

}
