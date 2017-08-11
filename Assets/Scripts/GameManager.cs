using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject gui_gameOver_group;

    public GameObject gui_win_group;

	public GameObject effectGroup;

	public GameObject enemyDieEffectPrefab;

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);
        
        gui_gameOver_group.SetActive(false);
        gui_win_group.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GameOver()
    {
        Debug.Log("GameOver");
        gui_gameOver_group.SetActive(true);
        gui_win_group.SetActive(false);
        
    }

    public TweenPosition tweenWin1;
    public void Win()
    {
        Debug.Log("Win");

		if (tweenWin1) {
			tweenWin1.enabled = true;
			tweenWin1.Play (true);
			Invoke ("OnGuiWin", tweenWin1.duration + 0.5f);
		} else {
			Invoke ("OnGuiWin", 0.5f);
		}
        
        

    }

    private void OnGuiWin()
    {
        gui_win_group.SetActive(true);
        gui_gameOver_group.SetActive(false);
    }
    public void Replay()
    {
        Application.LoadLevel(0);
    }

	public void OnCreateEffectEnemyDie(Transform e_pos)
	{
		if (effectGroup && enemyDieEffectPrefab) {

			GameObject die = (GameObject)NGUITools.AddChild(this.effectGroup, enemyDieEffectPrefab);
			die.transform.position = e_pos.position;
		}
	}



}
