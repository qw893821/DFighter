using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    private Gear _gear;

    public Gear Gear
    {
        get { return _gear; }
        //set { _gear = value; }
    }

    private void Start()
    {
        _gear = CustomizeController.GameManager.GM.IteamCollection.RandomLoot();
    }

    private void Update()
    {
        try
        {
            Debug.Log(_gear.itemName);
        }
        catch (System.Exception ex)
        {

            Debug.Log(ex.Message);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("player loot this, I will be destory");
            Destroy(this.gameObject);
        }
    }


    //private void OnEnable()
    //{
    //    _gear=CustomizeController.GameManager.GM.IteamCollection.RandomLoot();
    //}

}
