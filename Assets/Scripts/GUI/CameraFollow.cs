using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform mainChar;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = this.transform.position - mainChar.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if(mainChar != null)
			this.transform.position = Vector3.right*(mainChar.position.x + offset.x) + Vector3.up*(offset.y + mainChar.position.y) + Vector3.forward*offset.z;
	}
}
