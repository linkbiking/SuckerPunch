using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Duration : MonoBehaviour {
    public Text timerText;
    public float min,sec;
    public static int minutes = 2, msec =30;
   	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>() as Text;
       
	}
	
	// Update is called once per frame
	void Update () {
        
        min = (int)(minutes - Time.time/60f);
        sec = (int)( 60- Time.time % 60);

       timerText.text = min.ToString("0") + ":" + sec.ToString("00");
       
	}
   
}
