using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncSystem : MonoBehaviour {

	Transform player1, player2;
	LineRenderer lineRen;

	[SerializeField] GameObject bullet_Obj, syncBullet_Obj;
	[SerializeField] ParticleSystem player1_SyncParticles, player2_SyncParticles;
	public GameObject currentBullet_Obj;
	Vector3[] points = new Vector3[5];

	int point_Begin = 0;
	int point_MiddleLeft = 1;
	int point_Center = 2;
	int point_MiddleRight = 3;
	int point_End = 4;

	//public Transform line;
	float random_PosOffset = 0.3f;
	float random_OffsetMax = 2.0f;
	float random_OffsetMin = 1.0f;

	[SerializeField] float distance;
	[SerializeField] float maxDistance = 15.0f;

	float lightning_UpdateTime;

	Bullet player1Bullet_Script, player2Bullet_Script;
	SceneManagement sceneManager;

	// Use this for initialization
	void Start () 
	{
		sceneManager = Camera.main.transform.GetComponentInParent<SceneManagement>();
		currentBullet_Obj = bullet_Obj;
		player1 = GameObject.Find("Player").transform;
		if(sceneManager.isSinglePlayer != true)
		{
			player2 = GameObject.Find("Player2").transform;
		}
		player1Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
		player2Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
		player1_SyncParticles = player1.GetChild(13).GetComponent<ParticleSystem>();
		if(player2 == null)
		{
			player2Bullet_Script = null;
			player2_SyncParticles = null;
		}
		else
		{
			player2_SyncParticles = player2.GetChild(13).GetComponent<ParticleSystem>();
		}
		lineRen = GetComponent<LineRenderer>();
		lightning_UpdateTime = 0.02f;

		//StartCoroutine(Beam());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player2 != null)
		{
			transform.position = (player1.position + player2.position) / 2.0f;
			distance = Vector3.Distance(player1.position, player2.position);

			if(distance < maxDistance)
			{
				if(lineRen.enabled == false)
				{
					currentBullet_Obj = syncBullet_Obj;
					player1Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
					player2Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
					player1Bullet_Script.bullet_Damage = 1.5f;
					player2Bullet_Script.bullet_Damage = 1.5f;
					lineRen.enabled = true;

				}
				if(player1_SyncParticles.isPlaying == false)
				{
					player1_SyncParticles.Play();
				}
				if(player2_SyncParticles.isPlaying == false)
				{
					player2_SyncParticles.Play();
				}
				StartCoroutine(Beam());
			}
			else
			{
				if(lineRen.enabled == true)
				{
					currentBullet_Obj = bullet_Obj;
					player1Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
					player2Bullet_Script = currentBullet_Obj.GetComponent<Bullet>();
					player1Bullet_Script.bullet_Damage = 1.0f;
					player2Bullet_Script.bullet_Damage = 1.0f;
					lineRen.enabled = false;

				}
				if(player1_SyncParticles.isPlaying == true)
				{
					player1_SyncParticles.Stop();
				}
				if(player2_SyncParticles.isPlaying == true)
				{
					player2_SyncParticles.Stop();
				}
				StopCoroutine(Beam());

			}
		}

	}

	// Double Check the Begin Point and End Point
	IEnumerator Beam()
	{
		yield return new WaitForSeconds(lightning_UpdateTime);
		points[point_Begin] = player2.position;
		points[point_End] = player1.position;
		CalculateMiddle();
		lineRen.SetPositions(points);
		lineRen.startWidth = RandomWidthOffset();
		lineRen.endWidth = RandomWidthOffset();

		//StartCoroutine(Beam());
	}


	private float RandomWidthOffset()
	{
		return Random.Range(random_OffsetMin, random_OffsetMax);
	}

	private void CalculateMiddle()
	{
		Vector3 center = RandomMiddle(player2.position, player1.position);	

		points[point_Center] = center;
		points[point_MiddleLeft] = RandomMiddle(player2.position, center);
		points[point_MiddleRight] = RandomMiddle(center, player1.position);
	}

	private Vector3 RandomMiddle(Vector3 point1, Vector3 point2)
	{
		float x = (point1.x + point2.x) / point_Center;
		float finalX = Random.Range(x - random_PosOffset, x + random_PosOffset);
		float y = (point1.y + point2.y) / point_Center;
		float finalY = Random.Range(y - random_PosOffset, y + random_PosOffset);
		return new Vector3(finalX, finalY, 0);

	}
}
