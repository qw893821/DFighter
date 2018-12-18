using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeController;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour, IStatus {
    private float attackPower;
    private float attackModifer;
    private int health;
    private bool hideUI;
    private int maxHealth;

    //ui display related value
    private float dispalyUITimer;
    private float dispalyDuration;
    [SerializeField]
    GameObject HealthUI;

    public float AttackPower{ get { return attackPower*attackModifer; }  } 
    public int Health { get { return health; }  }
    public int MaxHealth { get { return maxHealth; } }


    float test;


    public void Damaged(float inputVal)
    {
        health -= DamageVal(inputVal);
    }

    // Use this for initialization
    void Start () {
        dispalyDuration = 1.0f;
        dispalyUITimer = dispalyDuration;
        hideUI = true;
        maxHealth = 100;
        health = maxHealth;
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    int DamageVal(float inputVal)
    {
        int returnVal;
        returnVal = (int)inputVal;
        hideUI = false;
        Debug.Log("change show ui");
        //when hit&display is on, reset the timer keep showing ui;
        dispalyUITimer = dispalyDuration;
        return returnVal;
    }

    void UIDisplay()
    {
        if (!hideUI)
        {
            HealthUI.SetActive(true);
            try
            {
                UIValUpdate();
            }
            catch (System.Exception ex)
            {

                Debug.Log(ex.Message);
                Debug.Log(ex.StackTrace);
            }
        }
        else if (hideUI)
        {
            HealthUI.SetActive(false);
        }
        CustomizedTimer.AutoTrigger(ref hideUI, ref dispalyUITimer, dispalyDuration);
    }

    void UIValUpdate()
    {
        var healthbar=HealthUI.transform.Find("Front").GetComponent<RectTransform>();
        healthbar.sizeDelta = new Vector2(2.0f* ((float)health / (float)maxHealth),0.2f);
        
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        GameManager.DeathHandler += Die;
        ProjectileController.UIdisplay += UIDisplay;
    }

    private void OnDisable()
    {
        GameManager.DeathHandler -= Die;
        ProjectileController.UIdisplay -= UIDisplay;
    }
}
