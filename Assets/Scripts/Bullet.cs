using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

    public float speed;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		this.transform.localPosition += Vector3.right * Time.deltaTime * speed;
	}



	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("other.gameObject.layer: " + other.gameObject.layer);

		if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			Debug.Log ("destroy bullet :"+ other.gameObject.name + " "+other.gameObject.layer);

			other.gameObject.GetComponent<Enemy> ().OnHit();

			DestroyObject (this.gameObject);
		}
	}
}
