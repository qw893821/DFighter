using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour, IStatus
{    

    private float attackModifer;
    private bool hideUI;
    

    public float AttackPower { get { return _hero.AttackPower*attackModifer; }  }
    public int Health { get { return _hero.Health; }  }

    
    public int MaxHealth{get { return _hero.MaxHealth; }  }
    public bool _________;

    //test scriptable object test
    [SerializeField]
    private Characters _hero;

    //gear list test;
    private List<Gear> gears=new List<Gear>();
    public List<Gear> Gears { get { return gears; } }

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
        HeroTestfunc(_hero);
    }


    //let the item determines which type it is?
    // them add to the inventory?
    //or, just add the item to the inventory.
    void HeroTestfunc(ScriptableObject so) 
    { 
        
    }

    public void AddGear(Gear gear)
    {
        Debug.Log(gears.Count);
        gears.Add(gear);
        Debug.Log(gears.Count);
    }
}
