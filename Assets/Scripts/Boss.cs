using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public static Boss Instance;
    public Transform Player_tran;
    private float dist;
    private Animator anim;
    private bool isWalking = false;
	// Use this for initialization
	void Start () {
       
        anim = GetComponent<Animator>();
	}
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Space();
        come();
        if(isWalking == true)
        {
            transform.position -= Vector3.right * 1.5f * Time.deltaTime;
            Debug.Log("WAlk1231");
        }
        if(dist <= 6)
        {
            isWalking = false;
            anim.SetBool("walk", false);
        }
    }
    void Space()
    {
        dist = Vector3.Distance(Player_tran.position, transform.position);
        
    }
    void come()
    {
        if (dist <= 15 && dist >6)
        {
            anim.Play("Walk");
            isWalking = true;
        }
        
        if(dist >13.2 && dist < 6)
        {

            isWalking = false;
        }
       
    }
   
}
