using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeController;
public class Projectile : MonoBehaviour,IProjectile {
    //private val
    private float speed;
    private float duration;
    private Vector3 target;
    private bool end;
    private float selfTimer;

    public float Speed { get { return speed; } set {speed=value; } }

    public Vector3 Target { get { return target; } set { target = value; } }
    public float Duration { get { return duration; } set { duration = value; } }

    public bool End { get { return end; } set { end = value; } }

    public float Selftimer { get { return selfTimer; } set { selfTimer = value; } }

    public float AttackPower
    {
        get;
        set;
    }

    public void Move()
    {
        target = transform.position + transform.right;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Use this for initialization
    void Start () {
        speed = 2.0f;
        duration = 4.0f;
        selfTimer = duration;
        end = false;

	}
	
	// Update is called once per frame
	void Update () {
        CustomizedTimer.AutoTrigger(ref end,ref selfTimer,duration);
        if (end)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        ProjectileController.PMoveDg += Move;
    }

    private void OnDisable()
    {
        ProjectileController.PMoveDg -= Move;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            var hitES=other.gameObject.GetComponent<EnemyStatus>();
            hitES.Damaged(AttackPower);
        }
        else if (other.tag=="Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
