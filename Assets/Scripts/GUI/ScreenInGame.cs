using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInGame : MonoBehaviour 
{
	public PlayerController playerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnClick_BtnJump()
	{
		playerController.JumpProcess();

		Debug.Log ("OnClick Jump");
	}

	public void OnClick_BtnSkill1()
	{

	}

	public void OnClick_Fire()
	{
		playerController.Fire ();
	}

}
