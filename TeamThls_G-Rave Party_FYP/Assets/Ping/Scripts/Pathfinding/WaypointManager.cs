using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaypointManager : MonoBehaviour {

	public List<GameObject> childList;
	public GameObject manager;
	public GameObject MinChild;

	// Use this for initialization
	void Awake () {
		GetChild();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GetChild ()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			GameObject wp = transform.GetChild(i).gameObject;
			childList.Add(wp);
		}
	}
}
