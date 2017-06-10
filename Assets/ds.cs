using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds : MonoBehaviour {
    public float delay ;
	public float roundsPerSec = 1;
	public Vector3 dir = Vector3.forward;
    private bool isRotating = false;
    // Use this for initialization
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        StartCoroutine(StartRot());
        if (isRotating)
        transform.Rotate(dir, Time.deltaTime * 30 * roundsPerSec);
        
    }
    IEnumerator StartRot()
    {
        
        isRotating = true;
        yield return new WaitForSeconds(delay-0.2f);
        isRotating = false;
        Destroy(gameObject);
        transform.rotation = Quaternion.identity;
        StopAllCoroutines();
    }
}

