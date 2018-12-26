using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeController;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour,IStatus
{
    private float attackModifer;
    private bool hideUI;

    //ui display related value
    private float displayUITimer;
    private float displayDuration;
    [SerializeField]
    GameObject HealthUI;

    public float AttackPower { get { return _char.AttackPower * attackModifer; } }
    public int Health { get { return _char.Health; } }
    public int MaxHealth { get { return _char.MaxHealth; } }

    [SerializeField]
    private Characters _char;

    public Characters Char
    {
        get
        {
            return _char;
        }

        set
        {    }
    }

    float test;

    //local delegate collection
    UIDisplayDg uidgcollection;
    DeathDg deathcollection;

    public void Damaged(float inputVal)
    {
        _char.Health -= DamageVal(inputVal);
    }

    // Use this for initialization
    void Start()
    {
        //create a clone of enemy. this is required part. enemy should use the data but not sharing the same instance.
        _char = Instantiate(_char);
        displayDuration = 1.0f;
        displayUITimer = displayDuration;
        hideUI = true;

        //this part is goofy, need some change.
        uidgcollection = delegate { UIDisplay(hideUI, HealthUI,"Front",_char.Health, _char.MaxHealth,2.0f, displayUITimer, displayDuration); };
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
        healthbar.sizeDelta = new Vector2(2.0f * ((float)_char.Health / (float)_char.MaxHealth), 0.2f);

    }

    void Die()
    {
        if (_char.Health <= 0)
        {
            GameManager.GM.Loot(transform.position);
            //ProjectileController.UIdisplay -= delegate { UIDisplay(hideUI, HealthUI, displayUITimer, displayDuration); };
            //GameManager.DeathHandler -= delegate { Die(); };
            
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
