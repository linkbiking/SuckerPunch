using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
     Rigidbody rigi;
    public static Coin Instance;
    void start()
    {
        rigi = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            
            case "Player":
             Destroy(gameObject);
                break;
            case "Ground":
                if(this !=null)
                rigi.useGravity = false;
                break;
        }
    }
    
        
      
    
}
