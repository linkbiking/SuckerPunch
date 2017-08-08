using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIJump : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPress(bool isPressed)
    {
        if (isPressed)
        {
            PlayerController.Instance.JumpProcess();
        }
        else
        {

        }
    }

}
