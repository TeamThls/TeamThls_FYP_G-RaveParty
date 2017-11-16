using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlashingRedEffect : MonoBehaviour {

	[SerializeField] Image image_Red;
	public bool isEnable = false;
	
	// Use this for initialization
	void Start () {
		image_Red = GameObject.Find("RedImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ScreenFlash(float duration)
	{
		var alpha = image_Red.color.a;
		alpha = Mathf.Lerp(alpha, 0.2f, 1.0f);
		image_Red.color = new Color (1.0f, 0.0f, 0.0f, alpha);

		yield return new WaitForSeconds(duration);

		alpha = Mathf.Lerp(alpha, 0.0f, 1.0f);
		image_Red.color = new Color (1.0f, 0.0f, 0.0f, alpha);	

	}

	/*public IEnumerator ScreenRed()
	{
		var alpha = image_Red.color.a;
		alpha = 0.0f;
		if(alpha == 0.0f)
		{
			alpha = 0.2f;
			image_Red.color = new Color(1.0f, 0.0f, 0.0f, alpha);
		}
		for(float i = 0.2f; i < 0.3f; i -= Time.deltaTime / 5.0f)
		{
			yield return new WaitForSeconds(0.25f);
			alpha = i;
			image_Red.color = new Color(1.0f, 0.0f, 0.0f, i);
		}
		if(alpha < 0.0f)
		{
			alpha = 0.0f;
		}
		StopAllCoroutines();


	}*/
}
