using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class InstructionMenuManager : MonoBehaviour 
{
	//public GameObject instruction1;

	public SpriteRenderer spriterendererIM;
	public Sprite instruction1;
	public Sprite instruction2;
	public Sprite instruction3;
	public Sprite controlscheme;


	public string nextScene;
	public int arrowchange = 1;
	private string scene;
	private bool m_isAxisInUseP1 = false;
	private bool m_isAxisInUseP2 = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (arrowchange < 1) 
		{
			arrowchange = 1;
		}
		if (arrowchange > 4) 
		{
			arrowchange = 4;
		}

		/*foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}*/

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)  ) 
		{
			arrowchange--;
		}
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow) ) 
		{
			arrowchange++;
		}



		if( Input.GetAxisRaw("HorizontalP1") == 1 )
		{
			if(m_isAxisInUseP1 == false)
			{
				// Call your event function here
				arrowchange++;
				m_isAxisInUseP1 = true;
			}
		}
		if( Input.GetAxisRaw("HorizontalP1") == 0)
		{
			m_isAxisInUseP1 = false;
		}

		if( Input.GetAxisRaw("HorizontalP1") == -1 )
		{
			if(m_isAxisInUseP1 == false)
			{
				// Call your event function here
				arrowchange--;

				m_isAxisInUseP1 = true;
			}
		}
		if( Input.GetAxisRaw("HorizontalP1") == 0)
		{
			m_isAxisInUseP2 = false;
		}


		if( Input.GetAxisRaw("HorizontalP2") == 1 )
		{
			if(m_isAxisInUseP2 == false)
			{
				// Call your event function here
				arrowchange++;

				m_isAxisInUseP2 = true;
			}
		}
		if( Input.GetAxisRaw("HorizontalP2") == 0)
		{
			m_isAxisInUseP2 = false;
		}

		if( Input.GetAxisRaw("HorizontalP2") == -1 )
		{
			if(m_isAxisInUseP2 == false)
			{
				// Call your event function here
				arrowchange--;

				m_isAxisInUseP2 = true;
			}
		}
		if( Input.GetAxisRaw("HorizontalP2") == 0)
		{
			m_isAxisInUseP2 = false;
		}






		if (arrowchange == 1) 
		{
			spriterendererIM.sprite = instruction1;
		}
		else if (arrowchange == 2) 
		{
			spriterendererIM.sprite = instruction2;
		}
		else if (arrowchange == 3) 
		{
			spriterendererIM.sprite = instruction3;
		}
		else if (arrowchange == 4) 
		{
			spriterendererIM.sprite = controlscheme;
		}
		else if (arrowchange == 5) 
		{
			ChangeScene (nextScene);
		}








		    


	}

	public void ChangeScene (string sceneName)
	{
		//SoundManagerScript.Instance.PlaySFX (AudioClipID.SFX_BUTTONPRESSED1);
		scene = sceneName;
		Invoke ("ChangeSceneDelay",0.1f);
	}

	void ChangeSceneDelay ()
	{
		SceneManager.LoadScene (scene);
	}
}


