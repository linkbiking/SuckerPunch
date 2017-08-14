using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public static Coin Instance;
    void Awake()
    {
        Instance = this;
    }
    
   void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
        {
           
            Destroy(gameObject);
           
        }

    }
 
}
