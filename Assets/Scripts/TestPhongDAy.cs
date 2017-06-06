using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhongDAy : MonoBehaviour 
{
	public GameObject day_prefab;

	public Transform pivot;

	public float    speed = 0.5f;

	public Vector3 vectorPhongDay;

	public float speedPhongDay;

	public float timePhongDay; 

	private bool dragging = false;
	private float   startAngle = 0.0f;
	private float   endAngle = 90.0f;
	private float   fTimer = 0.0f;
	private Vector3 v3T = Vector3.zero; 


	// Use this for initialization
	void Start () {
		
	}

	public enum S_TEST
	{
		s1,
		s2,
		s3,
		s4,
		auto,
	}

	private S_TEST _test_state = S_TEST.s1;



	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			_test_state = S_TEST.s2;
		}
		else if (Input.GetKeyDown (KeyCode.F2)) {
			_test_state = S_TEST.s3;
		}
		else if (Input.GetKeyDown (KeyCode.F3)) {
			_test_state = S_TEST.s4;
		}

		if (Input.GetMouseButtonDown (0)) {
			_test_state = S_TEST.s2;
		}
		if(Input.GetMouseButtonUp (0)) {
			_test_state = S_TEST.s3;
		}


		if (_test_state == S_TEST.s2 ) 
		{
			PhongDay ();
		}
		if (_test_state == S_TEST.s3 ) 
		{
			//float f = (Mathf.Sin (fTimer * speed - Mathf.PI / 2.0f) + 1.0f) / 2.0f ;
			float f = (Mathf.Sin(fTimer * speed -Mathf.PI / 2.0f)+1.0f) /2.0f;

			if (f >= 0.98) {
				SwitchS4 ();
				return;
			}
			v3T.Set (0.0f, 0.0f, Mathf.Lerp(startAngle, endAngle, f));
			pivot.eulerAngles = v3T;
			fTimer += Time.deltaTime;
		}



	}

	public void StartSkill()
	{
		_test_state = S_TEST.s2;

		Invoke ("SwitchS3", timePhongDay);

	}

	public void SwitchS3()
	{
		_test_state = S_TEST.s3;
	}

	public void SwitchS4()
	{
		_test_state = S_TEST.s4;
	}

	public void PhongDay()
	{
		pivot.transform.Translate (vectorPhongDay* speedPhongDay);

		Rigidbody r = this.GetComponent<Rigidbody> ();


	}

	public void DuDay()
	{

	}


}
