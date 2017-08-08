using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessChem : MonoBehaviour
{
    public PlayerController _controller;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other.gameObject.layer: " + other.gameObject.layer);

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _controller.ChemProcess();
        }
    }
}
