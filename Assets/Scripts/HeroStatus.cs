using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour,IStatus {
    private float attackPower;
    private float attackModifer;
    private int health;
    
    private int maxHealth;
    private bool hideUI;

    public float AttackPower { get { return attackPower* attackModifer; }  }
    public int Health { get { return health; }  }

    
    public int MaxHealth{get { return maxHealth; }  }


    public void Damaged(float val)
    {
        
    }

    // Use this for initialization
    void Start () {
        attackPower = 10.0f;
        attackModifer = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
