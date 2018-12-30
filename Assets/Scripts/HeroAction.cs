using CharAction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAction : MonoBehaviour,ICharAction {

    Animator anim;
    //public float Speedx { get; set; }
    float maxXSpeed;
    float maxYSpeed;
    private float speedXInRate;
    private float speedXDeRate;

    private float minXspeed;
    private float minYspeed;
    public float Speedy{get;set; }

    HeroStatus hs;

    bool jump;
    bool ground;

    //
    bool firable;
    float fireTimer;
    float fireCooldown;
    //jump timer & time
    private float jumpTimer;
    private float jumpTime;
    public Collider2D JumpCol;

    public SpeedStruct XSpeed
    {
        get;
        set;
    }

    public SpeedStruct YSpeed
    {
        get;
        set;
    }

    private float speedYInRate;
    private float speedYDeRate;

    [SerializeField]
    GameObject Fireball;

    

    

    // Use this for initialization
    void Start () {
        jumpTime = 0.3f;
        jumpTimer = 0;
        //speed of x direction
        maxXSpeed = 3f;
        minXspeed = 0f;
        speedXInRate = 3.0f;
        speedXDeRate = 3.0f;
        //speed of y direction
        maxYSpeed = 20f;
        minYspeed = -Mathf.Infinity;
        speedYInRate = 200.0f;
        speedYDeRate = 10.0f;

        jump = false;
        ground = true;

        firable = true;
        fireCooldown =1f;
        fireTimer= fireCooldown;
        
        XSpeed = new SpeedStruct(0, speedXInRate, speedXDeRate,maxXSpeed,minXspeed);   
        YSpeed = new SpeedStruct(0,speedYInRate,speedYDeRate,maxYSpeed,minYspeed);
        anim = transform.GetComponent<Animator>();

        //temp code
        hs = gameObject.GetComponent<HeroStatus>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //AnimController();
        CustomizedTimer.ButtonTrigger("Jump",ref jump,ref jumpTimer, jumpTime);
    }

    private void FixedUpdate()
    {
        AnimController();
        Jump(); 
    }

    //when horizontal return true
    public bool Move()
    {
        Vector3 target;
        var val = Input.GetAxisRaw("Horizontal");
        var curSpeed = XSpeed.speedMani(val);
        XSpeed = new SpeedStruct(curSpeed, speedXInRate, speedXDeRate, maxXSpeed, minXspeed);
        target = transform.position + transform.right;
        transform.position=Vector3.MoveTowards(transform.position, target, XSpeed.speed* Time.deltaTime);
        
        if (val > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            return true;
        }
        else if (val < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            return true;
        }
        else return false;
    }


    //when fire1 return true
    public bool Attack()
    {
        CustomizedTimer.AutoTrigger(ref firable, ref fireTimer, fireCooldown);
        //this part controls the actul fireball
        if (Input.GetButton("Fire1")&&firable)
        {
            var fb=Instantiate(Fireball,transform.position,Quaternion.identity);
            fb.GetComponent<Projectile>().AttackPower = hs.AttackPower;
            firable = false;
            //return true;
        }
        //this part control the animation
        if (Input.GetButton("Fire1"))
        {
            //Instantiate(Fireball,transform.position,Quaternion.identity);
            firable = false;
            return true;
        }
        else {
            
            return false;
        }
        
    }

    //when not fire1 or horizontal, then idle
    public bool Idle()
    {
        return !(Move() || Attack());
    }

    private void AnimController()
    {
        anim.SetBool("Walk", Move());
        anim.SetBool("Attack", Attack());
        anim.SetBool("Idle", Idle());
    }

    void Jump()
    {
        
        float curSpeed;
        if (ground)
        {           
            if (!jump)
            {
                curSpeed = 0;
            }
            else {
                var val = Input.GetAxisRaw("Jump");
                curSpeed = YSpeed.speedMani(val);
            }
        }
        else
        {
            curSpeed = YSpeed.speedMani(0);
        }
        YSpeed = new SpeedStruct(curSpeed, speedYInRate, speedYDeRate, maxYSpeed, minYspeed);
        Vector3 target;
        target = transform.position + transform.up;
        transform.position = Vector3.MoveTowards(transform.position, target, YSpeed.speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "ColliderTile")
        {
            ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ColliderTile")
        {
            ground = true;
        }
    }

    void OnGround()
    {
        ground = true;
    }

    void LeaveGround()
    {
        ground = false;
    }
}
