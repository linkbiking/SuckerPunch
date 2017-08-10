using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    public enum PLAYER_STATE
    {
        READY,
        DEATH,
        NORMAL,
        RUN,
        JUMP,
        DOUBLE_JUMP,
        FALL,
        STOP,

    }

    public enum RAGE_STATE
    {
        LOW,
        MEDIUM,
        HIGH
    }

    #region Properties
    public float JUMP_FORCE;

    public float NORMAL_SPEED;

    public float JUMP_SPEED;

    public PLAYER_STATE m_state
    {
        get
        {
            return _state;
        }

        set
        {
            m_pre_state = _state;
            _state = value;
        }
    }

    private PLAYER_STATE _state = PLAYER_STATE.READY;
    public PLAYER_STATE m_pre_state = PLAYER_STATE.READY;

    public RAGE_STATE m_rage_state = RAGE_STATE.LOW;

    public RAGE_STATE rage_state
    {
        get { return m_rage_state; }
        set
        {
            m_rage_state = value;

            ChangeRageState(value);
        }
    }

    public Animator animator;
    public GameObject Player;
    public GameObject sword;
    public GameObject gun;

    public GameObject spawnBullet;

    public GameObject bulletPrefab;
    public Transform coin;
    public Transform obstacle;
    public Transform endpoint;
    private float map_x;
    public GameObject[] block;
	public bool isRun = true;

    private Rigidbody m_rigidbody;
    private float m_speed;

    private float scale_speed_state = 1;
    #endregion

    #region MonoBehavirour call backs


    void Awake()
    {
        Instance = this;
        //call  obstacle len map A thang
        Instantiate(obstacle, new Vector3(14, 2, 0), Quaternion.identity);
    }

    // Use this for initialization
    void Start()
    {
        if (m_rigidbody == null)
            m_rigidbody = this.GetComponent<Rigidbody>();

        TurnOffSword();
        TurnOffGun();
        Player = GameObject.Find("Player");
        callCoin();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Make jump.
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log("Jump");
        //    JumpProcess();
        //}

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("velo: " + m_rigidbody.velocity);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //ChemProcess();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //FireProcess();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if(this.rage_state == RAGE_STATE.LOW)
                ChangeRageState(RAGE_STATE.MEDIUM);
            else if (this.rage_state == RAGE_STATE.MEDIUM)
                ChangeRageState(RAGE_STATE.HIGH);
            else 
                ChangeRageState(RAGE_STATE.LOW);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //phiday();
            
            
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
           
        }
        


       
        CheckFall();
        //run
		if (m_state != PLAYER_STATE.DEATH && m_state != PLAYER_STATE.STOP && isRun)
            RunProcess();
    
        
    }
    // instance random 0-20 coin cho  moi 1 block ( block is  ground ) A Thang
    void callCoin()
    {
      float  xcoin = Random.Range(0,7);
      for (int i=0;i <xcoin; i++)
        {
            c_call();
        }
    }
    void c_call()
    {
        float xpos = Random.Range(-3,3);
        Instantiate(coin, new Vector3(block[0].transform.position.x + xpos, 2, 0), Quaternion.identity);
        Instantiate(coin, new Vector3(block[1].transform.position.x + xpos, 2, 0), Quaternion.identity);
        Instantiate(coin, new Vector3(block[2].transform.position.x + xpos, 2, 0), Quaternion.identity);
        Instantiate(coin, new Vector3(block[3].transform.position.x + xpos, 2, 0), Quaternion.identity);
        Instantiate(coin, new Vector3(block[4].transform.position.x + xpos, 2, 0), Quaternion.identity);
    }
      
       
   
    private void CheckFall()
    {
        if (this.m_rigidbody.velocity.y < -1)
        {
            m_state = PLAYER_STATE.FALL;
            this.animator.SetBool("Fall",true);
            this.animator.SetBool("Jump", false);
            
            // this.animator.Play("Fall");
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.transform.tag)
        {
            case "Ground":
                this.m_state = PLAYER_STATE.RUN;
                if (animator)
                {
                    animator.SetBool("Jump", false);
                    animator.Play("Run");
                }
                break;
            case "WinGate":
                this.m_state = PLAYER_STATE.STOP;
                PlayerWinProcess();
                break;
		case "DeathBox":
			this.m_state = PLAYER_STATE.DEATH;
			Debug.Log ("Death: " + this.name + " and with: " + other.gameObject.name);
                PlayerDeathProcess();
                break;
           
        }

    }

    #endregion

    #region Private Method

    public void JumpProcess()
    {
        if (m_state != PLAYER_STATE.DEATH && m_state != PLAYER_STATE.STOP && m_state != PLAYER_STATE.DOUBLE_JUMP )
        {

            m_rigidbody.velocity += Vector3.up * JUMP_FORCE;
            if (this.m_state == PLAYER_STATE.JUMP)
            {
                this.m_state = PLAYER_STATE.DOUBLE_JUMP;
                if (animator)
                {
                    animator.SetTrigger("DoubleJump");
                    animator.SetBool("Fall", false);
                    //animator.Play("Jump");
                    Debug.Log("ANIM DouobleJUMP");
                }
            }
            else if(m_state != PLAYER_STATE.DOUBLE_JUMP || m_state != PLAYER_STATE.FALL)
            {
                this.m_state = PLAYER_STATE.JUMP;
                if (animator)
                {
                    animator.SetBool("Jump", true);
                    animator.SetBool("Fall", false);
                    //animator.SetTrigger("DoubleJump");
                    //animator.Play("Jump");
                    Debug.Log("ANIM JUMP");
                }
            }

        }

    }
   

    public void ChemProcess()
    {
        if (animator)
            animator.Play("chem1", -1, 0f);

        TurnOnSword();

        Invoke("TurnOffSword", 0.5f);
    }



    public void FireProcess()
    {
        if (animator)
            animator.Play("shot1");

        
        TurnOnGun();
		Invoke("SpawnBullet", 0.02f);
        Invoke("TurnOffGun", 0.6f);


    }

	public void SpawnBullet()
	{
		GameObject go = NGUITools.AddChild(spawnBullet, bulletPrefab);
		go.SetActive(true);

		go.transform.position = Vector3.right* (this.transform.position.x + 0.2f)  + Vector3.up*gun.transform.position.y;
	}

    private void RunProcess()
    {
        if (this.m_state == PLAYER_STATE.NORMAL || this.m_state == PLAYER_STATE.RUN)
            m_speed = NORMAL_SPEED * scale_speed_state;
        else if (this.m_state == PLAYER_STATE.JUMP)
            m_speed = JUMP_SPEED * scale_speed_state;

        transform.position += Vector3.right * m_speed * scale_speed_state * Time.deltaTime;
    }

    private void PlayerDeathProcess()
    {
        Debug.Log("PlayerDeath");
        GameManager.Instance.GameOver();
    }

    public void TurnOnSword()
    {
        if (sword)
            sword.SetActive(true);
    }


    public void TurnOffSword()
    {
        if (sword)
            sword.SetActive(false);
    }

    public void TurnOnGun()
    {
        if (gun)
            gun.SetActive(true);
    }


    public void TurnOffGun()
    {
        if (gun)
            gun.SetActive(false);
    }

    public void ChangeRageState(RAGE_STATE newState)
    {
        switch (newState)
        {
            case RAGE_STATE.LOW:
                SetupLowState();
                break;
            case RAGE_STATE.MEDIUM:
                SetupMediumState();
                break;
            case RAGE_STATE.HIGH:
                SetupHighState();
                break;
        }
    }
    private void PlayerWinProcess()
    {
        Debug.Log("Player Win");
        GameManager.Instance.Win();
    }

    private void SetupLowState()
    {
        scale_speed_state = 1;
    }
    private void SetupMediumState()
    {
        scale_speed_state = 2;
    }
    private void SetupHighState()
    {
        scale_speed_state = 3;
    }

	public void Fire()
	{
		FireProcess ();
	}
    
    
    #endregion
}
