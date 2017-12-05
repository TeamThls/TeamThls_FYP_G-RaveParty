using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class ReadFolderMultiplayer : MonoBehaviour {

	public string myPath;
	FileInfo[] info;
	public List<AudioClip> clips = new List<AudioClip>();
	public List<string> names = new List<string>();
	public List<string> paths = new List<string>();
	public float vSbarValue;
	public Vector2 scrollPosition = Vector2.zero;
	public GameObject GamaManager;
	public SharedStats sharedstats;
	string mp3 = ".mp3";
	// Use this for initialization
	void Start () {
		GamaManager = GameObject.Find("GameManager");
		sharedstats = GamaManager.GetComponent<SharedStats> ();
		DirectoryInfo dir = new DirectoryInfo(Application.dataPath+"/Resources");
		info = dir.GetFiles("*.mp3"  );

		foreach (FileInfo f in info)
		{
			print(f.Name);
			print(f.ToString());
			names.Add (f.Name);
			paths.Add (f.ToString());
			//GUILayout.BeginArea(new Rect(100, 100, 1000, 100),f.Name);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height), "FREE MODE",GUI.skin.window);
		//vSbarValue = GUILayout.VerticalScrollbar(vSbarValue, 1.0F, 10.0F, 0.0F);
		//scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
		scrollPosition = GUI.BeginScrollView(new Rect(5, 30, Screen.width-10, Screen.height), scrollPosition, new Rect(0, 0, 100, Screen.height*500),false,true);
		GUILayout.BeginHorizontal();
		for (int i = 0; i<paths.Count; i++)
		{
			GUILayout.BeginArea (new Rect (10, 55*(i+1), Screen.width - 50, 50), names[i],GUI.skin.window);
			GUILayout.BeginHorizontal();
			GUILayout.Label(names[i]);
			GUILayout.FlexibleSpace();
			if (GUILayout.Button ("Select", GUILayout.Width (50))) 
			{
				sharedstats.newpath = names [i].Replace (mp3, "");
				//Debug.Log ("HERE"+sharedstats.newpath);
				SceneManager.LoadScene ("Free Instructions 2");
				//SoundManagerScript.Instance.ChangeClip (f.Name);
				//SoundManagerScript.Instance.PlayBGM (AudioClipID.BGM_LEVEL);
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		/*foreach (FileInfo f in info)
		{
			GUILayout.BeginArea (new Rect (10, 25, Screen.width - 50, 100), f.Name,GUI.skin.window);
			if (GUILayout.Button ("Select", GUILayout.Width (50))) 
			{
				//SoundManagerScript.Instance.ChangeClip (paths [0]);
				SoundManagerScript.Instance.ChangeClip (f.Name);

				//SoundManagerScript.Instance.bgmAudioSource.Play ();
				SoundManagerScript.Instance.PlayBGM (AudioClipID.BGM_LEVEL);
			}

			GUILayout.EndArea();
		}*/
		GUILayout.FlexibleSpace();
		//vSbarValue = GUILayout.VerticalScrollbar(vSbarValue, 10.0F, 10.0F, 0.0F);

		GUILayout.EndHorizontal();


		GUI.EndScrollView();
		GUILayout.EndArea();
	}
}
