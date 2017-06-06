using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour 
{

	private static LoadingSceneManager _instance;

	public static LoadingSceneManager Instance
	{
		get 
		{
			if (_instance == null) 
			{
				_instance = GameObject.Find ("LoadingSceneManager").GetComponent<LoadingSceneManager>();

			}

			return _instance;	
		}

		set { }
	}



	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadingScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);

	}


}
