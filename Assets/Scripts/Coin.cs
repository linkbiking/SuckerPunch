using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public static Coin Instance;
    public static float c_distance;
    void Awake()
    {
        Instance = this;
    }
    
    void Update()
    {
      if (this != null)
        {
            c_distance = Vector3.Distance(PlayerController.Player.transform.position, this.transform.position);
          
        }
      // neu xu cach Player < 2 thi xoa xu 
        if (c_distance <2)
        {
            Destroy(gameObject);
        }
    }
 
}
