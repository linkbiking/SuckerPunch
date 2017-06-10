using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isMove = false;

    public float speed = 1f;

    public GameObject objDie;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
            RunProcess();
    }

    private void RunProcess()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }

    private void OnDie()
    {
        /*if (objDie)
        {
            GameObject die = (GameObject)NGUITools.AddChild(this.gameObject, objDie);
			die.transform.position = this.transform.position;
			die.transform.localScale = Vector3.one;
        }*/

		GameManager.Instance.OnCreateEffectEnemyDie (this.transform);

		DestroyObject (this.gameObject);
    }

    public void OnHit()
    {
        OnDie();
    }

    private void OnCollisionEnter(Collision other)
    {
        //this.OnHit();
    }

}
