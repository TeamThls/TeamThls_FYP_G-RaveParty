using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncSystem : MonoBehaviour {

	Transform player1, player2;
	LineRenderer lineRen;

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

	[SerializeField] float lightning_UpdateTime;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player").transform;
		player2 = GameObject.Find("Player2").transform;
		lineRen = GetComponent<LineRenderer>();
		//line = this.transform;
		StartCoroutine(Beam());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = (player1.position + player2.position) / 2.0f ;

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

		StartCoroutine(Beam());
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
