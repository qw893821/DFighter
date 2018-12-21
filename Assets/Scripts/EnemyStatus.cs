using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeController;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour, IStatus
{
    private float attackPower;
    private float attackModifer;
    private int health;
    private bool hideUI;
    private int maxHealth;

    //ui display related value
    private float displayUITimer;
    private float displayDuration;
    [SerializeField]
    GameObject HealthUI;

    public float AttackPower { get { return attackPower * attackModifer; } }
    public int Health { get { return health; } }
    public int MaxHealth { get { return maxHealth; } }


    float test;

    //local delegate collection
    UIDisplayDg uidgcollection;
    DeathDg deathcollection;

    public void Damaged(float inputVal)
    {
        health -= DamageVal(inputVal);
    }

    // Use this for initialization
    void Start()
    {
        displayDuration = 1.0f;
        displayUITimer = displayDuration;
        hideUI = true;
        maxHealth = 100;
        health = maxHealth;
        uidgcollection = delegate { UIDisplay(hideUI, HealthUI,"Front",health,maxHealth,2.0f, displayUITimer, displayDuration); };
        deathcollection = delegate { Die(); };
        ProjectileController.UIdisplay += uidgcollection;
        GameManager.GM.DeathHandler += deathcollection;
    }

    // Update is called once per frame
    void Update()
    {
    }

    int DamageVal(float inputVal)
    {
        int returnVal;
        returnVal = (int)inputVal;
        hideUI = false;
        Debug.Log("change show ui");
        //when hit&display is on, reset the timer keep showing ui;
        displayUITimer = displayDuration;
        return returnVal;
    }

    void UIDisplay(bool unshow, GameObject uigo, string uiname, float currentVal, float maxVal, float normalSize, float timer, float time)
    {
        UIController.UIDisplayHandler(unshow, uigo,uiname,currentVal,maxVal,normalSize);
        CustomizedTimer.AutoTrigger(ref unshow, ref timer, time);
    }

    void UIValUpdate()
    {
        var healthbar = HealthUI.transform.Find("Front").GetComponent<RectTransform>();
        healthbar.sizeDelta = new Vector2(2.0f * ((float)health / (float)maxHealth), 0.2f);

    }

    void Die()
    {
        if (health <= 0)
        {

            //ProjectileController.UIdisplay -= delegate { UIDisplay(hideUI, HealthUI, displayUITimer, displayDuration); };
            //GameManager.DeathHandler -= delegate { Die(); };
            Debug.Log("this has triggered");
            Destroy(this.gameObject);
        }
    }

    //private void OnEnable()
    //{
        
    //    //GameManager.DeathHandler += delegate { Die(); };
    //    //ProjectileController.UIdisplay += delegate { UIDisplay(hideUI, HealthUI, displayUITimer, displayDuration); };
    //    ProjectileController.UIdisplay += uidgcollection;
    //    GameManager.GM.DeathHandler += deathcollection;
    //}

    private void OnDisable()
    {

        //ProjectileController.UIdisplay -= delegate { UIDisplay(hideUI, HealthUI, displayUITimer, displayDuration); };
        // GameManager.DeathHandler -= delegate { Die(); };
        ProjectileController.UIdisplay -= uidgcollection;
        GameManager.GM.DeathHandler -= deathcollection;
    }
}
