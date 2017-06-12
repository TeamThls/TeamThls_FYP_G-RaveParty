using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] float speed = 13.0f;
	[SerializeField] float time = 0.0f;
	public GameObject player;
	public PlayerMovement movementScript;
	public Transform gun;

	//[SerializeField] MeshRenderer mesh_Ren;
	[SerializeField] LineRenderer line_Ren;


	// Use this for initialization
	void Start () 
	{
		//movementScript = player.GetComponent<Movement>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
		line_Ren.widthMultiplier = Mathf.Clamp(time * 10, 1, 15);

		time += Time.deltaTime;
		if(time > 5.0f)
			Destroy(this.gameObject);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Enemy"))
		{
			col.GetComponent<EnemyCollider>().enemy_Health -= 10.0f;
			col.GetComponent<EnemyCollider>().WhitenedWhenHit();
			Destroy(this.gameObject);
		}
	}
}
