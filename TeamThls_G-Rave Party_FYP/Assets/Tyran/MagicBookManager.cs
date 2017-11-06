using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookManager : MonoBehaviour 
{
	public float setTime = 0.0f;
	public float currTime = 0.0f;
	public int r;
	public GameObject magicSkillBook;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currTime >= setTime) 
		{
			r = Random.Range (0, 8);
			magicSkillBook.transform.parent = this.transform.GetChild (r); 
			magicSkillBook.transform.position = magicSkillBook.transform.parent.position;
			currTime = 0.0f;

		} 
		else 
		{
			currTime += Time.deltaTime;
		}
		
	}
}
