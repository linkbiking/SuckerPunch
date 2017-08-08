using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProcess : MonoBehaviour
{

    public PlayerController _conntroll;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other.gameObject.layer: " + other.gameObject.layer);

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _conntroll.Fire();
        }
    }
}
