using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour, IStatus
{    

    private float attackModifer;
    //private int maxHealth;
    private bool hideUI;
    
    public float AttackPower { get { return /*attackPower* attackModifer*/_hero.AttackPower*attackModifer; }  }
    public int Health { get { return /*health*/_hero.Health; }  }

    
    public int MaxHealth{get { return /*maxHealth*/_hero.MaxHealth; }  }
    public bool _________;

    //test scriptable object test
    [SerializeField]
    private Characters _hero;


    public Characters Char { get { return _hero; } set { } }



    public void Damaged(float val)
    {
        
    }

    // Use this for initialization
    void Start () {
        attackModifer = 2.0f;
        //make it clone, so no worry when testing
        _hero = Instantiate(_hero);   
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
