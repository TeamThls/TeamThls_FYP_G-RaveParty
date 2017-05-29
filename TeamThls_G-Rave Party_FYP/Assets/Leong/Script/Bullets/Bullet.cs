using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] float speed = 13.0f;
	[SerializeField] float time = 0.0f;
	public GameObject player;
	public Movement movementScript;
	public Transform gun;

	[SerializeField] MeshRenderer mesh_Ren;

	// Use this for initialization
	void Start () 
	{
		//movementScript = player.GetComponent<Movement>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);

		time += Time.deltaTime;
		if(time > 3.0f)
			this.gameObject.SetActive(false);

	}
}
